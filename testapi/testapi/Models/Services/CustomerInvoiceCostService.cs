using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerInvoiceCostService
    {
        Task<ICollection<CustomerInvoiceCostDTOGet>> GetAllCustomerInvoiceCosts(CustomerInvoiceCostFilter filter);
        Task<CustomerInvoiceCostDTOGet> GetCustomerInvoiceCostById(int id);
        Task<CustomerInvoiceCostDTOGet> CreateCustomerInvoiceCost(CustomerInvoiceCost customerInvoiceCost);
        Task<CustomerInvoiceCostDTOGet> UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost customerInvoiceCost);
        Task<CustomerInvoiceCostDTOGet> DeleteCustomerInvoiceCost(int id);

        Task<int> CountCustomerInvoiceCosts(CustomerInvoiceCostFilter filter);
        Task<string> MassDeleteCustomerInvoiceCost(List<int> customerInvoiceCostId);
        Task<string> MassUpdateCustomerInvoiceCost(List<CustomerInvoiceCostDTOGet> newCustomerInvoiceCosts);
        Task<string> MassSaveCustomerInvoiceCost(List<CustomerInvoiceCostDTO> CustomerInvoiceCostsList);
    }
    public class CustomerInvoiceCostService : ICustomerInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _serviceCustomerInvoice;
        private readonly ICostRegistryService _costRegistry;
        public CustomerInvoiceCostService(Progetto_FormativoContext ctx, ICustomerInvoicesService service, ICostRegistryService cr)
        {
            _context = ctx;
            _serviceCustomerInvoice = service;
            _costRegistry = cr;
        }

        public async Task<ICollection<CustomerInvoiceCostDTOGet>> GetAllCustomerInvoiceCosts(CustomerInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountCustomerInvoiceCosts(CustomerInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        public IQueryable<CustomerInvoiceCostDTOGet> ApplyFilter(CustomerInvoiceCostFilter filter)
        {
            int itemsPage = 10;
            var query = _context.CustomerInvoiceCosts.Include(x => x.CostRegistry).Include(x => x.CustomerInvoice).AsQueryable();

            if (!string.IsNullOrEmpty(filter.CustomerInvoiceCostCustomerInvoiceCode))
            {
                query = query.Where(x => x.CustomerInvoice.CustomerInvoiceCode.Contains(filter.CustomerInvoiceCostCustomerInvoiceCode));
            }
            if (!string.IsNullOrEmpty(filter.CustomerInvoiceCostName))
            {
                query = query.Where(x => x.Name.Contains(filter.CustomerInvoiceCostName));
            }

            if (filter.CustomerInvoiceCostCostFrom != null && filter.CustomerInvoiceCostCostTo != null)
            {
                if (filter.CustomerInvoiceCostCostFrom > filter.CustomerInvoiceCostCostTo)
                {
                    throw new ErrorInputPropertyException("CostFrom cannot be more than CostTo.");
                }

                query = query.Where(s => s.Cost >= filter.CustomerInvoiceCostCostFrom && s.Cost <= filter.CustomerInvoiceCostCostTo);
            }
            else if (filter.CustomerInvoiceCostCostFrom != null)
            {
                query = query.Where(s => s.Cost >= filter.CustomerInvoiceCostCostFrom);
            }
            else if (filter.CustomerInvoiceCostCostTo != null)
            {
                query = query.Where(s => s.Cost <= filter.CustomerInvoiceCostCostTo);
            }

            if (!string.IsNullOrEmpty(filter.RegistryCode))
            {
                query = query.Where(x => x.CostRegistry.CostRegistryName.Contains(filter.RegistryCode));
            }

            if (filter.CustomerInvoiceCostQuantity != null)
            {
                query = query.Where(x => x.Quantity == filter.CustomerInvoiceCostQuantity);
            }
            if (filter.CustomerInvoiceCostPage != null)
            {
                query = query.Skip(((int)filter.CustomerInvoiceCostPage - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => CustomerInvoiceCostMapper.MapGet(x));
        }

        public async Task<CustomerInvoiceCostDTOGet> GetCustomerInvoiceCostById(int id)
        {
            var data = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsID == id).Include(x => x.CostRegistry).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new NotFoundException("Customer Invoice Cost not found!");
            }
            return CustomerInvoiceCostMapper.MapGet(data);
        }

        public async Task<CustomerInvoiceCostDTOGet> CreateCustomerInvoiceCost(CustomerInvoiceCost customerInvoiceCost)
        {
            CustomerInvoice ci;

            if (!await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceID).AnyAsync())
                throw new ErrorInputPropertyException("Customer Invoice Id not found!");


            ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceID).Include(x => x.Status).Include(x => x.CustomerInvoiceCosts).FirstAsync();
            if (ci.Status.StatusName.ToLower().Equals("paid"))
                throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");

            var total = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == ci.CustomerInvoiceID).SumAsync(x => x.Cost);
            if (total != null)
                ci.InvoiceAmount = total + customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            else
                ci.InvoiceAmount = customerInvoiceCost.Cost * customerInvoiceCost.Quantity;


            _context.Add(customerInvoiceCost);
            await _context.SaveChangesAsync();

            await _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceID, ci);
            return CustomerInvoiceCostMapper.MapGet(customerInvoiceCost);
        }

        public async Task<CustomerInvoiceCostDTOGet> UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost newCustomerInvCost)
        {
            CustomerInvoice? newCustomerInvoice;

            var oldCustomerInvCost = await _context.CustomerInvoiceCosts
                .Where(x => x.CustomerInvoiceCostsID == id).Include(x => x.CostRegistry)
                .FirstOrDefaultAsync();

            var oldCustomerInvoice = await _context.CustomerInvoices
                .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID).Include(x => x.Status)
                .FirstOrDefaultAsync();

            oldCustomerInvoice.InvoiceAmount -= (oldCustomerInvCost.Cost * oldCustomerInvCost.Quantity);

            if (oldCustomerInvCost != null && id >= 0)
            {

                if (newCustomerInvCost.CustomerInvoiceID != null)
                    oldCustomerInvCost.CustomerInvoiceID = newCustomerInvCost.CustomerInvoiceID;

                if (newCustomerInvCost.CustomerInvoiceID != null)
                    if (!await _context.CustomerInvoices.AnyAsync(x => x.CustomerInvoiceID == newCustomerInvCost.CustomerInvoiceID))
                        throw new NotFoundException("Customer Invoice not Found");

                if (newCustomerInvCost.Quantity > 0)
                    oldCustomerInvCost.Quantity = newCustomerInvCost.Quantity ?? oldCustomerInvCost.Quantity;

                if (newCustomerInvCost.Cost > 0)
                    oldCustomerInvCost.Cost = newCustomerInvCost.Cost ?? oldCustomerInvCost.Cost;
                if (newCustomerInvCost.CostRegistryID != null)
                    oldCustomerInvCost.CostRegistryID = newCustomerInvCost.CostRegistryID ?? oldCustomerInvCost.CostRegistryID;
                if (newCustomerInvCost.CostRegistry != null)
                    oldCustomerInvCost.CostRegistry = newCustomerInvCost.CostRegistry ?? oldCustomerInvCost.CostRegistry;

                newCustomerInvoice = await _context.CustomerInvoices
                    .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID).Include(x => x.Status)
                    .FirstOrDefaultAsync();

                if (newCustomerInvoice.Status.StatusName.ToLower().Equals("paid"))
                    throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");

                oldCustomerInvCost.Name = newCustomerInvCost.Name ?? oldCustomerInvCost.Name;

                _context.CustomerInvoiceCosts.Update(oldCustomerInvCost);

                await _context.SaveChangesAsync();

                if (oldCustomerInvCost.Cost > 0 && oldCustomerInvCost.Quantity > 0)
                {
                    var total = oldCustomerInvCost.Cost * oldCustomerInvCost.Quantity;

                    newCustomerInvoice.InvoiceAmount += total;

                    await _serviceCustomerInvoice.UpdateCustomerInvoice(newCustomerInvoice.CustomerInvoiceID, newCustomerInvoice);

                    await _serviceCustomerInvoice.UpdateCustomerInvoice(oldCustomerInvoice.CustomerInvoiceID, oldCustomerInvoice);
                }

                return CustomerInvoiceCostMapper.MapGet(oldCustomerInvCost);
            }

            throw new NotFoundException("Customer Invoice Cost not found");
        }


        public async Task<CustomerInvoiceCostDTOGet> DeleteCustomerInvoiceCost(int id)
        {
            var data = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsID == id).FirstOrDefaultAsync();
            if (data == null || id < 1)
            {
                throw new NotFoundException("Customer Invoice Cost not found!");
            }
            CustomerInvoice ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == data.CustomerInvoiceID).FirstAsync();
            var total = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == ci.CustomerInvoiceID).SumAsync(x => x.Cost);
            ci.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.CustomerInvoices.Update(ci);
            _context.CustomerInvoiceCosts.Remove(data);
            await _context.SaveChangesAsync();
            return CustomerInvoiceCostMapper.MapGet(data);

        }
        public async Task<string> MassDeleteCustomerInvoiceCost(List<int> customerInvoiceCostId)
        {
            int count = 0;
            foreach (var id in customerInvoiceCostId)
            {
                var data = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsID == id).FirstOrDefaultAsync();
                if (data == null || id < 1)
                    continue;
                CustomerInvoice ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == data.CustomerInvoiceID).FirstAsync();
                var total = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == ci.CustomerInvoiceID).SumAsync(x => x.Cost);
                ci.InvoiceAmount = total - data.Cost * data.Quantity;
                _context.CustomerInvoices.Update(ci);
                _context.CustomerInvoiceCosts.Remove(data);
                await _context.SaveChangesAsync();
                count++;
            }
            return $"{count} Customer Invoice Cost were delete out of {customerInvoiceCostId.Count}";

        }

        public async Task<string> MassUpdateCustomerInvoiceCost(List<CustomerInvoiceCostDTOGet> newCustomerInvoiceCosts)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (CustomerInvoiceCostDTOGet customerInvoiceCost in newCustomerInvoiceCosts)
                {
                    CustomerInvoice? newCustomerInvoice;

                    // Fetch the existing CustomerInvoiceCost record from the database based on the provided ID
                    var oldCustomerInvCost = await _context.CustomerInvoiceCosts
                        .Where(x => x.CustomerInvoiceCostsID == customerInvoiceCost.CustomerInvoiceCostsId).Include(x => x.CostRegistry)
                        .FirstOrDefaultAsync();

                    // Fetch the related CustomerInvoice for the existing cost record
                    var oldCustomerInvoice = await _context.CustomerInvoices
                        .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID).Include(x => x.Status)
                        .FirstOrDefaultAsync();

                    // Subtract the old cost amount from the associated invoice before updating
                    oldCustomerInvoice.InvoiceAmount -= (oldCustomerInvCost.Cost * oldCustomerInvCost.Quantity);

                    // Ensure the cost record exists and the provided ID is valid
                    if (oldCustomerInvCost != null)
                    {
                        // If a new CustomerInvoiceId is provided, update it
                        if (customerInvoiceCost.CustomerInvoiceId != null)
                            oldCustomerInvCost.CustomerInvoiceID = customerInvoiceCost.CustomerInvoiceId;

                        // Ensure the new CustomerInvoiceId exists in the database, otherwise throw an exception
                        if (customerInvoiceCost.CustomerInvoiceId != null)
                            if (!await _context.CustomerInvoices.AnyAsync(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceId))
                                throw new NotFoundException("Customer Invoice not Found");

                        // If a new quantity is provided and greater than 0, update the record
                        if (customerInvoiceCost.Quantity > 0)
                            oldCustomerInvCost.Quantity = customerInvoiceCost.Quantity ?? oldCustomerInvCost.Quantity;

                        // If a new cost is provided and greater than 0, update the record
                        if (customerInvoiceCost.Cost > 0)
                            oldCustomerInvCost.Cost = customerInvoiceCost.Cost ?? oldCustomerInvCost.Cost;

                        var registry1 = await _context.CostRegistries.Where(x => x.CostRegistryUniqueCode == customerInvoiceCost.CostRegistryCode).FirstOrDefaultAsync();
                        if (registry1 == null)
                            throw new NotFoundException("Registry not found");
                        else
                        {
                            oldCustomerInvCost.CostRegistry = registry1;
                            oldCustomerInvCost.CostRegistryID = registry1.CostRegistryID;
                        }
                        if (customerInvoiceCost.Cost > 0)
                            oldCustomerInvCost.Cost = customerInvoiceCost.Cost ?? oldCustomerInvCost.Cost;

                        // Fetch the updated CustomerInvoice associated with the cost
                        newCustomerInvoice = await _context.CustomerInvoices
                            .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID).Include(x => x.Status)
                            .FirstOrDefaultAsync();

                        // Prevent modifications if the invoice is already marked as "paid"
                        if (newCustomerInvoice.Status.StatusName.ToLower().Equals("paid"))
                            throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");

                        // Update the name field if a new value is provided
                        oldCustomerInvCost.Name = customerInvoiceCost.Name ?? oldCustomerInvCost.Name;
                        if (string.IsNullOrEmpty(customerInvoiceCost.CostRegistryCode))
                        {
                            var registry = await _context.CostRegistries.Where(x => x.CostRegistryUniqueCode == customerInvoiceCost.CostRegistryCode).FirstOrDefaultAsync();
                            if (registry != null)
                                oldCustomerInvCost.CostRegistry = registry;
                        }

                        // Mark the updated cost record for database update
                        _context.CustomerInvoiceCosts.Update(oldCustomerInvCost);

                        // Save changes to the database
                        await _context.SaveChangesAsync();

                        // If the cost and quantity are valid, recalculate the invoice amount
                        if (oldCustomerInvCost.Cost > 0 && oldCustomerInvCost.Quantity > 0)
                        {
                            // Calculate the new total cost for the updated invoice
                            var total = oldCustomerInvCost.Cost * oldCustomerInvCost.Quantity;

                            // Update the invoice's total amount
                            newCustomerInvoice.InvoiceAmount += total;

                            // Call the external service to update the invoice
                            await _serviceCustomerInvoice.UpdateCustomerInvoice(newCustomerInvoice.CustomerInvoiceID, newCustomerInvoice);

                            // Update the old invoice (which had its amount subtracted earlier)
                            await _serviceCustomerInvoice.UpdateCustomerInvoice(oldCustomerInvoice.CustomerInvoiceID, oldCustomerInvoice);
                        }
                    }
                    count++;
                }
                await transaction.CommitAsync();
                return $"{count} Customer Invoice Costs were deleted out of {newCustomerInvoiceCosts.Count}";
            }
            catch (NotFoundException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (ErrorInputPropertyException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Database update error occurred", ex);
            }
        }

        public async Task<string> MassSaveCustomerInvoiceCost(List<CustomerInvoiceCostDTO> CustomerInvoiceCostsList)
        {
            int count = 0;

            foreach (CustomerInvoiceCostDTO customerInvoiceCostDto in CustomerInvoiceCostsList)
            {
                CustomerInvoiceCost customerInvoiceCost = Mapper.CustomerInvoiceCostMapper.Map(customerInvoiceCostDto, await _costRegistry.GetCostRegistryByCode(customerInvoiceCostDto.CostRegistryCode), await _serviceCustomerInvoice.GetOnlyCustomerInvoiceById((int)customerInvoiceCostDto.CustomerInvoiceId));
                CustomerInvoice ci;
                if (customerInvoiceCost == null)
                    throw new NullPropertyException("Couldn't create customer Invoice Cost,the input was null");
                if (customerInvoiceCost.CustomerInvoiceID == null)
                    throw new NullPropertyException("Customer Invoice Id can't be null!");
                if (!await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceID).AnyAsync())
                    throw new ErrorInputPropertyException("Customer Invoice Id not found!");
                if (customerInvoiceCost.Cost < 0 || customerInvoiceCost.Quantity < 1 || customerInvoiceCost.Cost == null || customerInvoiceCost.Quantity == null)
                    throw new ErrorInputPropertyException("Values can't be lesser than 1 or null");
                if (string.IsNullOrEmpty(customerInvoiceCost.Name))
                    throw new NullPropertyException("Name can't be empty");

                ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceID).Include(x => x.Status).FirstAsync();
                if (ci.Status.StatusName.ToLower().Equals("paid"))
                    throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");
                var total = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == ci.CustomerInvoiceID).SumAsync(x => x.Cost);
                if (total != null)
                    ci.InvoiceAmount = total + customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
                else
                    ci.InvoiceAmount = customerInvoiceCost.Cost * customerInvoiceCost.Quantity;

                if (customerInvoiceCost.CostRegistryID == null)
                    throw new ErrorInputPropertyException("Cost Registry Code wrong or missing");

                await _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceID, ci);

                _context.Add(customerInvoiceCost);
                count++;
            }
            await _context.SaveChangesAsync();
            return $"{count} out of {CustomerInvoiceCostsList.Count} Customer Invoice Costs were created";
        }
    }
}
