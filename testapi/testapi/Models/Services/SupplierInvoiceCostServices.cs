using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISupplierInvoiceCostService
    {
        Task<ICollection<SupplierInvoiceCostDTOGet>> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);
        Task<SupplierInvoiceCostDTOGet> GetSupplierInvoiceCostById(int id);
        Task<SupplierInvoiceCostDTOGet> CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost);
        Task<SupplierInvoiceCostDTOGet> UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost);
        Task<SupplierInvoiceCostDTOGet> DeleteSupplierInvoiceCost(int id);

        Task<int> CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter);
        Task<string> MassDeleteSupplierInvoiceCost(List<int> supplierInvoiceCostId);
        Task<string> MassUpdateSupplierInvoiceCost(List<SupplierInvoiceCostDTOGet> newSupplierInvoiceCosts);



    }
    public class SupplierInvoiceCostServices : ISupplierInvoiceCostService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICostRegistryService _costRegistryService;
        public SupplierInvoiceCostServices(Progetto_FormativoContext ctx, ICostRegistryService costRegistryService)
        {
            _context = ctx;
            _costRegistryService = costRegistryService;

        }

        public async Task<ICollection<SupplierInvoiceCostDTOGet>> GetAllSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SupplierInvoiceCostDTOGet> ApplyFilter(SupplierInvoiceCostFilter filter)
        {
            int itemsPage = 10;
            var query = _context.SupplierInvoiceCosts.Include(x => x.CostRegistry).Include(x => x.SupplierInvoice).AsQueryable();

            if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostSupplierInvoiceCode))
            {
                query = query.Where(x => x.SupplierInvoice.SupplierInvoiceCode.Contains(filter.SupplierInvoiceCostSupplierInvoiceCode));
            }

            if (!string.IsNullOrEmpty(filter.SupplierInvoiceCostName))
            {
                query = query.Where(x => x.Name.Contains(filter.SupplierInvoiceCostName));
            }

            if (filter.SupplierInvoiceCostCostFrom != null && filter.SupplierInvoiceCostCostTo != null)
            {
                if (filter.SupplierInvoiceCostCostFrom > filter.SupplierInvoiceCostCostTo)
                {
                    throw new ErrorInputPropertyException("CostFrom cannot be more than CostTo.");
                }

                query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom && s.Cost <= filter.SupplierInvoiceCostCostTo);
            }
            else if (filter.SupplierInvoiceCostCostFrom != null)
            {
                query = query.Where(s => s.Cost >= filter.SupplierInvoiceCostCostFrom);
            }
            else if (filter.SupplierInvoiceCostCostTo != null)
            {
                query = query.Where(s => s.Cost <= filter.SupplierInvoiceCostCostTo);
            }

            if (filter.SupplierInvoiceCostQuantity != null)
            {
                query = query.Where(x => x.Quantity == filter.SupplierInvoiceCostQuantity);
            }
            if (filter.SupplierInvoiceCostRegistryCode != null)
            {
                query = query.Where(x => x.CostRegistry.CostRegistryUniqueCode.Contains(filter.SupplierInvoiceCostRegistryCode));
            }

            if (filter.SupplierInvoiceCostPage != null)
            {
                query = query.Skip(((int)filter.SupplierInvoiceCostPage - 1) * itemsPage).Take(itemsPage);
            }

            return query.Select(x => SupplierInvoiceCostMapper.MapGet(x));
        }

        public async Task<SupplierInvoiceCostDTOGet> GetSupplierInvoiceCostById(int id)
        {
            var data = await _context.SupplierInvoiceCosts.Include(x => x.CostRegistry).Include(x => x.SupplierInvoice).Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new NotFoundException("Supplier Invoice Cost not found!");
            }
            return SupplierInvoiceCostMapper.MapGet(data);
        }

        public async Task<SupplierInvoiceCostDTOGet> CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice si;

            if (!await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId).AnyAsync())
                throw new NotFoundException("Supplier Invoice Id not found!");


            si = await _context.SupplierInvoices.Include(x => x.Status).Where(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId).FirstAsync();

            if (si.Status.StatusName.ToLower().Equals("approved"))
                throw new ErrorInputPropertyException("Supplier Invoice is already approved");


            decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == supplierInvoiceCost.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);

            si.InvoiceAmount = total + supplierInvoiceCost.Cost * supplierInvoiceCost.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.Add(supplierInvoiceCost);
            await _context.SaveChangesAsync();
            return SupplierInvoiceCostMapper.MapGet(supplierInvoiceCost);
        }

        public async Task<SupplierInvoiceCostDTOGet> UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice? si;
            var sicDB = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            SupplierInvoice? oldSi = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();
            oldSi.InvoiceAmount = oldSi.InvoiceAmount - (sicDB.Cost * sicDB.Quantity);
            if (sicDB != null && id >= 0)
            {
                if (supplierInvoiceCost.SupplierInvoiceId != null)
                    sicDB.SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId;
                if ((await _context.SupplierInvoices.Include(x => x.Status)
                    .Where(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId)
                    .FirstOrDefaultAsync()).Status.StatusName.ToLower().Equals("approved"))
                    throw new ErrorInputPropertyException("Supplier Invoice is already approved");
                if (!await _context.SupplierInvoices.AnyAsync(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId))
                    throw new NotFoundException("Supplier Invoice not Found");
                if (supplierInvoiceCost.Quantity > 0)
                    sicDB.Quantity = supplierInvoiceCost.Quantity ?? sicDB.Quantity;
                if (supplierInvoiceCost.Cost > 0)
                    sicDB.Cost = supplierInvoiceCost.Cost ?? sicDB.Cost;
                sicDB.Name = supplierInvoiceCost.Name ?? sicDB.Name;
                sicDB.CostRegistryID = supplierInvoiceCost.CostRegistryID ?? sicDB.CostRegistryID;

                _context.SupplierInvoiceCosts.Update(sicDB);
                await _context.SaveChangesAsync();
                if (sicDB.Cost > 0 && sicDB.Quantity > 0)
                {
                    _context.SupplierInvoices.Update(oldSi);

                    si = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();
                    decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == sicDB.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
                    si.InvoiceAmount = total;
                    _context.SupplierInvoices.Update(si);
                    await _context.SaveChangesAsync();
                }
                return SupplierInvoiceCostMapper.MapGet(sicDB);
            }
            throw new NotFoundException("Supplier Invoice Cost not found");
        }

        public async Task<SupplierInvoiceCostDTOGet> DeleteSupplierInvoiceCost(int id)
        {
            var data = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
            if (data == null || id < 1)
            {
                throw new NotFoundException("Supplier Invoice Cost not found!");
            }
            SupplierInvoice si = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == data.SupplierInvoiceId).FirstAsync();
            decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == data.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
            si.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.SupplierInvoiceCosts.Remove(data);
            await _context.SaveChangesAsync();
            return SupplierInvoiceCostMapper.MapGet(data);

        }
        public async Task<string> MassDeleteSupplierInvoiceCost(List<int> supplierInvoiceCostId)
        {
            int count = 0;
            foreach (int id in supplierInvoiceCostId)
            {
                var data = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefaultAsync();
                if (data == null || id < 1)
                    continue;
                SupplierInvoice si = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == data.SupplierInvoiceId).FirstAsync();
                decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == data.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
                si.InvoiceAmount = total - data.Cost * data.Quantity;
                _context.SupplierInvoices.Update(si);
                _context.SupplierInvoiceCosts.Remove(data);
                await _context.SaveChangesAsync();
                count++;
            }
            return $"{count} Supplier invoice cost were deleted out of {supplierInvoiceCostId.Count}";

        }

        public async Task<string> MassUpdateSupplierInvoiceCost(List<SupplierInvoiceCostDTOGet> newSupplierInvoiceCosts)
        {
            int count = 0;
            foreach (SupplierInvoiceCostDTOGet supplierInvoiceCost in newSupplierInvoiceCosts)
            {

                SupplierInvoice? si;

                var sicDB = await _context.SupplierInvoiceCosts.Include(x => x.CostRegistry).Where(x => x.SupplierInvoiceCostsId == supplierInvoiceCost.SupplierInvoiceCostsId).FirstOrDefaultAsync();

                SupplierInvoice? oldSi = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();

                oldSi.InvoiceAmount = oldSi.InvoiceAmount - (sicDB.Cost * sicDB.Quantity);

                if (sicDB != null)
                {
                    if (supplierInvoiceCost.SupplierInvoiceId != null)
                        sicDB.SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId;

                    if ((await _context.SupplierInvoices.Include(x => x.Status)
                            .Where(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId)
                            .FirstOrDefaultAsync())
                            .Status.StatusName.ToLower().Equals("approved"))
                        throw new ErrorInputPropertyException("Supplier Invoice is already approved");

                    if (!await _context.SupplierInvoices.AnyAsync(x => x.SupplierInvoiceID == supplierInvoiceCost.SupplierInvoiceId))
                        throw new NotFoundException("Supplier Invoice not Found");

                    if (supplierInvoiceCost.Quantity > 0)
                        sicDB.Quantity = supplierInvoiceCost.Quantity ?? sicDB.Quantity;

                    if (supplierInvoiceCost.Cost > 0)
                        sicDB.Cost = supplierInvoiceCost.Cost ?? sicDB.Cost;

                    sicDB.CostRegistryID = (await _costRegistryService.GetCostRegistryByCode(supplierInvoiceCost.CostRegistryCode))?.CostRegistryID ?? sicDB.CostRegistryID;

                    sicDB.Name = supplierInvoiceCost.Name ?? sicDB.Name;

                    _context.SupplierInvoiceCosts.Update(sicDB);
                    await _context.SaveChangesAsync();
                    if (sicDB.Cost > 0 && sicDB.Quantity > 0)
                    {
                        _context.SupplierInvoices.Update(oldSi);

                        si = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == sicDB.SupplierInvoiceId).FirstOrDefaultAsync();
                        decimal? total = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == sicDB.SupplierInvoiceId).SumAsync(x => x.Cost * x.Quantity);
                        si.InvoiceAmount = total;
                        _context.SupplierInvoices.Update(si);
                        await _context.SaveChangesAsync();
                    }

                }
                count++;
            }
            return $"{count} Supplier invoice cost were updated out of {newSupplierInvoiceCosts.Count}";
        }
    }
}
