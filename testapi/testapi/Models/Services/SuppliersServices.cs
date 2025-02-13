using API.Models.DTO;
using API.Models.Entities;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierService
    {
        ICollection<SupplierDTOGet> GetAllSuppliers();
        SupplierDTOGet GetSupplierById(int id);
        SupplierDTOGet CreateSupplier(Supplier supplier);
        SupplierDTOGet UpdateSupplier(int id, Supplier supplier);
        SupplierDTOGet DeleteSupplier(int id);


    }
    public class SupplierService : ISupplierService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISupplierInvoiceService _supplierInvoiceService;
        public SupplierService(Progetto_FormativoContext ctx, ISupplierInvoiceService supplierInvoiceService)
        {
            _context = ctx;
            _supplierInvoiceService = supplierInvoiceService;
        }

        public ICollection<SupplierDTOGet> GetAllSuppliers()
        {
            return _context.Suppliers.Select(x => SupplierMapper.MapGet(x)).ToList();
        }

        public SupplierDTOGet GetSupplierById(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentException("Supplier not found!");
            }
            return SupplierMapper.MapGet(data);
        }

        public SupplierDTOGet CreateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("Couldn't create supplier");
            if (string.IsNullOrEmpty(supplier.Country))
                throw new ArgumentNullException("Country can't be null");
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new ArgumentNullException("Supplier name can't be null");

            if (supplier.SupplierName.Length > 100)
                throw new ArgumentException("Supplier name is too long");

            if (supplier.Country.Length > 50)
                throw new ArgumentException("Country is too long");

            if (!supplier.Country.All(char.IsLetter))
                throw new ArgumentException("Country can't have special characters");

            if (_context.Suppliers.Any(x => x.SupplierName.Equals(supplier.SupplierName) && x.Country.Equals(supplier.Country)))
                throw new ArgumentException("This supplier already exists");

            _context.Add(supplier);
            _context.SaveChanges();
            return SupplierMapper.MapGet(supplier);
        }

        public SupplierDTOGet UpdateSupplier(int id, Supplier supplier)
        {
            var cDB = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (cDB != null)
            {
                if (supplier.SupplierName != null && supplier.Country != null)
                {
                    if (_context.Suppliers.Any(x => x.SupplierName.Equals(supplier.SupplierName) && x.Country.Equals(supplier.Country)))
                        throw new ArgumentException("This supplier already exists");
                }
                else if (supplier.SupplierName != null)
                {
                    if (_context.Suppliers.Any(x => x.SupplierName.Equals(supplier.SupplierName) && x.Country.Equals(cDB.Country)))
                        throw new ArgumentException("This supplier already exists");
                }
                else if (supplier.Country != null)
                {
                    if (_context.Suppliers.Any(x => x.SupplierName.Equals(cDB.SupplierName) && x.Country.Equals(supplier.Country)))
                        throw new ArgumentException("This supplier already exists");
                }

                if (!string.IsNullOrEmpty(supplier.SupplierName))
                    cDB.SupplierName = supplier.SupplierName ?? cDB.SupplierName;
                if (!string.IsNullOrEmpty(supplier.Country))
                    cDB.Country = supplier.Country ?? cDB.Country;

                if (supplier.SupplierName != null)
                    if (supplier.SupplierName.Length > 100)
                        throw new ArgumentException("Supplier name is too long");

                if (supplier.Country != null)
                {
                    if (supplier.Country.Length > 50)
                        throw new ArgumentException("Country is too long");

                    if (!supplier.Country.All(char.IsLetter))
                        throw new ArgumentException("Country can't have special characters");
                }

                _context.Suppliers.Update(cDB);
                _context.SaveChanges();
                return SupplierMapper.MapGet(cDB);
            }
            throw new ArgumentNullException("Supplier not found");
        }

        public SupplierDTOGet DeleteSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (data == null)
                throw new ArgumentNullException("Supplier not found!");
            List<SupplierInvoice> si = _context.SupplierInvoices.Where(x => x.SupplierId == id).ToList();
            if (si.Any())
            {
                foreach (SupplierInvoice item in si)
                    _supplierInvoiceService.DeleteSupplierInvoice(item.InvoiceId);
            }
            _context.Suppliers.Remove(data);
            _context.SaveChanges();
            return SupplierMapper.MapGet(data);

        }



    }
}
