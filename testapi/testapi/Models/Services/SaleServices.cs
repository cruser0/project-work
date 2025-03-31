using API.Models.Exceptions;
using API.Models.Mapper;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Models.Services
{
    public interface ISalesService
    {
        Task<ICollection<SaleCustomerDTO>> GetAllSales(SaleCustomerFilter filter);
        Task<SaleCustomerDTO> GetSaleById(int id);
        Task<SaleDTOGet> CreateSale(Sale sale);
        Task<SaleDTOGet> UpdateSale(int id, Sale sale);
        Task<SaleDTOGet> DeleteSale(int id);

        Task<Sale?> GetOnlySaleById(int id);
        Task<int> CountSales(SaleCustomerFilter filter);
        Task<string> MassDeleteSale(List<int> saleId);
        Task<string> MassUpdateSale(List<SaleDTOGet> newSales);

    }
    public class SaleServices : ISalesService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _ciService;
        private readonly ISupplierInvoiceService _siService;
        private readonly StatusService _statusService;
        List<string> statusList = new() { "active", "closed" };
        public SaleServices(Progetto_FormativoContext ctx, ICustomerInvoicesService CIservice, ISupplierInvoiceService SIservice, StatusService statusService)
        {
            _context = ctx;
            _ciService = CIservice;
            _siService = SIservice;
            _statusService = statusService;

        }

        public async Task<ICollection<SaleCustomerDTO>> GetAllSales(SaleCustomerFilter filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSales(SaleCustomerFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SaleCustomerDTO> ApplyFilter(SaleCustomerFilter filter)
        {
            int itemsPage = 10;
            var query = (from s in _context.Sales.Include(x => x.Status)
                         join c in _context.Customers.Include(x => x.Country) on s.CustomerID equals c.CustomerID into SaleGroup
                         from customer in SaleGroup.DefaultIfEmpty()
                         select new { Sale = s, Customer = customer }).AsQueryable();

            if (!string.IsNullOrEmpty(filter.SaleBookingNumber))
            {
                query = query.Where(s => s.Sale.BookingNumber.StartsWith(filter.SaleBookingNumber));
            }

            if (!string.IsNullOrEmpty(filter.SaleBoLnumber))
            {
                query = query.Where(s => s.Sale.BoLnumber.StartsWith(filter.SaleBoLnumber));
            }

            if (filter.SaleDateFrom != null && filter.SaleDateTo != null)
            {
                if (filter.SaleDateFrom > filter.SaleDateTo)
                {
                    throw new ErrorInputPropertyException("SaleDateFrom cannot be later than SaleDateTo.");
                }

                query = query.Where(s => s.Sale.SaleDate >= filter.SaleDateFrom && s.Sale.SaleDate <= filter.SaleDateTo);
            }
            else if (filter.SaleDateFrom != null)
            {
                query = query.Where(s => s.Sale.SaleDate >= filter.SaleDateFrom);
            }
            else if (filter.SaleDateTo != null)
            {
                query = query.Where(s => s.Sale.SaleDate <= filter.SaleDateTo);
            }

            if (filter.SaleRevenueFrom != null && filter.SaleRevenueTo != null)
            {
                if (filter.SaleRevenueFrom > filter.SaleRevenueTo)
                {
                    throw new ErrorInputPropertyException("RevenueFrom cannot be later than RevenueTo.");
                }

                query = query.Where(s => s.Sale.TotalRevenue >= filter.SaleRevenueFrom && s.Sale.TotalRevenue <= filter.SaleRevenueTo);
            }
            else if (filter.SaleRevenueFrom != null)
            {
                query = query.Where(s => s.Sale.TotalRevenue >= filter.SaleRevenueFrom);
            }
            else if (filter.SaleRevenueTo != null)
            {
                query = query.Where(s => s.Sale.TotalRevenue <= filter.SaleRevenueTo);
            }

            if (!string.IsNullOrEmpty(filter.SaleStatus))
            {
                query = query.Where(s => s.Sale.Status.StatusName == filter.SaleStatus);
            }

            if (!string.IsNullOrEmpty(filter.SaleCustomerName))
            {
                query = query.Where(s => s.Customer.CustomerName.Contains(filter.SaleCustomerName));
            }

            if (!string.IsNullOrEmpty(filter.SaleCustomerCountry))
            {
                query = query.Where(s => s.Customer.Country.CountryName.Contains(filter.SaleCustomerCountry));
            }

            if (filter.SalePage != null)
            {
                query = query.Skip(((int)filter.SalePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => new SaleCustomerDTO(x.Sale, x.Customer));
        }

        public async Task<SaleCustomerDTO> GetSaleById(int id)
        {
            var sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();
            var customer = await _context.Customers.Include(x => x.Country).Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
            var result = new SaleCustomerDTO(sale, customer);

            // Check if the sale exists
            if (result == null || sale == null)
                throw new NotFoundException("Sale not found!");

            return result;
        }

        public async Task<Sale?> GetOnlySaleById(int id)
        {
            var sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();
            return sale;
        }

        public async Task<SaleDTOGet> CreateSale(Sale sale)
        {

            if (!statusList.Contains(sale.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
            if (customers == null)
                throw new NotFoundException($"There is no customer with ID {sale.CustomerID}");
            else if ((bool)customers.Deprecated)
                throw new ErrorInputPropertyException($"The customer {sale.CustomerID} is deprecated");

            sale.TotalRevenue = 0;

            _context.Add(sale);
            await _context.SaveChangesAsync();

            return SaleMapper.MapGet(sale);
        }

        public async Task<SaleDTOGet> UpdateSale(int id, Sale sale)
        {
            var sDB = await _context.Sales.Where(x => x.SaleID == id).FirstOrDefaultAsync();



            sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
            sDB.StatusID = sale.StatusID ?? sDB.StatusID;
            sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
            sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
            sDB.CustomerID = sale.CustomerID ?? sDB.CustomerID;


            if (!string.IsNullOrEmpty(sale.Status.StatusName) && !statusList.Contains(sale.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            if (sale.CustomerID != null)
            {
                var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
                if (customers == null)
                    throw new NotFoundException($"There is no customer with ID {sale.CustomerID}");
                else if ((bool)customers.Deprecated)
                    throw new ErrorInputPropertyException($"The customer {sale.CustomerID} is deprecated");
            }

            _context.Sales.Update(sDB);
            await _context.SaveChangesAsync();

            return SaleMapper.MapGet(sDB);
        }

        public async Task<SaleDTOGet> DeleteSale(int id)
        {
            var data = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();

            bool isInTransaction = _context.Database.CurrentTransaction != null;
            IDbContextTransaction? transaction = null;

            if (!isInTransaction)
            {
                transaction = await _context.Database.BeginTransactionAsync();
            }

            try
            {
                if (data == null)
                    throw new NotFoundException("Sale not found!");
                if (data.Status.StatusName.ToLower().Equals("closed"))
                    throw new ErrorInputPropertyException("Sale is closed,can't delete!");

                var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleID == id).ToListAsync();
                if (customerInvoices.Count > 0)
                {
                    foreach (var invoice in customerInvoices)
                    {
                        await _siService.DeleteSupplierInvoice(invoice.CustomerInvoiceID);
                    }
                }

                var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleID == id).ToListAsync();
                if (supplierInvoices.Count > 0)
                {
                    foreach (var invoice in supplierInvoices)
                    {
                        await _siService.DeleteSupplierInvoice(invoice.SupplierInvoiceID);
                    }
                }

                _context.Sales.Remove(data);
                await _context.SaveChangesAsync();

                if (!isInTransaction && transaction != null)
                {
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                if (!isInTransaction && transaction != null)
                {
                    await transaction.RollbackAsync();
                }

                if (ex is ErrorInputPropertyException)
                    throw;
                else
                    throw new Exception($"Error deleting sale: {ex.Message}", ex);
            }

            return SaleMapper.MapGet(data);
        }


        public async Task<string> MassDeleteSale(List<int> saleId)
        {
            int count = 0;
            foreach (int id in saleId)
            {

                var data = await _context.Sales.Where(x => x.SaleID == id).FirstOrDefaultAsync();

                if (data == null)
                    continue;


                var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleID == id).ToListAsync();
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (customerInvoices.Count > 0)
                    {
                        foreach (var invoice in customerInvoices)
                        {

                            await _siService.DeleteSupplierInvoice(invoice.CustomerInvoiceID);

                        }
                    }

                    var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleID == id).ToListAsync();

                    if (supplierInvoices.Count > 0)
                    {


                        foreach (var invoice in supplierInvoices)
                        {

                            await _siService.DeleteSupplierInvoice(invoice.SupplierInvoiceID);


                        }

                    }
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    continue;
                }

                _context.Sales.Remove(data);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                count++;
            }
            return $"{count} Sales were deleted out of {saleId.Count} ";
        }

        public async Task<string> MassUpdateSale(List<SaleDTOGet> newSales)
        {
            int count = 0;

            foreach (SaleDTOGet sale in newSales)
            {
                var sDB = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == sale.SaleId).FirstOrDefaultAsync();

                if (sDB == null)
                    throw new NotFoundException($"There is no sale with id {sale.SaleId}");

                sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
                sDB.StatusID = (await _statusService.GetStatusByName(sale.Status))?.StatusID ?? sDB.StatusID;
                sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
                sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
                sDB.CustomerID = sale.CustomerId ?? sDB.CustomerID;

                if (sale.BookingNumber != null)
                    if (sale.BookingNumber.Length > 50)
                        throw new ErrorInputPropertyException("Booking Number is too long");

                if (sale.BoLnumber != null)
                    if (sale.BoLnumber.Length > 50)
                        throw new ErrorInputPropertyException("BoL Number is too long");

                string stat = (await _statusService.GetStatusByName(sale.Status)).StatusName;
                if (!string.IsNullOrEmpty(stat) && !statusList.Contains(stat.ToLower()))
                    throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

                if (sale.CustomerId != null)
                {
                    var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerId).FirstOrDefaultAsync();
                    if (customers == null)
                        throw new NotFoundException($"There is no customer with ID {sale.CustomerId}");
                    else if ((bool)customers.Deprecated)
                        throw new ErrorInputPropertyException($"The customer {sale.CustomerId} is deprecated");
                }

                _context.Sales.Update(sDB);
                await _context.SaveChangesAsync();

                count++;
            }

            return $"{count} Sales were updated out of {newSales.Count} ";
        }
    }
}
