using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISupplierService
    {
        Task<ICollection<SupplierDTOGet>> GetAllSuppliers(SupplierFilter filter);
        Task<SupplierDTOGet> GetSupplierById(int id);
        Task<SupplierDTOGet> CreateSupplier(Supplier supplier);
        Task<SupplierDTOGet> UpdateSupplier(int id, Supplier supplier);
        Task<SupplierDTOGet> DeleteSupplier(int id);

        Task<int> CountSuppliers(SupplierFilter filter);
        Task<string> MassDeleteSupplier(List<int> supplierId);
        Task<string> MassUpdateSupplier(List<SupplierDTOGet> newSuppliers);
        Task<List<string>> GetAllSuppliersNameCountry(string? filter);
    }
    public class SupplierService : ISupplierService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISupplierInvoiceService _supplierInvoiceService;
        private readonly CountryService _countryService;
        public SupplierService(Progetto_FormativoContext ctx, ISupplierInvoiceService supplierInvoiceService, CountryService countryService)
        {
            _context = ctx;
            _supplierInvoiceService = supplierInvoiceService;
            _countryService = countryService;
        }

        public async Task<ICollection<SupplierDTOGet>> GetAllSuppliers(SupplierFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSuppliers(SupplierFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SupplierDTOGet> ApplyFilter(SupplierFilter filter)
        {
            int itemsPage = 10;
            var query = _context.Suppliers.Include(x => x.Country).AsQueryable();

            if (filter.SupplierOriginalID != null)
            {
                query = query.Where(x => x.OriginalID == filter.SupplierOriginalID);
            }
            if (!string.IsNullOrEmpty(filter.SupplierName))
            {
                query = query.Where(x => x.SupplierName!.Contains(filter.SupplierName));
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
                query = query.Where(x => x.Country.CountryName.Contains(filter.SupplierCountry));
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
            var data = await _context.Suppliers.Include(x => x.Country).Where(x => x.SupplierID == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new ArgumentException("Supplier not found!");
            }
            return SupplierMapper.MapGet(data);
        }

        public async Task<SupplierDTOGet> CreateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new NullPropertyException("Couldn't create supplier,data is null");
            if (string.IsNullOrEmpty(supplier.Country.CountryName))
                throw new NullPropertyException("Country can't be null");
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new NullPropertyException("Supplier name can't be null");

            if (supplier.Deprecated != null)
                if ((bool)supplier.Deprecated)
                    throw new ErrorInputPropertyException("Can't create an already deprecated supplier");
                else
                    supplier.Deprecated = false;
            else
                supplier.Deprecated = false;

            supplier.CreatedAt = DateTime.Now;

            if (supplier.SupplierName.Length > 100)
                throw new ErrorInputPropertyException("Supplier name is too long");

            if (supplier.Country.CountryName.Length > 50)
                throw new ErrorInputPropertyException("Country is too long");


            _context.Add(supplier);
            await _context.SaveChangesAsync();
            supplier.OriginalID = supplier.SupplierID;
            _context.Update(supplier);
            await _context.SaveChangesAsync();
            return SupplierMapper.MapGet(supplier);
        }

        public async Task<SupplierDTOGet> UpdateSupplier(int id, Supplier supplier)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var cDB = await _context.Suppliers.Include(x => x.Country).Where(x => x.SupplierID == id).FirstOrDefaultAsync();
            try
            {
                if (cDB != null)
                {
                    if ((bool)cDB.Deprecated!)
                        throw new ErrorInputPropertyException("Can't update deprecated supplier");

                    if (supplier.SupplierName != null)
                        if (supplier.SupplierName.Length > 100)
                            throw new ErrorInputPropertyException("Supplier name is too long");

                    if (supplier.Country.CountryName != null)
                    {
                        if (supplier.Country.CountryName.Length > 50)
                            throw new ErrorInputPropertyException("Country is too long");

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
                    _context.Suppliers.Update(cDB);
                    await _context.SaveChangesAsync();

                    _context.Suppliers.Add(newSupplier);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return SupplierMapper.MapGet(newSupplier);
                }
                throw new NotFoundException("Supplier not found");
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<SupplierDTOGet> DeleteSupplier(int id)
        {
            var data = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            if (data == null)
                throw new NotFoundException("Supplier not found!");
            List<SupplierInvoice> si = await _context.SupplierInvoices.Where(x => x.SupplierID == id).ToListAsync();

            if (si.Any())
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    foreach (SupplierInvoice item in si)
                    {

                        await _supplierInvoiceService.DeleteSupplierInvoice(item.SupplierInvoiceID);
                    }
                }
                catch (ErrorInputPropertyException ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }


            }
            _context.Suppliers.Remove(data);
            await _context.SaveChangesAsync();
            return SupplierMapper.MapGet(data);

        }

        public async Task<string> MassDeleteSupplier(List<int> supplierId)
        {
            int count = 0;
            foreach (int id in supplierId)
            {
                var data = _context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
                if (data == null)
                    continue;
                List<SupplierInvoice> si = await _context.SupplierInvoices.Where(x => x.SupplierID == id).ToListAsync();
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (si.Any())
                    {


                        foreach (SupplierInvoice item in si)
                        {

                            await _supplierInvoiceService.DeleteSupplierInvoice(item.SupplierInvoiceID);
                        }

                    }
                    _context.Suppliers.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    continue;
                }
                transaction.Commit();
                count++;
            }
            return $"{count} Suppliers were deleted out of {supplierId.Count}";

        }

        public async Task<string> MassUpdateSupplier(List<SupplierDTOGet> newSuppliers)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (SupplierDTOGet supplier in newSuppliers)
                {
                    var c = await _context.Suppliers.Include(x => x.Country).Where(x => x.SupplierID == supplier.SupplierId).FirstOrDefaultAsync();

                    if (c == null)
                        throw new NotFoundException("Supplier not found");

                    if ((bool)c.Deprecated!)
                        throw new ErrorInputPropertyException("Can't update deprecated supplier");

                    if (supplier.SupplierName != null)
                    {
                        if (supplier.SupplierName.Length > 100)
                            throw new ErrorInputPropertyException("Supplier name is too long");
                    }

                    if (supplier.Country != null)
                    {
                        if (supplier.Country.Length > 50)
                            throw new ErrorInputPropertyException("Country is too long");

                    }

                    Supplier newSupplier = new Supplier
                    {
                        SupplierName = supplier.SupplierName ?? c.SupplierName,
                        CountryID = (await _countryService.GetCountryByName(supplier.Country))?.CountryID ?? c.CountryID,
                        Deprecated = false,
                        OriginalID = c.OriginalID,
                        CreatedAt = DateTime.Now,
                    };

                    c.Deprecated = true;
                    _context.Suppliers.Update(c);
                    _context.Suppliers.Add(newSupplier);
                    count++;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return $"{count} Suppliers were updated out of {newSuppliers.Count}";
            }
            catch (NotFoundException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (ErrorInputPropertyException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Database update error occurred", ex);
            }
        }

        public async Task<List<string>> GetAllSuppliersNameCountry(string? filter)
        {
            var query = _context.Suppliers
                .Include(x => x.Country)
                .Select(x => new { x.SupplierName, CountryName = x.Country.CountryName });

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => (x.SupplierName + " - " + x.CountryName).StartsWith(filter));
            }

            return await query
                .Select(x => x.SupplierName + " - " + x.CountryName)
                .ToListAsync();
        }

    }
}
