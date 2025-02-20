using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISupplierService
    {
        ICollection<SupplierDTOGet> GetAllSuppliers(SupplierFilter? filter);
        SupplierDTOGet GetSupplierById(int id);
        SupplierDTOGet CreateSupplier(Supplier supplier);
        SupplierDTOGet UpdateSupplier(int id, Supplier supplier);
        SupplierDTOGet DeleteSupplier(int id);

        int CountSuppliers(SupplierFilter filter);


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

        public ICollection<SupplierDTOGet> GetAllSuppliers(SupplierFilter? filter)
        {
            return ApplyFilter(filter).ToList();
        }

        public int CountSuppliers(SupplierFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        private IQueryable<SupplierDTOGet> ApplyFilter(SupplierFilter? filter)
        {
            int itemsPage = 100;
            var query = _context.Suppliers.AsQueryable();

            if (filter.OriginalID != null)
            {
                query = query.Where(x => x.OriginalID == filter.OriginalID);
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.SupplierName.Contains(filter.Name));
            }
            if (filter.CreatedDateFrom.HasValue)
            {
                if ((filter.CreatedDateFrom <= DateTime.Now && filter.CreatedDateFrom > new DateTime(1975, 1, 1)))
                {
                    query = query.Where(x => x.CreatedAt >= filter.CreatedDateFrom);
                }
            }
            if (filter.CreatedDateTo.HasValue)
            {
                if (filter.CreatedDateTo <= DateTime.Now && filter.CreatedDateTo >= filter.CreatedDateTo)
                    query = query.Where(x => x.CreatedAt <= filter.CreatedDateTo);
            }



            if (!string.IsNullOrEmpty(filter.Country))
            {
                query = query.Where(x => x.Country.Contains(filter.Country));
            }

            if (filter.Deprecated != null)
            {
                query = query.Where(x => x.Deprecated == filter.Deprecated);
            }
            if (filter.page != null)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => SupplierMapper.MapGet(x));
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

            if (supplier.Deprecated != null)
                if ((bool)supplier.Deprecated)
                    throw new ArgumentException("Can't create an already deprecated supplier");
                else
                    supplier.Deprecated = false;

            if (supplier.SupplierName.Length > 100)
                throw new ArgumentException("Supplier name is too long");

            if (supplier.Country.Length > 50)
                throw new ArgumentException("Country is too long");

            if (!supplier.Country.All(char.IsLetter))
                throw new ArgumentException("Country can't have special characters");

            try
            {
                _context.Add(supplier);
                _context.SaveChanges();
                supplier.OriginalID = supplier.SupplierId;
                _context.Update(supplier);
                _context.SaveChanges();
                return SupplierMapper.MapGet(supplier);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("This supplier already exists");
            }
        }

        public SupplierDTOGet UpdateSupplier(int id, Supplier supplier)
        {
            var cDB = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (cDB != null)
            {
                if ((bool)cDB.Deprecated)
                    throw new ArgumentException("Can't update deprecated supplier");

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

                Supplier newSupplier = new Supplier
                {
                    SupplierName = supplier.SupplierName ?? cDB.SupplierName,
                    Country = supplier.Country ?? cDB.Country,
                    Deprecated = false,
                    OriginalID = cDB.OriginalID,
                    CreatedAt = DateTime.Now,
                };

                cDB.Deprecated = true;

                try
                {
                    _context.Suppliers.Update(cDB);
                    _context.SaveChanges();

                    _context.Suppliers.Add(newSupplier);
                    _context.SaveChanges();
                    return SupplierMapper.MapGet(newSupplier);
                }
                catch (Exception)
                {
                    throw new ArgumentException("This supplier already exists");
                }
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
