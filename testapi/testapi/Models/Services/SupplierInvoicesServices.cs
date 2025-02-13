using API.Models.DTO;
using API.Models.Entities;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierInvoiceService
    {
        ICollection<SupplierInvoiceDTOGet> GetAllSupplierInvoices();
        SupplierInvoiceDTOGet GetSupplierInvoiceById(int id);
        SupplierInvoiceDTOGet CreateSupplierInvoice(SupplierInvoice supplierInvoice);
        SupplierInvoiceDTOGet UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice);
        SupplierInvoiceDTOGet DeleteSupplierInvoice(int id);


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

        public SupplierInvoiceDTOGet CreateSupplierInvoice(SupplierInvoice supplierInvoice)
        {
            if (supplierInvoice == null)
                throw new ArgumentException("Couldn't create supplier Invoice");

            if (!_context.Suppliers.Any(x => x.SupplierId == supplierInvoice.SupplierId))
                throw new ArgumentException("SupplierID not found");
            if (!_context.Sales.Any(x => x.SaleId == supplierInvoice.SaleId))
                throw new ArgumentException("SaleID not found");

            if (!new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status?.ToLower()))
                throw new ArgumentException("Status is not valid");
            if (supplierInvoice.InvoiceDate == null)
                throw new ArgumentException("Date is not valid");

            supplierInvoice.InvoiceAmount = 0;
            _context.Add(supplierInvoice);
            _context.SaveChanges();
            return SupplierInvoiceMapper.MapGet(supplierInvoice);
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

        public ICollection<SupplierInvoiceDTOGet> GetAllSupplierInvoices()
        {
            return _context.SupplierInvoices.Select(si => SupplierInvoiceMapper.MapGet(si)).ToList();
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

        public SupplierInvoiceDTOGet UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice)
        {
            var siDB = _context.SupplierInvoices.Where(x => x.InvoiceId == id).FirstOrDefault();
            if (siDB != null)
            {
                if (supplierInvoice.SaleId != null && supplierInvoice.SaleId >= 1)
                {
                    if (_context.Sales.Any(x => x.SaleId == supplierInvoice.SaleId))
                        siDB.SaleId = supplierInvoice.SaleId;
                    else
                        throw new ArgumentException("SaleID not present");
                }
                if (supplierInvoice.SupplierId != null && supplierInvoice.SupplierId >= 1)
                {
                    if (_context.Suppliers.Any(x => x.SupplierId == supplierInvoice.SupplierId))
                        siDB.SupplierId = supplierInvoice.SupplierId;
                    else
                        throw new ArgumentException("SupplierID not present");
                }
                siDB.InvoiceAmount = supplierInvoice.InvoiceAmount ?? siDB.InvoiceAmount;
                siDB.InvoiceDate = supplierInvoice.InvoiceDate ?? siDB.InvoiceDate;
                if (new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status?.ToLower()))
                {
                    siDB.Status = supplierInvoice.Status ?? siDB.Status;
                }
                else
                    throw new ArgumentException("Status not correct");

                _context.SupplierInvoices.Update(siDB);
                _context.SaveChanges();
                return SupplierInvoiceMapper.MapGet(siDB);
            }
            throw new ArgumentException("Supplier Invoice not found");
        }
    }
}
