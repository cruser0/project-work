using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerInvoicesService
    {
        Task<ICollection<CustomerInvoiceDTOGet>> GetAllCustomerInvoices(CustomerInvoiceFilter filter);
        Task<ICollection<CustomerInvoiceTotalAmountPaidDTO>> GetAllCustomerInvoicesWithTotalPaid(CustomerInvoiceFilter filter);
        Task<CustomerInvoiceDTOGet> GetCustomerInvoiceById(int id);
        Task<CustomerInvoice?> GetOnlyCustomerInvoiceById(int id);
        Task<CustomerInvoiceDTOGet> CreateCustomerInvoice(CustomerInvoice customer);
        Task<CustomerInvoiceDTOGet> UpdateCustomerInvoice(int id, CustomerInvoice customer);
        Task<CustomerInvoiceDTOGet> DeleteCustomerInvoice(int id);
        Task<int> CountCustomerInvoices(CustomerInvoiceFilter filter);
        Task<string> MassDeleteCustomerInvoice(List<int> customerInvoiceId);

        Task<string> MassUpdateCustomerInvoice(List<CustomerInvoiceDTOGet> newCustomerInvoices);
        Task<CustomerInvoiceSummary> GetCustomerInvoiceSummary(int customerID);
        Task<CustomerInvoiceDTOGet> MakeInvoiceFromSupplier(MakeCustomerInvoiceDTO makeCustomerInvoiceDTO);
    }
    public class CustomerInvoicesServices : ICustomerInvoicesService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly IStatusService _statusService;

        List<string> statusList = new() { "paid", "unpaid" };
        public CustomerInvoicesServices(Progetto_FormativoContext ctx, IStatusService ss)
        {
            _context = ctx;
            _statusService = ss;

        }

        public async Task<ICollection<CustomerInvoiceDTOGet>> GetAllCustomerInvoices(CustomerInvoiceFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }
        public async Task<ICollection<CustomerInvoiceTotalAmountPaidDTO>> GetAllCustomerInvoicesWithTotalPaid(CustomerInvoiceFilter filter)
        {
            var query = _context.CustomerInvoices
                .Include(x => x.Status)
                .Include(x => x.Sale).ThenInclude(x => x.Customer).ThenInclude(x => x.Country)
                .Include(x => x.CustomerInvoiceAmountPaid)
                .AsQueryable();

            query = query.Where(x => x.Sale.BoLnumber == filter.CustomerInvoiceSaleBoL)
                         .Where(x => x.Sale.BookingNumber == filter.CustomerInvoiceSaleBk)
                         .Where(x => x.Sale.Customer.Country.CountryName == filter.CustomerCountry)
                         .Where(x => x.Sale.Customer.CustomerName == filter.CustomerName);

            var result = await query.Select(x => new CustomerInvoiceTotalAmountPaidDTO
            {
                CustomerInvoiceId = x.CustomerInvoiceID,
                CustomerInvoiceCode = x.CustomerInvoiceCode,
                SaleID = x.SaleID,
                AmountPaidID = x.CustomerInvoiceAmountPaid.CustomerInvoiceAmountPaidID,
                SaleBookingNumber = x.Sale.BookingNumber,
                SaleBoL = x.Sale.BoLnumber,
                InvoiceAmount = x.InvoiceAmount,
                InvoiceDate = x.InvoiceDate,
                Status = x.Status.StatusName,
                AmountPaid = x.CustomerInvoiceAmountPaid.AmountPaid,
            }).ToListAsync();
            return result;
        }

        public async Task<int> CountCustomerInvoices(CustomerInvoiceFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        public IQueryable<CustomerInvoiceDTOGet> ApplyFilter(CustomerInvoiceFilter filter)
        {
            int itemsPage = 10;

            var query = _context.CustomerInvoices.Include(x => x.Status).Include(x => x.Sale).Include(x => x.CustomerInvoiceAmountPaid).AsQueryable();

            if (filter.CustomerInvoiceSaleID != null)
            {
                query = query.Where(x => x.SaleID == filter.CustomerInvoiceSaleID);
            }

            if (!string.IsNullOrEmpty(filter.CustomerInvoiceSaleBoL))
            {
                query = query.Where(x => x.Sale.BoLnumber.Contains(filter.CustomerInvoiceSaleBoL));
            }

            if (!string.IsNullOrEmpty(filter.CustomerInvoiceSaleBk))
            {
                query = query.Where(x => x.Sale.BookingNumber.Contains(filter.CustomerInvoiceSaleBk));
            }

            if (!string.IsNullOrEmpty(filter.CustomerInvoiceCode))
            {
                query = query.Where(x => x.CustomerInvoiceCode.Contains(filter.CustomerInvoiceCode));
            }

            if (filter.CustomerInvoiceInvoiceAmountFrom != null && filter.CustomerInvoiceInvoiceAmountTo != null)
            {
                query = query.Where(s => s.InvoiceAmount >= filter.CustomerInvoiceInvoiceAmountFrom && s.InvoiceAmount <= filter.CustomerInvoiceInvoiceAmountTo);
            }
            else if (filter.CustomerInvoiceInvoiceAmountFrom != null)
            {
                query = query.Where(s => s.InvoiceAmount >= filter.CustomerInvoiceInvoiceAmountFrom);
            }
            else if (filter.CustomerInvoiceInvoiceAmountTo != null)
            {
                query = query.Where(s => s.InvoiceAmount <= filter.CustomerInvoiceInvoiceAmountTo);
            }

            if (filter.CustomerInvoiceInvoiceDateFrom != null && filter.CustomerInvoiceInvoiceDateTo != null)
            {
                query = query.Where(s => s.InvoiceDate >= filter.CustomerInvoiceInvoiceDateFrom && s.InvoiceDate <= filter.CustomerInvoiceInvoiceDateTo);
            }
            else if (filter.CustomerInvoiceInvoiceDateFrom != null)
            {
                query = query.Where(s => s.InvoiceDate >= filter.CustomerInvoiceInvoiceDateFrom);
            }
            else if (filter.CustomerInvoiceInvoiceDateTo != null)
            {
                query = query.Where(s => s.InvoiceDate <= filter.CustomerInvoiceInvoiceDateTo);
            }
            if (!string.IsNullOrEmpty(filter.CustomerInvoiceStatus))
            {
                query = query.Where(s => s.Status.StatusName == filter.CustomerInvoiceStatus);
            }
            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
               query= query.Include(x => x.Sale).ThenInclude(x => x.Customer);
                query = query.Where(s => s.Sale.Customer.CustomerName == filter.CustomerName);
            }
            if (!string.IsNullOrEmpty(filter.CustomerCountry))
            {
                query = query.Include(x => x.Sale).ThenInclude(x => x.Customer).ThenInclude(x => x.Country);
                query = query.Where(s => s.Sale.Customer.Country.CountryName == filter.CustomerCountry);
            }
            if (filter.CustomerInvoicePage != null)
            {
                query = query.Skip(((int)filter.CustomerInvoicePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => CustomerInvoiceMapper.MapGet(x));
        }

        public async Task<CustomerInvoiceDTOGet> CreateCustomerInvoice(CustomerInvoice customerInvoice)
        {

            if (!statusList.Contains(customerInvoice.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");

            var sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == customerInvoice.SaleID).FirstOrDefaultAsync();

            if (sale == null)
                throw new NotFoundException($"There is no sale with id {customerInvoice.SaleID}");

            if (sale.Status.StatusName.ToLower().Equals("closed"))
                throw new ErrorInputPropertyException($"The Sale is already closed");

            customerInvoice.InvoiceAmount = 0;

            string code;
            while (true)
            {
                code = "CINV-" + Guid.NewGuid().ToString("N").Substring(0, 20);
                if (!await _context.CustomerInvoices.AnyAsync(x => x.CustomerInvoiceCode.Equals(code)))
                    break;
            }

            customerInvoice.CustomerInvoiceCode = code;
            _context.Add(customerInvoice);
            await _context.SaveChangesAsync();

            int invoiceId = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceCode == code).Select(x => x.CustomerInvoiceID).FirstAsync();
            CustomerInvoiceAmountPaid amountPaid = new CustomerInvoiceAmountPaid()
            {
                CustomerInvoiceID = invoiceId,
                AmountPaid = 0
            };

            await _context.CustomerInvoiceAmountPaids.AddAsync(amountPaid);


            var Total = await _context.CustomerInvoices.Where(x => x.SaleID == customerInvoice.SaleID).SumAsync(x => x.InvoiceAmount);

            sale.TotalRevenue = Total;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return CustomerInvoiceMapper.MapGet(customerInvoice);
        }

        public async Task<CustomerInvoiceDTOGet> UpdateCustomerInvoice(int id, CustomerInvoice customerInvoice)
        {
            var ciDB = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == id).Include(x => x.Status).Include(x => x.CustomerInvoiceAmountPaid).FirstOrDefaultAsync();


            int? oldSaleId = ciDB.SaleID;

            ciDB.SaleID = customerInvoice.SaleID ?? ciDB.SaleID;
            ciDB.InvoiceAmount = customerInvoice.InvoiceAmount ?? ciDB.InvoiceAmount;
            ciDB.InvoiceDate = customerInvoice.InvoiceDate ?? ciDB.InvoiceDate;
            ciDB.StatusID = customerInvoice.StatusID ?? ciDB.StatusID;
            ciDB.Status = customerInvoice.Status ?? ciDB.Status;

            if (!string.IsNullOrEmpty(customerInvoice.Status!.StatusName) && !statusList.Contains(customerInvoice.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");

            Sale sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == ciDB.SaleID).FirstAsync();
            if (sale.Status.StatusName.ToLower().Equals("closed"))

                throw new ErrorInputPropertyException($"The current Sale is already closed");

            if (customerInvoice.InvoiceAmount <= 0)
                throw new ErrorInputPropertyException("The amount can't be less or equal than 0");

            _context.CustomerInvoices.Update(ciDB);

            CustomerInvoiceAmountPaid amountPaid = await _context.CustomerInvoiceAmountPaids
                .Where(x => x.CustomerInvoiceAmountPaidID == customerInvoice.CustomerInvoiceAmountPaid.CustomerInvoiceAmountPaidID).FirstAsync();

            amountPaid.AmountPaid = customerInvoice.InvoiceAmount;

            _context.CustomerInvoiceAmountPaids.Update(amountPaid);


            await _context.SaveChangesAsync();

            if (oldSaleId.HasValue)
            {
                var newSale = await _context.Sales.Where(x => x.SaleID == ciDB.SaleID).FirstOrDefaultAsync();
                if (newSale!.Status.StatusName.ToLower().Equals("closed"))
                    throw new ErrorInputPropertyException($"The current Sale is already closed");

                var TotalOldSale = await _context.CustomerInvoices.Where(x => x.SaleID == oldSaleId.Value).SumAsync(x => x.InvoiceAmount);

                var oldSale = await _context.Sales.Where(x => x.SaleID == oldSaleId.Value).FirstOrDefaultAsync();
                oldSale!.TotalRevenue = TotalOldSale;

                var TotalNewSale = await _context.CustomerInvoices.Where(x => x.SaleID == ciDB.SaleID).SumAsync(x => x.InvoiceAmount);

                newSale.TotalRevenue = TotalNewSale;

                _context.Sales.Update(oldSale);
                _context.Sales.Update(newSale);
                await _context.SaveChangesAsync();
            }

            return CustomerInvoiceMapper.MapGet(ciDB);
        }

        public async Task<CustomerInvoiceDTOGet> DeleteCustomerInvoice(int id)
        {
            CustomerInvoice? data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == id).Include(x => x.Status).Include(x => x.CustomerInvoiceAmountPaid).FirstOrDefaultAsync();

            if (data == null)
                throw new NotFoundException("Customer invoice not found!");
            Sale? sale = await _context.Sales.Where(x => x.SaleID == data.SaleID).Include(x => x.Status).FirstOrDefaultAsync();
            if (sale == null)
                throw new NotFoundException("Sale not found!");

            if (sale.Status.StatusName.ToLower().Equals("closed"))
                throw new ErrorInputPropertyException("Sale is closed,can't delete!");
            sale.TotalRevenue -= data.InvoiceAmount;
            List<CustomerInvoiceCost> listInvoiceCost = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == id).ToListAsync();
            if (listInvoiceCost.Count > 0)
            {
                _context.CustomerInvoiceCosts.RemoveRange(listInvoiceCost);
            }

            _context.CustomerInvoices.Remove(data);
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return CustomerInvoiceMapper.MapGet(data);
        }

        public async Task<string> MassDeleteCustomerInvoice(List<int> customerInvoiceId)
        {
            int count = 0;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (int id in customerInvoiceId)
                {
                    CustomerInvoice? data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == id).FirstOrDefaultAsync();
                    try
                    {

                        if (data == null)
                            throw new NotFoundException("Customer invoice not found!");
                        Sale? sale = await _context.Sales.Where(x => x.SaleID == data.SaleID).Include(x => x.Status).FirstOrDefaultAsync();
                        if (sale == null)
                            throw new NotFoundException("Sale not found!");

                        if (sale.Status.StatusName.ToLower().Equals("closed"))
                            throw new ErrorInputPropertyException("Sale is closed,can't delete!");
                        sale.TotalRevenue -= data.InvoiceAmount;
                        List<CustomerInvoiceCost> listInvoiceCost = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceID == id).ToListAsync();
                        if (listInvoiceCost.Count > 0)
                        {
                            _context.CustomerInvoiceCosts.RemoveRange(listInvoiceCost);
                        }

                        _context.CustomerInvoices.Remove(data);
                        _context.Sales.Update(sale);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    count++;
                }
                await transaction.CommitAsync();
            }
            catch (NotFoundException nex)
            {
                await transaction.RollbackAsync();
                return "Process stopped " + nex.Message;
            }
            catch (ErrorInputPropertyException eipe)
            {
                await transaction.RollbackAsync();
                return "Process stopped " + eipe.Message;
            }
            return $"{count} Customer Invoices deleted out of {customerInvoiceId.Count}";
        }
        public async Task<CustomerInvoiceDTOGet> GetCustomerInvoiceById(int id)
        {
            var data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == id).Include(x => x.Status).Include(x => x.Sale).Include(x => x.CustomerInvoiceAmountPaid).FirstOrDefaultAsync();

            if (data == null)
                throw new NotFoundException("Customer invoice not found!");

            return CustomerInvoiceMapper.MapGet(data);
        }

        public async Task<CustomerInvoice?> GetOnlyCustomerInvoiceById(int id)
        {
            var data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == id).Include(x => x.Status).Include(x => x.CustomerInvoiceAmountPaid).FirstOrDefaultAsync();

            return data;
        }

        public async Task<string> MassUpdateCustomerInvoice(List<CustomerInvoiceDTOGet> newCustomerInvoices)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (CustomerInvoiceDTOGet customerInvoice in newCustomerInvoices)
                {
                    var ciDB = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceID == customerInvoice.CustomerInvoiceId)
                        .Include(x => x.Status)
                        .Include(x => x.Sale)
                        .Include(x => x.CustomerInvoiceAmountPaid)
                        .FirstOrDefaultAsync();

                    if (ciDB == null)
                        throw new NotFoundException("Customer invoice not found");

                    int? oldSaleId = ciDB.SaleID;

                    ciDB.SaleID = customerInvoice.SaleID ?? ciDB.SaleID;
                    if (!await _context.Sales.Where(x => x.SaleID == customerInvoice.SaleID).AnyAsync())
                        throw new NotFoundException("SaleId not found");
                    if (!await _context.Sales.Where(x => x.SaleID == ciDB.SaleID).AnyAsync())
                        throw new NotFoundException("Old SaleId not found");
                    Status statusnew = await _statusService.GetStatusByName(customerInvoice.Status);
                    CustomerInvoice customerInvoiceMapped = CustomerInvoiceMapper.Map(customerInvoice, statusnew, ciDB.Sale/*, ciDB.CustomerInvoiceAmountPaid*/);
                    ciDB.InvoiceAmount = customerInvoiceMapped.InvoiceAmount ?? ciDB.InvoiceAmount;
                    ciDB.InvoiceDate = customerInvoiceMapped.InvoiceDate ?? ciDB.InvoiceDate;
                    ciDB.StatusID = customerInvoiceMapped.StatusID ?? ciDB.StatusID;
                    ciDB.Status = customerInvoiceMapped.Status ?? ciDB.Status;

                    if (!string.IsNullOrEmpty(customerInvoice.Status) && !statusList.Contains(customerInvoice.Status.ToLower()))
                        throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");
                    Sale sale = await _context.Sales.Where(x => x.SaleID == ciDB.SaleID).Include(x => x.Status).FirstAsync();
                    if (sale.Status.StatusName.ToLower().Equals("closed"))
                        throw new ErrorInputPropertyException($"The current Sale is already closed");

                    if (customerInvoice.InvoiceAmount <= 0)
                        throw new ErrorInputPropertyException("The amount can't be less or equal than 0");

                    _context.CustomerInvoices.Update(ciDB);
                    await _context.SaveChangesAsync();

                    if (oldSaleId.HasValue)
                    {
                        var newSale = await _context.Sales.Where(x => x.SaleID == ciDB.SaleID).Include(x => x.Status).FirstOrDefaultAsync();
                        if (newSale!.Status.StatusName.ToLower().Equals("closed"))
                            throw new ErrorInputPropertyException($"The current Sale is already closed");

                        var TotalOldSale = await _context.CustomerInvoices.Where(x => x.SaleID == oldSaleId.Value).SumAsync(x => x.InvoiceAmount);

                        var oldSale = await _context.Sales.Where(x => x.SaleID == oldSaleId.Value).FirstOrDefaultAsync();
                        oldSale!.TotalRevenue = TotalOldSale;

                        var TotalNewSale = await _context.CustomerInvoices.Where(x => x.SaleID == ciDB.SaleID).SumAsync(x => x.InvoiceAmount);

                        newSale.TotalRevenue = TotalNewSale;

                        _context.Sales.Update(oldSale);
                        await _context.SaveChangesAsync();
                        _context.Sales.Update(newSale);
                        await _context.SaveChangesAsync();
                    }
                    count++;
                }

                await transaction.CommitAsync();
                return $"{count} Customer Invoices were updated out of {newCustomerInvoices.Count}";
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

        public async Task<CustomerInvoiceSummary> GetCustomerInvoiceSummary(int customerID)
        {
            var data = await _context.CustomerInvoices
                .Include(x => x.Sale)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Status)
                .Where(x => x.Sale.Customer.CustomerID == customerID)
                .GroupBy(x => x.Status.StatusName)  // Accessing the StatusName from the related Status entity
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToDictionaryAsync(x => x.Status.ToLower(), x => x.Count);

            return new CustomerInvoiceSummary()
            {
                OpenInvoices = data.ContainsKey("unpaid") ? data["unpaid"] : 0,
                ClosedInvoices = data.ContainsKey("paid") ? data["paid"] : 0
            };
        }

        public async Task<CustomerInvoiceDTOGet> MakeInvoiceFromSupplier(MakeCustomerInvoiceDTO makeCustomerInvoiceDTO)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                CustomerInvoice newInvoice = new CustomerInvoice()
                {
                    InvoiceDate = DateTime.Now,
                    StatusID = 6, //unpaid
                    SaleID = makeCustomerInvoiceDTO.SaleID,
                    Status = await _context.Statuses.Where(x => x.StatusID == 6).FirstAsync(),
                    Sale = await _context.Sales.Where(x => x.SaleID == makeCustomerInvoiceDTO.SaleID).FirstAsync(),
                };

                CustomerInvoiceDTOGet createdInvoice = await CreateCustomerInvoice(newInvoice);

                var customerInvoiceCosts = await _context.SupplierInvoiceCosts
                    .Include(x => x.SupplierInvoice)
                    .Include(x => x.CostRegistry)
                    .Where(x => makeCustomerInvoiceDTO.SupplierInvoiceIDs.Contains(x.SupplierInvoice.SupplierInvoiceID))
                    .Select(x => new CustomerInvoiceCost()
                    {
                        Cost = x.Cost,
                        Quantity = x.Quantity,
                        Name = x.Name,
                        CostRegistryID = x.CostRegistryID,
                        CustomerInvoiceID = createdInvoice.CustomerInvoiceId,

                    })
                    .ToListAsync();

                decimal totalCost = 0;

                foreach (var item in customerInvoiceCosts)
                {
                    totalCost += (decimal)item.Cost! * (decimal)item.Quantity!;
                }

                decimal surchargeCost = totalCost / 100 * (decimal)makeCustomerInvoiceDTO.PercentSurcharge! + (decimal)makeCustomerInvoiceDTO.FixedSurcharge!;

                if (surchargeCost > 0)
                {
                    CustomerInvoiceCost surcharge = new CustomerInvoiceCost
                    {
                        Cost = surchargeCost,
                        Quantity = 1,
                        Name = "Surcharge",
                        CostRegistryID = 1, //al momento metto gnc
                        CustomerInvoiceID = createdInvoice.CustomerInvoiceId,
                    };
                    customerInvoiceCosts.Add(surcharge);
                    totalCost += (decimal)surcharge.Cost!;
                }

                _context.CustomerInvoiceCosts.AddRange(customerInvoiceCosts);

                var paid = await _context.CustomerInvoiceAmountPaids.Where(x => x.CustomerInvoiceID == createdInvoice.CustomerInvoiceId).FirstAsync();

                createdInvoice = await UpdateCustomerInvoice((int)createdInvoice.CustomerInvoiceId!, new CustomerInvoice()
                {
                    InvoiceAmount = (decimal)createdInvoice.InvoiceAmount! + totalCost,
                    Status = await _context.Statuses.Where(x => x.StatusID == 6).FirstAsync(),
                    Sale = await _context.Sales.Where(x => x.SaleID == makeCustomerInvoiceDTO.SaleID).FirstAsync(),
                    CustomerInvoiceAmountPaid = paid
                });

                await _context.SaveChangesAsync();

                var supplierInvoiceCosts = await _context.SupplierInvoiceCosts
                   .Include(x => x.SupplierInvoice)
                   .Include(x => x.CostRegistry)
                   .Where(x => makeCustomerInvoiceDTO.SupplierInvoiceIDs.Contains(x.SupplierInvoice.SupplierInvoiceID))
                   .ToListAsync();

                var newCustomerInvoiceCostIDs = await _context.CustomerInvoiceCosts
                    .Where(c => c.CustomerInvoiceID == createdInvoice.CustomerInvoiceId)
                    .Select(x => x.CustomerInvoiceCostsID)
                    .ToListAsync();

                for (int i = 0; i < supplierInvoiceCosts.Count; i++)
                {
                    supplierInvoiceCosts[i].CustomerInvoiceCostID = newCustomerInvoiceCostIDs[i];
                }

                _context.SupplierInvoiceCosts.UpdateRange(supplierInvoiceCosts);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return createdInvoice;

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }


        }

    }
}
