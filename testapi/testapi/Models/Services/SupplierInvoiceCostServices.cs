using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierInvoiceCostService
    {
        ICollection<SupplierInvoiceCostDTOGet> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);
        SupplierInvoiceCostDTOGet GetSupplierInvoiceCostById(int id);
        SupplierInvoiceCostDTOGet CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost);
        SupplierInvoiceCostDTOGet UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost);
        SupplierInvoiceCostDTOGet DeleteSupplierInvoiceCost(int id);

        int CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);



    }
    public class SupplierInvoiceCostServices : ISupplierInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        public SupplierInvoiceCostServices(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public ICollection<SupplierInvoiceCostDTOGet> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return ApplyFilter(filter).ToList();
        }

        public int CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        public IQueryable<SupplierInvoiceCostDTOGet> ApplyFilter(SupplierInvoiceCostFilter filter)
        {
            int itemsPage = 100;
            var query = _context.SupplierInvoiceCosts.AsQueryable();

            if (filter.SupplierInvoiceId != null)
            {
                query = query.Where(x => x.SupplierInvoiceId == filter.SupplierInvoiceId);
            }

            if (filter.Cost != null)
            {
                query = query.Where(x => x.Cost == filter.Cost);
            }

            if (filter.Quantity != null)
            {
                query = query.Where(x => x.Quantity == filter.Quantity);
            }
            if (filter.page != null)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => SupplierInvoiceCostMapper.MapGet(x));
        }

        public SupplierInvoiceCostDTOGet GetSupplierInvoiceCostById(int id)
        {
            var data = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentException("Supplier Invoice Cost not found!");
            }
            return SupplierInvoiceCostMapper.MapGet(data);
        }

        public SupplierInvoiceCostDTOGet CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost)
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

            si = _context.SupplierInvoices.Where(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).First();

            decimal? total = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == supplierInvoiceCost.SupplierInvoiceId).Sum(x => x.Cost * x.Quantity);

            si.InvoiceAmount = total + supplierInvoiceCost.Cost * supplierInvoiceCost.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.Add(supplierInvoiceCost);
            _context.SaveChanges();
            return SupplierInvoiceCostMapper.MapGet(supplierInvoiceCost);
        }

        public SupplierInvoiceCostDTOGet UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice? si;
            var sicDB = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (sicDB != null && id >= 0)
            {
                if (supplierInvoiceCost.SupplierInvoiceId != null)
                    sicDB.SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId;
                if (!_context.SupplierInvoices.Any(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId))
                    throw new ArgumentNullException("Supplier Invoice not Found");
                if (supplierInvoiceCost.Quantity > 0)
                    sicDB.Quantity = supplierInvoiceCost.Quantity ?? sicDB.Quantity;
                if (supplierInvoiceCost.Cost > 0)
                    sicDB.Cost = supplierInvoiceCost.Cost ?? sicDB.Cost;
                _context.SupplierInvoiceCosts.Update(sicDB);
                _context.SaveChanges();
                if (sicDB.Cost > 0 && sicDB.Quantity > 0)
                {
                    si = _context.SupplierInvoices.Where(x => x.InvoiceId == sicDB.SupplierInvoiceId).FirstOrDefault();
                    decimal? total = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == sicDB.SupplierInvoiceId).Sum(x => x.Cost * x.Quantity);
                    si.InvoiceAmount = total;
                    _context.SupplierInvoices.Update(si);
                    _context.SaveChanges();
                }
                return SupplierInvoiceCostMapper.MapGet(sicDB);
            }
            throw new ArgumentNullException("Supplier Invoice Cost not found");
        }

        public SupplierInvoiceCostDTOGet DeleteSupplierInvoiceCost(int id)
        {
            var data = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (data == null || id < 1)
            {
                throw new ArgumentNullException("Supplier Invoice Cost not found!");
            }
            SupplierInvoice si = _context.SupplierInvoices.Where(x => x.InvoiceId == data.SupplierInvoiceId).First();
            decimal? total = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == data.SupplierInvoiceId).Sum(x => x.Cost * x.Quantity);
            si.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.SupplierInvoiceCosts.Remove(data);
            _context.SaveChanges();
            return SupplierInvoiceCostMapper.MapGet(data);

        }
    }
}
