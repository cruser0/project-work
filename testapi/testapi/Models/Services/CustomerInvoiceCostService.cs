using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
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
    }
    public class CustomerInvoiceCostService : ICustomerInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _serviceCustomerInvoice;
        public CustomerInvoiceCostService(Progetto_FormativoContext ctx, ICustomerInvoicesService service)
        {
            _context = ctx;
            _serviceCustomerInvoice = service;
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
            var query = _context.CustomerInvoiceCosts.AsQueryable();

            if (filter.CustomerInvoiceCostCustomerInvoiceId != null)
            {
                query = query.Where(x => x.CustomerInvoiceID == filter.CustomerInvoiceCostCustomerInvoiceId);
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
            var data = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsID == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new NotFoundException("Customer Invoice Cost not found!");
            }
            return CustomerInvoiceCostMapper.MapGet(data);
        }

        public async Task<CustomerInvoiceCostDTOGet> CreateCustomerInvoiceCost(CustomerInvoiceCost customerInvoiceCost)
        {
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

            ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoiceCost.CustomerInvoiceID).FirstAsync();
            if (ci.Status.ToLower().Equals("paid"))
                throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");
            var total = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == ci.CustomerInvoiceID).SumAsync(x => x.Cost);
            if (total != null)
                ci.InvoiceAmount = total + customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            else
                ci.InvoiceAmount = customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            //_context.CustomerInvoices.Update(ci);
            await _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceID, ci);

            _context.Add(customerInvoiceCost);
            await _context.SaveChangesAsync();
            return CustomerInvoiceCostMapper.MapGet(customerInvoiceCost);
        }

        public async Task<CustomerInvoiceCostDTOGet> UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost newCustomerInvCost)
        {
            // Declare a variable to hold the new related CustomerInvoice
            CustomerInvoice? newCustomerInvoice;

            // Fetch the existing CustomerInvoiceCost record from the database based on the provided ID
            var oldCustomerInvCost = await _context.CustomerInvoiceCosts
                .Where(x => x.CustomerInvoiceCostsID == id)
                .FirstOrDefaultAsync();

            // Fetch the related CustomerInvoice for the existing cost record
            var oldCustomerInvoice = await _context.CustomerInvoices
                .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID)
                .FirstOrDefaultAsync();

            // Subtract the old cost amount from the associated invoice before updating
            oldCustomerInvoice.InvoiceAmount -= (oldCustomerInvCost.Cost * oldCustomerInvCost.Quantity);

            // Ensure the cost record exists and the provided ID is valid
            if (oldCustomerInvCost != null && id >= 0)
            {

                // If a new CustomerInvoiceId is provided, update it
                if (newCustomerInvCost.CustomerInvoiceID != null)
                    oldCustomerInvCost.CustomerInvoiceID = newCustomerInvCost.CustomerInvoiceID;

                // Ensure the new CustomerInvoiceId exists in the database, otherwise throw an exception
                if (newCustomerInvCost.CustomerInvoiceID != null)
                    if (!await _context.CustomerInvoices.AnyAsync(x => x.CustomerInvoiceID == newCustomerInvCost.CustomerInvoiceID))
                        throw new NotFoundException("Customer Invoice not Found");

                // If a new quantity is provided and greater than 0, update the record
                if (newCustomerInvCost.Quantity > 0)
                    oldCustomerInvCost.Quantity = newCustomerInvCost.Quantity ?? oldCustomerInvCost.Quantity;

                // If a new cost is provided and greater than 0, update the record
                if (newCustomerInvCost.Cost > 0)
                    oldCustomerInvCost.Cost = newCustomerInvCost.Cost ?? oldCustomerInvCost.Cost;

                // Fetch the updated CustomerInvoice associated with the cost
                newCustomerInvoice = await _context.CustomerInvoices
                    .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID)
                    .FirstOrDefaultAsync();

                // Prevent modifications if the invoice is already marked as "paid"
                if (newCustomerInvoice.Status.ToLower().Equals("paid"))
                    throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");

                // Update the name field if a new value is provided
                oldCustomerInvCost.Name = newCustomerInvCost.Name ?? oldCustomerInvCost.Name;

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

                // Return the updated CustomerInvoiceCost as a DTO
                return CustomerInvoiceCostMapper.MapGet(oldCustomerInvCost);
            }

            // If the cost record was not found, throw an exception
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
                        .Where(x => x.CustomerInvoiceCostsID == customerInvoiceCost.CustomerInvoiceCostsId)
                        .FirstOrDefaultAsync();

                    // Fetch the related CustomerInvoice for the existing cost record
                    var oldCustomerInvoice = await _context.CustomerInvoices
                        .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID)
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

                        // Fetch the updated CustomerInvoice associated with the cost
                        newCustomerInvoice = await _context.CustomerInvoices
                            .Where(x => x.CustomerInvoiceID == oldCustomerInvCost.CustomerInvoiceID)
                            .FirstOrDefaultAsync();

                        // Prevent modifications if the invoice is already marked as "paid"
                        if (newCustomerInvoice.Status.ToLower().Equals("paid"))
                            throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");

                        // Update the name field if a new value is provided
                        oldCustomerInvCost.Name = customerInvoiceCost.Name ?? oldCustomerInvCost.Name;

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
    }
}
