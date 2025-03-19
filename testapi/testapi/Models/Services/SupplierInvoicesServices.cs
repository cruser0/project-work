using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISupplierInvoiceService
    {
        Task<ICollection<SupplierInvoiceSupplierDTO>> GetAllSupplierInvoices(SupplierInvoiceSupplierFilter filter);
        Task<SupplierInvoiceSupplierDTO> GetSupplierInvoiceById(int id);
        Task<SupplierInvoiceDTOGet> CreateSupplierInvoice(SupplierInvoice supplierInvoice);
        Task<SupplierInvoiceDTOGet> UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice);
        Task<SupplierInvoiceDTOGet> DeleteSupplierInvoice(int id);
        Task<int> CountSupplierinvoices(SupplierInvoiceSupplierFilter filter);
        Task<string> MassDeleteSupplierInvoice(List<int> supplierInvoiceId);
        Task<string> MassUpdateSupplierInvoice(List<SupplierInvoiceDTOGet> newSupplierInvoices);


    }
    public class SupplierInvoiceService : ISupplierInvoiceService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISupplierInvoiceCostService _serviceCost;
        private readonly StatusService _statusService;
        public SupplierInvoiceService(Progetto_FormativoContext ctx, ISupplierInvoiceCostService serviceCost, StatusService statusService)
        {
            _context = ctx;
            _serviceCost = serviceCost;
            _statusService = statusService;

        }

        public async Task<ICollection<SupplierInvoiceSupplierDTO>> GetAllSupplierInvoices(SupplierInvoiceSupplierFilter filter)
        {
            // Retrieve all suppliers from the database and map them to DTOs
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSupplierinvoices(SupplierInvoiceSupplierFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SupplierInvoiceSupplierDTO> ApplyFilter(SupplierInvoiceSupplierFilter filter)
        {
            int itemsPage = 10;
            var query = (from si in _context.SupplierInvoices.Include(x => x.Status)
                         join s in _context.Suppliers.Include(x => x.Country) on si.SupplierID equals s.SupplierID into SupplierInvoiceGroup
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
                query = query.Where(x => x.SupplierInvoice.SaleID == filter.SupplierInvoiceSaleID);
            }
            if (filter.SupplierInvoiceSupplierID != null)
            {
                query = query.Where(x => x.SupplierInvoice.SupplierID == filter.SupplierInvoiceSupplierID);
            }
            if (!string.IsNullOrEmpty(filter.SupplierInvoiceStatus))
            {
                if (!filter.SupplierInvoiceStatus.Equals("All"))
                    query = query.Where(x => x.SupplierInvoice.Status.StatusName == filter.SupplierInvoiceStatus.ToLower());
            }

            if (!string.IsNullOrEmpty(filter.SupplierInvoiceSupplierName))
            {
                query = query.Where(x => x.Supplier.SupplierName.Contains(filter.SupplierInvoiceSupplierName));
            }

            if (!string.IsNullOrEmpty(filter.SupplierInvoiceSupplierCountry))
            {
                query = query.Where(x => x.Supplier.Country.CountryName.Contains(filter.SupplierInvoiceSupplierCountry));
            }


            if (filter.SupplierInvoicePage != null)
            {
                query = query.Skip(((int)filter.SupplierInvoicePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => new SupplierInvoiceSupplierDTO(x.SupplierInvoice, x.Supplier));
        }

        public async Task<SupplierInvoiceSupplierDTO> GetSupplierInvoiceById(int id)
        {
            var si = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == id).FirstOrDefaultAsync();
            var supplier = await _context.Suppliers.Where(x => x.SupplierID == si.SupplierID).FirstOrDefaultAsync();
            var result = new SupplierInvoiceSupplierDTO(si, supplier);
            if (si == null || supplier == null)
            {
                throw new NotFoundException("Supplier Invoice not found!");
            }
            return result;
        }

        public async Task<SupplierInvoiceDTOGet> CreateSupplierInvoice(SupplierInvoice supplierInvoice)
        {
            if (supplierInvoice == null)
                throw new NullPropertyException("Couldn't create supplier Invoice,data is null");

            var supplier = await _context.Suppliers.Where(x => x.SupplierID == supplierInvoice.SupplierID).FirstOrDefaultAsync();
            if (supplier == null)
                throw new NotFoundException("Supplier not found");
            else if ((bool)supplier.Deprecated)
                throw new ErrorInputPropertyException($"The supplier {supplierInvoice.SupplierID} is deprecated");


            if (!await _context.Sales.AnyAsync(x => x.SaleID == supplierInvoice.SaleID))
                throw new NotFoundException("SaleID not found");

            if (!new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status.StatusName?.ToLower()))
                throw new ErrorInputPropertyException("Status is not valid");
            if (supplierInvoice.InvoiceDate == null || supplierInvoice.InvoiceDate > DateTime.Now)
                throw new ErrorInputPropertyException("Date is not valid");

            supplierInvoice.InvoiceAmount = 0;
            _context.Add(supplierInvoice);
            await _context.SaveChangesAsync();
            return SupplierInvoiceMapper.MapGet(supplierInvoice);
        }

        public async Task<SupplierInvoiceDTOGet> UpdateSupplierInvoice(int id, SupplierInvoice supplierInvoice)
        {
            var siDB = await _context.SupplierInvoices.FirstOrDefaultAsync(x => x.SupplierInvoiceID == id);

            if (siDB == null)
            {
                throw new NotFoundException("Supplier Invoice not found");
            }

            if (supplierInvoice.SaleID != null)
            {
                if (!await _context.Sales.AnyAsync(x => x.SaleID == supplierInvoice.SaleID))
                {
                    throw new NotFoundException("SaleID not present");
                }
                siDB.SaleID = supplierInvoice.SaleID;
            }

            if (supplierInvoice.SupplierID != null)
            {
                var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == supplierInvoice.SupplierID);
                if (supplier == null)
                {
                    throw new NotFoundException("SupplierID not present");
                }

                if ((bool)supplier.Deprecated)
                {
                    throw new ErrorInputPropertyException($"The supplier {supplierInvoice.SupplierID} is deprecated");
                }

                siDB.SupplierID = supplierInvoice.SupplierID;
            }

            if (supplierInvoice.InvoiceDate > DateTime.Now)
            {
                throw new ErrorInputPropertyException("Date cannot be greater than today");
            }

            siDB.InvoiceAmount = supplierInvoice.InvoiceAmount ?? siDB.InvoiceAmount;
            siDB.InvoiceDate = supplierInvoice.InvoiceDate ?? siDB.InvoiceDate;


            if (supplierInvoice.Status != null)
            {
                if (new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status.StatusName.ToLower()))
                {
                    siDB.StatusID = supplierInvoice.StatusID ?? siDB.StatusID;
                }
                else
                {
                    throw new ErrorInputPropertyException("Status not correct");
                }
            }


            _context.SupplierInvoices.Update(siDB);
            await _context.SaveChangesAsync();

            return SupplierInvoiceMapper.MapGet(siDB);
        }

        public async Task<SupplierInvoiceDTOGet> DeleteSupplierInvoice(int id)
        {
            var data = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == id).FirstOrDefaultAsync();
            if (data == null || id < 1)
            {
                throw new NotFoundException("Supplier Invoice not found!");
            }
            List<SupplierInvoiceCost> listInvoiceCost = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == id).ToListAsync();
            if (listInvoiceCost.Count > 0)
            {
                foreach (SupplierInvoiceCost cost in listInvoiceCost)
                {
                    await _serviceCost.DeleteSupplierInvoiceCost(cost.SupplierInvoiceCostsId);
                }
            }
            _context.SupplierInvoices.Remove(data);
            await _context.SaveChangesAsync();
            return SupplierInvoiceMapper.MapGet(data);

        }

        public async Task<string> MassDeleteSupplierInvoice(List<int> supplierInvoiceId)
        {
            int count = 0;
            foreach (int id in supplierInvoiceId)
            {
                var data = await _context.SupplierInvoices.Where(x => x.SupplierInvoiceID == id).FirstOrDefaultAsync();
                if (data == null || id < 1)
                    continue;
                List<SupplierInvoiceCost> listInvoiceCost = await _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == id).ToListAsync();
                if (listInvoiceCost.Count > 0)
                {
                    foreach (SupplierInvoiceCost cost in listInvoiceCost)
                    {
                        await _serviceCost.DeleteSupplierInvoiceCost(cost.SupplierInvoiceCostsId);
                    }
                }
                _context.SupplierInvoices.Remove(data);
                await _context.SaveChangesAsync();
                count++;
            }
            return $"{count} Supplier Invoices were deleted out of {supplierInvoiceId.Count}";

        }

        public async Task<string> MassUpdateSupplierInvoice(List<SupplierInvoiceDTOGet> newSupplierInvoices)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (SupplierInvoiceDTOGet supplierInvoice in newSupplierInvoices)
                {
                    var siDB = await _context.SupplierInvoices.Include(x => x.Status).FirstOrDefaultAsync(x => x.SupplierInvoiceID == supplierInvoice.InvoiceId);

                    if (siDB == null)
                    {
                        throw new NotFoundException("Supplier Invoice not found");
                    }

                    if (supplierInvoice.SaleId != null)
                    {
                        if (!await _context.Sales.AnyAsync(x => x.SaleID == supplierInvoice.SaleId))
                        {
                            throw new NotFoundException("SaleID not present");
                        }
                        siDB.SaleID = supplierInvoice.SaleId;
                    }

                    if (supplierInvoice.SupplierId != null)
                    {
                        var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierID == supplierInvoice.SupplierId);
                        if (supplier == null)
                        {
                            throw new NotFoundException("SupplierID not present");
                        }

                        if ((bool)supplier.Deprecated)
                        {
                            throw new ErrorInputPropertyException($"The supplier {supplierInvoice.SupplierId} is deprecated");
                        }

                        siDB.SupplierID = supplierInvoice.SupplierId;
                    }

                    if (supplierInvoice.InvoiceDate > DateTime.Now)
                    {
                        throw new ErrorInputPropertyException("Date cannot be greater than today");
                    }

                    siDB.InvoiceAmount = supplierInvoice.InvoiceAmount ?? siDB.InvoiceAmount;
                    siDB.InvoiceDate = supplierInvoice.InvoiceDate ?? siDB.InvoiceDate;


                    if (supplierInvoice.Status != null)
                    {
                        if (new[] { "approved", "unapproved" }.Contains(supplierInvoice.Status.ToLower()))
                        {
                            siDB.StatusID = _statusService.GetStatusByName(supplierInvoice.Status)?.StatusID ?? siDB.StatusID;
                        }
                        else
                        {
                            throw new ErrorInputPropertyException("Status not correct");
                        }
                    }


                    _context.SupplierInvoices.Update(siDB);
                    await _context.SaveChangesAsync();

                    count++;
                }

                await transaction.CommitAsync();
                return $"{count} Supplier Invoices were updated out of {newSupplierInvoices.Count}";
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

    }
}
