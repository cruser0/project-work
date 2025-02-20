using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierInvoiceService
    {
        ICollection<SupplierInvoiceDTOGet> GetAllSupplierInvoices(SupplierInvoiceFilter? filter);
        SupplierInvoiceDTOGet GetSupplierInvoiceById(int id);
        SupplierInvoiceDTOGet CreateSupplierInvoice(SupplierInvoice supplierInvoice);
        SupplierInvoiceDTOGet UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice);
        SupplierInvoiceDTOGet DeleteSupplierInvoice(int id);
        int CountSupplierinvoices(SupplierInvoiceFilter filter);


    }
    public class SupplierInvoiceService : ISupplierInvoiceService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISupplierInvoiceCostService _serviceCost;
        public SupplierInvoiceService(Progetto_FormativoContext ctx, ISupplierInvoiceCostService serviceCost)
        {
            _context = ctx;
            _serviceCost = serviceCost;
        }

        public ICollection<SupplierInvoiceDTOGet> GetAllSupplierInvoices(SupplierInvoiceFilter? filter)
        {
            // Retrieve all customers from the database and map them to DTOs
            return ApplyFilter(filter).ToList();
        }

        public int CountSupplierinvoices(SupplierInvoiceFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        private IQueryable<SupplierInvoiceDTOGet> ApplyFilter(SupplierInvoiceFilter? filter)
        {
            int itemsPage = 10;
            var query = _context.SupplierInvoices.AsQueryable();

            if (filter.InvoiceDateFrom.HasValue)
            {
                if ((filter.InvoiceDateFrom <= DateTime.Now && filter.InvoiceDateFrom > new DateTime(1975, 1, 1)))
                {
                    query = query.Where(x => x.InvoiceDate >= filter.InvoiceDateFrom);
                }
            }
            if (filter.InvoiceDateTo.HasValue)
            {
                if (filter.InvoiceDateTo <= DateTime.Now && filter.InvoiceDateTo >= filter.InvoiceDateFrom)
                    query = query.Where(x => x.InvoiceDate <= filter.InvoiceDateTo);
            }

            if (filter.InvoiceAmountFrom != null && filter.InvoiceAmountTo != null)
            {
                query = query.Where(s => s.InvoiceAmount >= filter.InvoiceAmountFrom && s.InvoiceAmount <= filter.InvoiceAmountTo);
            }
            else if (filter.InvoiceAmountFrom != null)
            {
                query = query.Where(s => s.InvoiceAmount >= filter.InvoiceAmountFrom);
            }
            else if (filter.InvoiceAmountTo != null)
            {
                query = query.Where(s => s.InvoiceAmount <= filter.InvoiceAmountTo);
            }

            if (filter.SaleID != null)
            {
                query = query.Where(x => x.SaleId == filter.SaleID);
            }
            if (filter.SupplierID != null)
            {
                query = query.Where(x => x.SupplierId == filter.SupplierID);
            }
            if (!string.IsNullOrEmpty(filter.Status))
            {
                if (!filter.Status.Equals("All"))
                    query = query.Where(x => x.Status == filter.Status.ToLower());
            }
            if (filter.page != null)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => SupplierInvoiceMapper.MapGet(x));
        }

        public SupplierInvoiceDTOGet GetSupplierInvoiceById(int id)
        {
            var data = _context.SupplierInvoices.Where(x => x.InvoiceId == id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentException("Supplier Invoice not found!");
            }
            return SupplierInvoiceMapper.MapGet(data);
        }

        public SupplierInvoiceDTOGet CreateSupplierInvoice(SupplierInvoice supplierInvoice)
        {
            if (supplierInvoice == null)
                throw new ArgumentException("Couldn't create supplier Invoice");

            var supplier = _context.Suppliers.Where(x => x.SupplierId == supplierInvoice.SupplierId).FirstOrDefault();
            if (supplier == null)
                throw new ArgumentException("SupplierID not found");
            else if ((bool)supplier.Deprecated)
                throw new ArgumentException($"The supplier {supplierInvoice.SupplierId} is deprecated");


            if (!_context.Sales.Any(x => x.SaleId == supplierInvoice.SaleId))
                throw new ArgumentException("SaleID not found");

            if (!new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status?.ToLower()))
                throw new ArgumentException("Status is not valid");
            if (supplierInvoice.InvoiceDate == null || supplierInvoice.InvoiceDate > DateTime.Now)
                throw new ArgumentException("Date is not valid");

            supplierInvoice.InvoiceAmount = 0;
            _context.Add(supplierInvoice);
            _context.SaveChanges();
            return SupplierInvoiceMapper.MapGet(supplierInvoice);
        }

        public SupplierInvoiceDTOGet UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice)
        {
            var siDB = _context.SupplierInvoices.FirstOrDefault(x => x.InvoiceId == id);

            if (siDB == null)
            {
                throw new ArgumentException("Supplier Invoice not found");
            }

            if (supplierInvoice.SaleId != null)
            {
                if (!_context.Sales.Any(x => x.SaleId == supplierInvoice.SaleId))
                {
                    throw new ArgumentException("SaleID not present");
                }
                siDB.SaleId = supplierInvoice.SaleId;
            }

            if (supplierInvoice.SupplierId != null)
            {
                var supplier = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplierInvoice.SupplierId);
                if (supplier == null)
                {
                    throw new ArgumentException("SupplierID not present");
                }

                if ((bool)supplier.Deprecated)
                {
                    throw new ArgumentException($"The supplier {supplierInvoice.SupplierId} is deprecated");
                }

                siDB.SupplierId = supplierInvoice.SupplierId;
            }

            if (supplierInvoice.InvoiceDate > DateTime.Now)
            {
                throw new ArgumentException("Date cannot be greater than today");
            }

            siDB.InvoiceAmount = supplierInvoice.InvoiceAmount ?? siDB.InvoiceAmount;
            siDB.InvoiceDate = supplierInvoice.InvoiceDate ?? siDB.InvoiceDate;


            if (supplierInvoice.Status != null)
            {
                if (new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status.ToLower()))
                {
                    siDB.Status = supplierInvoice.Status ?? siDB.Status;
                }
                else
                {
                    throw new ArgumentException("Status not correct");
                }
            }


            _context.SupplierInvoices.Update(siDB);
            _context.SaveChanges();

            return SupplierInvoiceMapper.MapGet(siDB);
        }

        public SupplierInvoiceDTOGet DeleteSupplierInvoice(int id)
        {
            var data = _context.SupplierInvoices.Where(x => x.InvoiceId == id).FirstOrDefault();
            if (data == null || id < 1)
            {
                throw new ArgumentNullException("Supplier Invoice not found!");
            }
            List<SupplierInvoiceCost> listInvoiceCost = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == id).ToList();
            if (listInvoiceCost.Count > 0)
            {
                foreach (SupplierInvoiceCost cost in listInvoiceCost)
                {
                    _serviceCost.DeleteSupplierInvoiceCost(cost.SupplierInvoiceCostsId);
                }
            }
            _context.SupplierInvoices.Remove(data);
            _context.SaveChanges();
            return SupplierInvoiceMapper.MapGet(data);

        }

    }
}
