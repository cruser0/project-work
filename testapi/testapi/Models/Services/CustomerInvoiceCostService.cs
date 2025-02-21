using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
        public interface ICustomerInvoiceCostService
        {
            ICollection<CustomerInvoiceCostDTOGet> GetAllCustomerInvoiceCosts(CustomerInvoiceCostFilter filter);
            CustomerInvoiceCostDTOGet GetCustomerInvoiceCostById(int id);
            CustomerInvoiceCostDTOGet CreateCustomerInvoiceCost(CustomerInvoiceCost customerInvoiceCost);
            CustomerInvoiceCostDTOGet UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost customerInvoiceCost);
            CustomerInvoiceCostDTOGet DeleteCustomerInvoiceCost(int id);

            int CountCustomerInvoiceCosts(CustomerInvoiceCostFilter filter);
        }
    public class CustomerInvoiceCostService: ICustomerInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _serviceCustomerInvoice;
        public CustomerInvoiceCostService(Progetto_FormativoContext ctx, ICustomerInvoicesService service)
        {
            _context = ctx;
            _serviceCustomerInvoice = service;
        }

        public ICollection<CustomerInvoiceCostDTOGet> GetAllCustomerInvoiceCosts(CustomerInvoiceCostFilter filter)
        {
            return ApplyFilter(filter).ToList();
        }

        public int CountCustomerInvoiceCosts(CustomerInvoiceCostFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        public IQueryable<CustomerInvoiceCostDTOGet> ApplyFilter(CustomerInvoiceCostFilter filter)
        {
            int itemsPage = 10;
            var query = _context.CustomerInvoiceCosts.AsQueryable();

            if (filter.CustomerInvoiceId != null)
            {
                query = query.Where(x => x.CustomerInvoiceId == filter.CustomerInvoiceId);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name == filter.Name);
            }

            if (filter.CostFrom != null && filter.CostTo != null)
            {
                if (filter.CostFrom > filter.CostTo)
                {
                    throw new ArgumentException("CostFrom cannot be more than CostTo.");
                }

                query = query.Where(s => s.Cost >= filter.CostFrom && s.Cost <= filter.CostTo);
            }
            else if (filter.CostFrom != null)
            {
                query = query.Where(s => s.Cost >= filter.CostFrom);
            }
            else if (filter.CostTo != null)
            {
                query = query.Where(s => s.Cost <= filter.CostTo);
            }

            if (filter.Quantity != null)
            {
                query = query.Where(x => x.Quantity == filter.Quantity);
            }
            if (filter.page != null)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => CustomerInvoiceCostMapper.MapGet(x));
        }

        public CustomerInvoiceCostDTOGet GetCustomerInvoiceCostById(int id)
        {
            var data = _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentException("Customer Invoice Cost not found!");
            }
            return CustomerInvoiceCostMapper.MapGet(data);
        }

        public CustomerInvoiceCostDTOGet CreateCustomerInvoiceCost(CustomerInvoiceCost customerInvoiceCost)
        {
            CustomerInvoice ci;
            if (customerInvoiceCost == null)
                throw new ArgumentNullException("Couldn't create customer Invoice Cost");
            if (customerInvoiceCost.CustomerInvoiceId == null)
                throw new ArgumentException("Customer Invoice Id can't be null!");
            if (!_context.CustomerInvoices.Where(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId).Any())
                throw new ArgumentException("Customer Invoice Id not found!");
            if (customerInvoiceCost.Cost < 0 || customerInvoiceCost.Quantity < 1 || customerInvoiceCost.Cost == null || customerInvoiceCost.Quantity == null)
                throw new ArgumentException("Values can't be lesser than 1 or null");
            if (string.IsNullOrEmpty(customerInvoiceCost.Name))
                throw new ArgumentException("Name can't be empty");

            ci = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId).First();
            if(ci.Status.ToLower().Equals("paid"))
                throw new ArgumentException("Cannot add cost to a paid invoice");
            var total = _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{ci.CustomerInvoiceId}\"").ToList().FirstOrDefault()?.TotalSpent;
            if (total != null)
                ci.InvoiceAmount = total + customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            else
                ci.InvoiceAmount = customerInvoiceCost.Cost * customerInvoiceCost.Quantity;
            //_context.CustomerInvoices.Update(ci);
            _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceId,ci);

            _context.Add(customerInvoiceCost);
            _context.SaveChanges();
            return CustomerInvoiceCostMapper.MapGet(customerInvoiceCost);
        }

        public CustomerInvoiceCostDTOGet UpdateCustomerInvoiceCost(int id, CustomerInvoiceCost customerInvoiceCost)
        {
            CustomerInvoice? ci;
            var cicDB = _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefault();
            var oldCi=_context.CustomerInvoices.Where(x=>x.CustomerInvoiceId==cicDB.CustomerInvoiceId).FirstOrDefault();
            oldCi.InvoiceAmount = oldCi.InvoiceAmount - (cicDB.Cost * cicDB.Quantity);
            if (cicDB != null && id >= 0)
            {
                if (customerInvoiceCost.CustomerInvoiceId != null)
                    cicDB.CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId;
                if (!_context.CustomerInvoices.Any(x => x.CustomerInvoiceId == customerInvoiceCost.CustomerInvoiceId))
                    throw new ArgumentNullException("Customer Invoice not Found");
                if (customerInvoiceCost.Quantity > 0)
                    cicDB.Quantity = customerInvoiceCost.Quantity ?? cicDB.Quantity;
                if (customerInvoiceCost.Cost > 0)
                    cicDB.Cost = customerInvoiceCost.Cost ?? cicDB.Cost;
                ci = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == cicDB.CustomerInvoiceId).FirstOrDefault();
                if (ci.Status.ToLower().Equals("paid"))
                    throw new ArgumentException("Cannot add cost to a paid invoice");
                cicDB.Name = customerInvoiceCost.Name ?? cicDB.Name;
                _context.CustomerInvoiceCosts.Update(cicDB);
                _context.SaveChanges();
                if (cicDB.Cost > 0 && cicDB.Quantity > 0)
                {
                    var total = _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{customerInvoiceCost.CustomerInvoiceId}\"").ToList().FirstOrDefault()?.TotalSpent;
                    ci.InvoiceAmount = total;
                    _serviceCustomerInvoice.UpdateCustomerInvoice(ci.CustomerInvoiceId, ci);
                    _context.CustomerInvoices.Update(oldCi);
                   _context.SaveChanges();
                }
                return CustomerInvoiceCostMapper.MapGet(cicDB);
            }
            throw new ArgumentNullException("Customer Invoice Cost not found");
        }

        public CustomerInvoiceCostDTOGet DeleteCustomerInvoiceCost(int id)
        {
            var data = _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceCostsId == id).FirstOrDefault();
            if (data == null || id < 1)
            {
                throw new ArgumentNullException("Customer Invoice Cost not found!");
            }
            CustomerInvoice ci = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == data.CustomerInvoiceId).First();
            var total = _context.TotalSpentPerCustomerInvoiceIDs.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @customerInvoiceID=\"{ci.CustomerInvoiceId}\"").ToList().FirstOrDefault()?.TotalSpent;
            ci.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.CustomerInvoices.Update(ci);
            _context.CustomerInvoiceCosts.Remove(data);
            _context.SaveChanges();
            return CustomerInvoiceCostMapper.MapGet(data);

        }
    }
}
