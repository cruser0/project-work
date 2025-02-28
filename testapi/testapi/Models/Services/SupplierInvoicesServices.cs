using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierInvoiceService
    {
        ICollection<SupplierInvoiceSupplierDTO> GetAllSupplierInvoices(SupplierInvoiceFilter? filter);
        SupplierInvoiceSupplierDTO GetSupplierInvoiceById(int id);
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

        public ICollection<SupplierInvoiceSupplierDTO> GetAllSupplierInvoices(SupplierInvoiceFilter? filter)
        {
            // Retrieve all customers from the database and map them to DTOs
            return ApplyFilter(filter).ToList();
        }

        public int CountSupplierinvoices(SupplierInvoiceFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        private IQueryable<SupplierInvoiceSupplierDTO> ApplyFilter(SupplierInvoiceFilter? filter)
        {
            int itemsPage = 10;
            var query = (from si in _context.SupplierInvoices
                         join s in _context.Suppliers on si.SupplierId equals s.SupplierId into SupplierInvoiceGroup
                         from supplier in SupplierInvoiceGroup.DefaultIfEmpty()
                         select new { SupplierInvoice = si, Supplier = supplier }).AsQueryable();

            if (filter.SupplierInvoiceInvoiceDateFrom.HasValue)
            {
                if ((filter.SupplierInvoiceInvoiceDateFrom <= DateTime.Now && filter.SupplierInvoiceInvoiceDateFrom > new DateTime(1975, 1, 1)))
                {
                    query = query.Where(x => x.SupplierInvoice.InvoiceDate >= filter.SupplierInvoiceInvoiceDateFrom);
                }
            }
            if (filter.SupplierInvoiceInvoiceDateTo.HasValue)
            {
                if (filter.SupplierInvoiceInvoiceDateTo <= DateTime.Now && filter.SupplierInvoiceInvoiceDateTo >= filter.SupplierInvoiceInvoiceDateFrom)
                    query = query.Where(x => x.SupplierInvoice.InvoiceDate <= filter.SupplierInvoiceInvoiceDateTo);
            }

            if (filter.SupplierInvoiceInvoiceAmountFrom != null && filter.SupplierInvoiceInvoiceAmountTo != null)
            {
                query = query.Where(s => s.SupplierInvoice.InvoiceAmount >= filter.SupplierInvoiceInvoiceAmountFrom && s.SupplierInvoice.InvoiceAmount <= filter.SupplierInvoiceInvoiceAmountTo);
            }
            else if (filter.SupplierInvoiceInvoiceAmountFrom != null)
            {
                query = query.Where(s => s.SupplierInvoice.InvoiceAmount >= filter.SupplierInvoiceInvoiceAmountFrom);
            }
            else if (filter.SupplierInvoiceInvoiceAmountTo != null)
            {
                query = query.Where(s => s.SupplierInvoice.InvoiceAmount <= filter.SupplierInvoiceInvoiceAmountTo);
            }

            if (filter.SupplierInvoiceSaleID != null)
            {
                query = query.Where(x => x.SupplierInvoice.SaleId == filter.SupplierInvoiceSaleID);
            }
            if (filter.SupplierInvoiceSupplierID != null)
            {
                query = query.Where(x => x.SupplierInvoice.SupplierId == filter.SupplierInvoiceSupplierID);
            }
            if (!string.IsNullOrEmpty(filter.SupplierInvoiceStatus))
            {
                if (!filter.SupplierInvoiceStatus.Equals("All"))
                    query = query.Where(x => x.SupplierInvoice.Status == filter.SupplierInvoiceStatus.ToLower());
            }
            if (filter.SupplierInvoicePage != null)
            {
                query = query.Skip(((int)filter.SupplierInvoicePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => new SupplierInvoiceSupplierDTO(x.SupplierInvoice, x.Supplier));
        }

        public SupplierInvoiceSupplierDTO GetSupplierInvoiceById(int id)
        {
            var si = _context.SupplierInvoices.Where(x => x.InvoiceId == id).FirstOrDefault();
            var supplier = _context.Suppliers.Where(x => x.SupplierId == si.SupplierId).FirstOrDefault();
            var result = new SupplierInvoiceSupplierDTO(si, supplier);
            if (si == null || supplier == null)
            {
                throw new ArgumentException("Supplier Invoice not found!");
            }
            return result;
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
