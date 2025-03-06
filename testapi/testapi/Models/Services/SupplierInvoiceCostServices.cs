using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISupplierInvoiceCostService
    {
        Task<ICollection<SupplierInvoiceCostDTOGet>> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);
        Task<SupplierInvoiceCostDTOGet> GetSupplierInvoiceCostById(int id);
        Task<SupplierInvoiceCostDTOGet> CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost);
        Task<SupplierInvoiceCostDTOGet> UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost);
        Task<SupplierInvoiceCostDTOGet> DeleteSupplierInvoiceCost(int id);

        Task<int> CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);



    }
    public class SupplierInvoiceCostServices : ISupplierInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        public SupplierInvoiceCostServices(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<ICollection<SupplierInvoiceCostDTOGet>> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SupplierInvoiceCostDTOGet> ApplyFilter(SupplierInvoiceCostFilter filter)
        {
            int itemsPage = 10;
            var query = _context.SupplierInvoiceCosts.AsQueryable();

            if (filter.SupplierInvoiceCostSupplierInvoiceId != null)
            {
                query = query.Where(x => x.SupplierInvoiceId == filter.SupplierInvoiceCostSupplierInvoiceId);
            }
            if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostName))
            {
                query = query.Where(x => x.Name.Contains(filter.SupplierInvoiceCostName));
            }

            if (filter.SupplierInvoiceCostCostFrom != null && filter.SupplierInvoiceCostCostTo != null)
            {
                if (filter.SupplierInvoiceCostCostFrom > filter.SupplierInvoiceCostCostTo)
                {
                    throw new ArgumentException("CostFrom cannot be more than CostTo.");
                }

                query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom && s.Cost <= filter.SupplierInvoiceCostCostTo);
            }
            else if (filter.SupplierInvoiceCostCostFrom != null)
            {
                query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom);
            }
            else if (filter.SupplierInvoiceCostCostTo != null)
            {
                query = query.Where(s => s.Cost <= filter.SupplierInvoiceCostCostTo);
            }

            if (filter.SupplierInvoiceCostQuantity != null)
            {
                query = query.Where(x => x.Quantity == filter.SupplierInvoiceCostQuantity);
            }
            if (filter.SupplierInvoiceCostPage != null)
            {
                query = query.Skip(((int)filter.SupplierInvoiceCostPage - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => SupplierInvoiceCostMapper.MapGet(x));
        }

        public async Task<SupplierInvoiceCostDTOGet> GetSupplierInvoiceCostById(int id)
        {
            var data = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new ArgumentException("Supplier Invoice Cost not found!");
            }
            return SupplierInvoiceCostMapper.MapGet(data);
        }

        public async Task<SupplierInvoiceCostDTOGet> CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice si;
            if (supplierInvoiceCost == null)
                throw new ArgumentNullException("Couldn't create supplier Invoice Cost");
            if (supplierInvoiceCost.SupplierInvoiceId == null)
                throw new ArgumentException("Supplier Invoice Id can't be null!");
            if (!_context.SupplierInvoices.Where(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).Any())
                throw new ArgumentException("Supplier Invoice Id not found!");
            if (supplierInvoiceCost.Cost < 0 || supplierInvoiceCost.Quantity < 1 || supplierInvoiceCost.Cost == null || supplierInvoiceCost.Quantity == null)
                throw new ArgumentException("Values can't be lesser than 1 or null");
            if (string.IsNullOrEmpty(supplierInvoiceCost.Name))
                throw new ArgumentException("Name can't be empty");
            si = await _context.SupplierInvoices.Where(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).FirstAsync();
            if (si.Status.ToLower().Equals("approved"))
                throw new ArgumentException("Supplier Invoice is already approved");


            decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == supplierInvoiceCost.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);

            si.InvoiceAmount = total + supplierInvoiceCost.Cost * supplierInvoiceCost.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.Add(supplierInvoiceCost);
            await _context.SaveChangesAsync();
            return SupplierInvoiceCostMapper.MapGet(supplierInvoiceCost);
        }

        public async Task<SupplierInvoiceCostDTOGet> UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice? si;
            var sicDB = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            SupplierInvoice? oldSi = await _context.SupplierInvoices.Where(x => x.InvoiceId == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();
            oldSi.InvoiceAmount = oldSi.InvoiceAmount - (sicDB.Cost * sicDB.Quantity);
            if (sicDB != null && id >= 0)
            {
                if (supplierInvoiceCost.SupplierInvoiceId != null)
                    sicDB.SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId;
                if ((await _context.SupplierInvoices.Where(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).FirstOrDefaultAsync()).Status.ToLower().Equals("approved"))
                    throw new ArgumentException("Supplier Invoice is already approved");
                if (!_context.SupplierInvoices.Any(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId))
                    throw new ArgumentNullException("Supplier Invoice not Found");
                if (supplierInvoiceCost.Quantity > 0)
                    sicDB.Quantity = supplierInvoiceCost.Quantity ?? sicDB.Quantity;
                if (supplierInvoiceCost.Cost > 0)
                    sicDB.Cost = supplierInvoiceCost.Cost ?? sicDB.Cost;
                sicDB.Name = supplierInvoiceCost.Name ?? sicDB.Name;
                _context.SupplierInvoiceCosts.Update(sicDB);
                await _context.SaveChangesAsync();
                if (sicDB.Cost > 0 && sicDB.Quantity > 0)
                {
                    si = await _context.SupplierInvoices.Where(x => x.InvoiceId == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();
                    decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == sicDB.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
                    si.InvoiceAmount = total;
                    _context.SupplierInvoices.Update(si);
                    _context.SupplierInvoices.Update(oldSi);
                    await _context.SaveChangesAsync();
                }
                return SupplierInvoiceCostMapper.MapGet(sicDB);
            }
            throw new ArgumentNullException("Supplier Invoice Cost not found");
        }

        public async Task<SupplierInvoiceCostDTOGet> DeleteSupplierInvoiceCost(int id)
        {
            var data = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            if (data == null || id < 1)
            {
                throw new ArgumentNullException("Supplier Invoice Cost not found!");
            }
            SupplierInvoice si = await _context.SupplierInvoices.Where(x => x.InvoiceId == data.SupplierInvoiceId).FirstAsync();
            decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == data.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
            si.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.SupplierInvoiceCosts.Remove(data);
            await _context.SaveChangesAsync();
            return SupplierInvoiceCostMapper.MapGet(data);

        }
    }
}
