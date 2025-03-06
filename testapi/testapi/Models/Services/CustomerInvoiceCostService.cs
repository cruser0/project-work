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
                query = query.Where(x => x.CustomerInvoiceId == filter.CustomerInvoiceCostCustomerInvoiceId);
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
            var data =await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefaultAsync();
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
            if (customerInvoiceCost.CustomerInvoiceId == null)
                throw new NullPropertyException("Customer Invoice Id can't be null!");
            if (!await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId).AnyAsync())
                throw new ErrorInputPropertyException("Customer Invoice Id not found!");
            if (customerInvoiceCost.Cost < 0 || customerInvoiceCost.Quantity < 1 || customerInvoiceCost.Cost == null || customerInvoiceCost.Quantity == null)
                throw new ErrorInputPropertyException("Values can't be lesser than 1 or null");
            if (string.IsNullOrEmpty(customerInvoiceCost.Name))
                throw new NullPropertyException("Name can't be empty");

            ci =await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId).FirstAsync();
            if (ci.Status.ToLower().Equals("paid"))
                throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");
            var total =(await _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{ci.CustomerInvoiceId}\"").ToListAsync()).FirstOrDefault()?.TotalSpent;
            if (total != null)
                ci.InvoiceAmount = total + customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            else
                ci.InvoiceAmount = customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            //_context.CustomerInvoices.Update(ci);
            await _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceId, ci);

            _context.Add(customerInvoiceCost);
            await _context.SaveChangesAsync();
            return CustomerInvoiceCostMapper.MapGet(customerInvoiceCost);
        }

        public async Task<CustomerInvoiceCostDTOGet> UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost customerInvoiceCost)
        {
            CustomerInvoice? ci;
            var cicDB = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefaultAsync();
            var oldCi =await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == cicDB.CustomerInvoiceId).FirstOrDefaultAsync();
            oldCi.InvoiceAmount -= (cicDB.Cost * cicDB.Quantity);
            if (cicDB != null && id >= 0)
            {
                if (customerInvoiceCost.CustomerInvoiceId != null)
                    cicDB.CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId;
                if (!await _context.CustomerInvoices.AnyAsync(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId))
                    throw new NotFoundException("Customer Invoice not Found");
                if (customerInvoiceCost.Quantity > 0)
                    cicDB.Quantity = customerInvoiceCost.Quantity ?? cicDB.Quantity;
                if (customerInvoiceCost.Cost > 0)
                    cicDB.Cost = customerInvoiceCost.Cost ?? cicDB.Cost;
                ci = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == cicDB.CustomerInvoiceId).FirstOrDefaultAsync();
                if (ci.Status.ToLower().Equals("paid"))
                    throw new ErrorInputPropertyException("Cannot add cost to a paid invoice");
                cicDB.Name = customerInvoiceCost.Name ?? cicDB.Name;
                _context.CustomerInvoiceCosts.Update(cicDB);
                await _context.SaveChangesAsync();
                if (cicDB.Cost > 0 && cicDB.Quantity > 0)
                {
                    var total = (await _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{customerInvoiceCost.CustomerInvoiceId}\"").ToListAsync()).FirstOrDefault()?.TotalSpent;
                    ci.InvoiceAmount = total;
                    await _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceId, ci);
                    _context.CustomerInvoices.Update(oldCi);
                    await _context.SaveChangesAsync();
                }
                return CustomerInvoiceCostMapper.MapGet(cicDB);
            }
            throw new NotFoundException("Customer Invoice Cost not found");
        }

        public async Task<CustomerInvoiceCostDTOGet> DeleteCustomerInvoiceCost(int id)
        {
            var data = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefaultAsync();
            if (data == null || id < 1)
            {
                throw new NotFoundException("Customer Invoice Cost not found!");
            }
            CustomerInvoice ci =await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == data.CustomerInvoiceId).FirstAsync();
            var total = (await _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{ci.CustomerInvoiceId}\"").ToListAsync()).FirstOrDefault()?.TotalSpent;
            ci.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.CustomerInvoices.Update(ci);
            _context.CustomerInvoiceCosts.Remove(data);
            await _context.SaveChangesAsync();
            return CustomerInvoiceCostMapper.MapGet(data);

        }
    }
}
