using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISupplierService
    {
        Task<ICollection<SupplierDTOGet>> GetAllSuppliers(SupplierFilter? filter);
        Task<SupplierDTOGet> GetSupplierById(int id);
        Task<SupplierDTOGet> CreateSupplier(Supplier supplier);
        Task<SupplierDTOGet> UpdateSupplier(int id, Supplier supplier);
        Task<SupplierDTOGet> DeleteSupplier(int id);

        Task<int> CountSuppliers(SupplierFilter filter);


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

        public async Task<ICollection<SupplierDTOGet>> GetAllSuppliers(SupplierFilter? filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSuppliers(SupplierFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SupplierDTOGet> ApplyFilter(SupplierFilter? filter)
        {
            int itemsPage = 10;
            var query = _context.Suppliers.AsQueryable();

            if (filter.SupplierOriginalID != null)
            {
                query = query.Where(x => x.OriginalID == filter.SupplierOriginalID);
            }
            if (!string.IsNullOrEmpty(filter.SupplierName))
            {
                query = query.Where(x => x.SupplierName.Contains(filter.SupplierName));
            }
            if (filter.SupplierCreatedDateFrom.HasValue)
            {
                if ((filter.SupplierCreatedDateFrom <= DateTime.Now && filter.SupplierCreatedDateFrom > new DateTime(1975, 1, 1)))
                {
                    query = query.Where(x => x.CreatedAt >= filter.SupplierCreatedDateFrom);
                }
            }
            if (filter.SupplierCreatedDateTo.HasValue)
            {
                if (filter.SupplierCreatedDateTo <= DateTime.Now && filter.SupplierCreatedDateTo >= filter.SupplierCreatedDateTo)
                    query = query.Where(x => x.CreatedAt <= filter.SupplierCreatedDateTo);
            }



            if (!string.IsNullOrEmpty(filter.SupplierCountry))
            {
                query = query.Where(x => x.Country.Contains(filter.SupplierCountry));
            }

            if (filter.SupplierDeprecated != null)
            {
                query = query.Where(x => x.Deprecated == filter.SupplierDeprecated);
            }
            if (filter.SupplierPage != null)
            {
                query = query.Skip(((int)filter.SupplierPage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => SupplierMapper.MapGet(x));
        }

        public async Task<SupplierDTOGet> GetSupplierById(int id)
        {
            var data = await _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new ArgumentException("Supplier not found!");
            }
            return SupplierMapper.MapGet(data);
        }

        public async Task<SupplierDTOGet> CreateSupplier(Supplier supplier)
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
            else
                supplier.Deprecated = false;

            supplier.CreatedAt = DateTime.Now;

            if (supplier.SupplierName.Length > 100)
                throw new ArgumentException("Supplier name is too long");

            if (supplier.Country.Length > 50)
                throw new ArgumentException("Country is too long");

            if (!supplier.Country.All(char.IsLetter))
                throw new ArgumentException("Country can't have special characters");

            try
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                supplier.OriginalID = supplier.SupplierId;
                _context.Update(supplier);
                await _context.SaveChangesAsync();
                return SupplierMapper.MapGet(supplier);
            }
            catch (Exception)
            {
                throw new ArgumentException("This supplier already exists");
            }
        }

        public async Task<SupplierDTOGet> UpdateSupplier(int id, Supplier supplier)
        {
            var cDB = await _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefaultAsync();
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
                    await _context.SaveChangesAsync();

                    _context.Suppliers.Add(newSupplier);
                    await _context.SaveChangesAsync();
                    return SupplierMapper.MapGet(newSupplier);
                }
                catch (Exception)
                {
                    throw new ArgumentException("This supplier already exists");
                }
            }
            throw new ArgumentNullException("Supplier not found");
        }

        public async Task<SupplierDTOGet> DeleteSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            if (data == null)
                throw new ArgumentNullException("Supplier not found!");
            List<SupplierInvoice> si = await _context.SupplierInvoices.Where(x => x.SupplierId == id).ToListAsync();
            if (si.Any())
            {
                foreach (SupplierInvoice item in si)
                    await _supplierInvoiceService.DeleteSupplierInvoice(item.InvoiceId);
            }
            _context.Suppliers.Remove(data);
            await _context.SaveChangesAsync();
            return SupplierMapper.MapGet(data);

        }



    }
}
