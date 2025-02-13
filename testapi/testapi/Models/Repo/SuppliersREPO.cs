using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;

namespace testapi.Repo
{
    public interface ISupplierREPO
    {
        ICollection<SupplierDTOGet> GetAllSuppliers();
        SupplierDTOGet GetSupplierById(int id);
        SupplierDTOGet CreateSupplier(Supplier supplier);
        SupplierDTOGet UpdateSupplier(int id, Supplier supplier);
        SupplierDTOGet DeleteSupplier(int id);


    }
    public class SupplierREPO : ISupplierREPO
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISupplierInvoiceREPO _supplierInvoiceREPO;
        public SupplierREPO(Progetto_FormativoContext ctx, ISupplierInvoiceREPO supplierInvoiceREPO)
        {
            _context = ctx;
            _supplierInvoiceREPO = supplierInvoiceREPO;
        }

        public SupplierDTOGet CreateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("Couldn't create supplier");
            if (string.IsNullOrEmpty(supplier.Country))
                throw new ArgumentNullException("Country can't be null");
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new ArgumentNullException("Supplier name can't be null");
            //table doesn't have a strong enought unique attribute to make other checks

            _context.Add(supplier);
            _context.SaveChanges();
            return SupplierMapper.MapGet(supplier);
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
                    _supplierInvoiceREPO.DeleteSupplierInvoice(item.InvoiceId);
            }
            _context.Suppliers.Remove(data);
            _context.SaveChanges();
            return SupplierMapper.MapGet(data);

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

        public SupplierDTOGet UpdateSupplier(int id, Supplier supplier)
        {
            var cDB = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (cDB != null)
            {
                if (!string.IsNullOrEmpty(supplier.SupplierName))
                    cDB.SupplierName = supplier.SupplierName ?? cDB.SupplierName;
                if (!string.IsNullOrEmpty(supplier.Country))
                    cDB.Country = supplier.Country ?? cDB.Country;
                _context.Suppliers.Update(cDB);
                _context.SaveChanges();
                return SupplierMapper.MapGet(cDB);
            }
            throw new ArgumentNullException("Supplier not found");
        }
    }
}
