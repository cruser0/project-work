

using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICostRegistryService
    {
        Task<CostRegistry?> GetCostRegistryByCode(string? name);
        Task<List<CostRegistryDTOGet>> GetAllCostRegistryByCode();
        Task<List<CostRegistryDTOGet>> GetAllCostRegistry(CostRegistryFilter filter);
        Task<int> CountRegistryCost(CostRegistryFilter filter);
        Task<CostRegistryDTOGet> CreateCostRegistry(CostRegistry costRegistry);
        Task<CostRegistryDTOGet> UpdateCostRegistry(int id, CostRegistry costRegistry);
        Task<CostRegistryDTOGet> DeleteCostRegistry(int id);


        Task<string> MassDeleteCostRegistry(List<int> costRegistryId);

        Task<string> MassUpdateCostRegistry(List<CostRegistryDTOGet> newCostRegistries);
        Task<CostRegistry> GetCostRegistryById(int id);
    }
    public class CostRegistryService : ICostRegistryService
    {

        private readonly Progetto_FormativoContext _context;
        public CostRegistryService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<CostRegistry?> GetCostRegistryByCode(string? name)
        {
            return await _context.CostRegistries.Where(x => x.CostRegistryUniqueCode.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<CostRegistryDTOGet>> GetAllCostRegistryByCode()
        {
            var list = await _context.CostRegistries.ToListAsync();
            if (list.Any())
                return list.Select(x => Mapper.CostRegistryMapper.MapGet(x)).ToList();
            return new List<CostRegistryDTOGet>();
        }

        public async Task<List<CostRegistryDTOGet>> GetAllCostRegistry(CostRegistryFilter filter)
        {
            var list = await ApplyFilter(filter).ToListAsync();
            return list;
        }

        public async Task<int> CountRegistryCost(CostRegistryFilter filter)
        {
            var list = await ApplyFilter(filter).CountAsync();
            return list;
        }
        private IQueryable<CostRegistryDTOGet> ApplyFilter(CostRegistryFilter filter)
        {
            int itemsPage = 10;
            var query = _context.CostRegistries.Include(x => x.SupplierInvoiceCosts).Include(x => x.CustomerInvoiceCosts).AsQueryable();

            if (!string.IsNullOrEmpty(filter.CostRegistryCode))
            {
                query = query.Where(x => x.CostRegistryUniqueCode.StartsWith(filter.CostRegistryCode));
            }
            if (!string.IsNullOrEmpty(filter.CostRegistryName))
            {
                query = query.Where(x => x.CostRegistryName.StartsWith(filter.CostRegistryName));
            }
            if (filter.CostRegistryPage != null)
            {
                query = query.Skip(((int)filter.CostRegistryPage - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => CostRegistryMapper.MapGet(x));
        }
        /*
        public int CostRegistryID { get; set; }
        public string? CostRegistryUniqueCode { get; set; }
        public string? CostRegistryName { get; set; }
        public decimal? CostRegistryPrice { get; set; }
        public int? CostRegistryQuantity { get; set; }
         */
        public async Task<CostRegistryDTOGet> CreateCostRegistry(CostRegistry costRegistry)
        {
            if (costRegistry == null)
                throw new NullPropertyException("Couldn't create Cost Registry");

            var nullFields = new List<string>();

            if (string.IsNullOrEmpty(costRegistry.CostRegistryUniqueCode)) nullFields.Add("CostRegistryUniqueCode");
            if (string.IsNullOrEmpty(costRegistry.CostRegistryName)) nullFields.Add("CostRegistryName");
            if (costRegistry.CostRegistryPrice == null) nullFields.Add("CostRegistryPrice");
            if (costRegistry.CostRegistryQuantity == null) nullFields.Add("CostRegistryQuantity");

            if (nullFields.Any())
                throw new NullPropertyException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            if (costRegistry.CostRegistryUniqueCode!.Length > 100)
                throw new ErrorInputPropertyException("Code is too long");

            if (costRegistry.CostRegistryName!.Length > 100)
                throw new ErrorInputPropertyException("Name is too long");

            _context.CostRegistries.Add(costRegistry);
            await _context.SaveChangesAsync();
            return CostRegistryMapper.MapGet(costRegistry);
        }

        public async Task<CostRegistryDTOGet> UpdateCostRegistry(int id, CostRegistry costRegistry)
        {
            var cr = await _context.CostRegistries.Where(x => x.CostRegistryID == id).FirstOrDefaultAsync();

            if (cr == null)
                throw new NotFoundException("Cost Registry not found");

            if (!string.IsNullOrEmpty(costRegistry.CostRegistryName))
            {
                if (costRegistry.CostRegistryName!.Length > 100)
                    throw new ErrorInputPropertyException("Name is too long");
                cr.CostRegistryName = costRegistry.CostRegistryName;
            }

            if (costRegistry.CostRegistryPrice != null)
            {
                if (costRegistry.CostRegistryPrice <= 0)
                    throw new ErrorInputPropertyException("cost cannot be zero or less");
                cr.CostRegistryPrice = costRegistry.CostRegistryPrice;
            }

            if (costRegistry.CostRegistryQuantity != null)
            {
                if (costRegistry.CostRegistryQuantity <= 0)
                    throw new ErrorInputPropertyException("quantity cannot be zero or less");
                cr.CostRegistryQuantity = costRegistry.CostRegistryQuantity;
            }

            try
            {
                _context.CostRegistries.Update(cr);
                await _context.SaveChangesAsync();
                return CostRegistryMapper.MapGet(cr);
            }
            catch
            {
                throw new UpdateException("Couldn't update");
            }
        }

        public async Task<string> MassUpdateCostRegistry(List<CostRegistryDTOGet> newCostRegistries)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                List<CostRegistry> UpdatedCostRegistries = new List<CostRegistry>();
                foreach (var cr in newCostRegistries)
                {
                    var oldCost = await _context.CostRegistries.Where(x => x.CostRegistryID == cr.CostRegistryID).FirstOrDefaultAsync();

                    if (oldCost == null)
                        throw new NotFoundException("Cost Registry not found");

                    if (!string.IsNullOrEmpty(cr.CostRegistryName))
                    {
                        if (cr.CostRegistryName!.Length > 100)
                            throw new ErrorInputPropertyException("Name is too long");
                        oldCost.CostRegistryName = cr.CostRegistryName;
                    }

                    if (cr.CostRegistryPrice != null)
                    {
                        if (cr.CostRegistryPrice <= 0)
                            throw new ErrorInputPropertyException("cost cannot be zero or less");
                        oldCost.CostRegistryPrice = cr.CostRegistryPrice;
                    }

                    if (cr.CostRegistryQuantity != null)
                    {
                        if (cr.CostRegistryQuantity <= 0)
                            throw new ErrorInputPropertyException("quantity cannot be zero or less");
                        oldCost.CostRegistryQuantity = cr.CostRegistryQuantity;
                    }
                    UpdatedCostRegistries.Add(oldCost);
                    count++;
                }
                _context.UpdateRange(UpdatedCostRegistries);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return $"{count} Cost Registries were updated out of {newCostRegistries.Count}";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CostRegistryDTOGet> DeleteCostRegistry(int id)
        {
            var cr = await _context.CostRegistries
                .Where(x => x.CostRegistryID == id)
                .Include(x => x.SupplierInvoiceCosts)
                .Include(x => x.CustomerInvoiceCosts)
                .FirstOrDefaultAsync();

            List<SupplierInvoiceCost> updateSupCosts = new List<SupplierInvoiceCost>();
            List<CustomerInvoiceCost> updateCusCosts = new List<CustomerInvoiceCost>();

            if (cr == null)
                throw new NotFoundException("Cost Registry not found");

            if (cr.SupplierInvoiceCosts.Count > 0)
            {
                foreach (var supCost in cr.SupplierInvoiceCosts)
                {
                    supCost.CostRegistryID = null;
                    updateSupCosts.Add(supCost);
                }
            }

            if (cr.CustomerInvoiceCosts.Count > 0)
            {
                foreach (var cusCost in cr.CustomerInvoiceCosts)
                {
                    cusCost.CostRegistryID = null;
                    updateCusCosts.Add(cusCost);
                }
            }
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.UpdateRange(updateSupCosts);
                _context.UpdateRange(updateCusCosts);
                _context.Remove(cr);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return CostRegistryMapper.MapGet(cr);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<string> MassDeleteCostRegistry(List<int> costRegistryId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var deleteRegistry = await _context.CostRegistries
                    .Where(x => costRegistryId.Contains(x.CostRegistryID))
                    .Include(x => x.SupplierInvoiceCosts)
                    .Include(x => x.CustomerInvoiceCosts)
                    .ToListAsync();

                if (deleteRegistry.Count != costRegistryId.Count)
                    throw new NotFoundException("Some Cost Registries not found");

                var updateSupCosts = deleteRegistry
                    .SelectMany(cr => cr.SupplierInvoiceCosts)
                    .Select(supCost =>
                    {
                        supCost.CostRegistryID = null;
                        return supCost;
                    })
                    .ToList();

                var updateCusCosts = deleteRegistry
                    .SelectMany(cr => cr.CustomerInvoiceCosts)
                    .Select(cusCost =>
                    {
                        cusCost.CostRegistryID = null;
                        return cusCost;
                    })
                    .ToList();

                _context.UpdateRange(updateSupCosts);
                _context.UpdateRange(updateCusCosts);
                _context.RemoveRange(deleteRegistry);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return $"{deleteRegistry.Count} Cost Registries were deleted out of {costRegistryId.Count}";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CostRegistry> GetCostRegistryById(int id)
        {
            return await _context.CostRegistries.Where(x => x.CostRegistryID == id).FirstOrDefaultAsync();
        }
    }
}
