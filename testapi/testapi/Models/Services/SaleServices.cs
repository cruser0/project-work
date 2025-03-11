using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ISalesService
    {
        Task<ICollection<SaleCustomerDTO>> GetAllSales(SaleFilter filter);
        Task<SaleCustomerDTO> GetSaleById(int id);
        Task<SaleDTOGet> CreateSale(Sale sale);
        Task<SaleDTOGet> UpdateSale(int id, Sale sale);
        Task<SaleDTOGet> DeleteSale(int id);

        Task<int> CountSales(SaleFilter filter);
        Task<string> MassDeleteSale(List<int> saleId);
        Task<string> MassUpdateSale(List<SaleDTOGet> newSales);

    }
    public class SaleServices : ISalesService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _ciService;
        private readonly ISupplierInvoiceService _siService;
        // List of valid sale statuses
        List<string> statusList = new() { "active", "closed" };
        public SaleServices(Progetto_FormativoContext ctx, ICustomerInvoicesService CIservice, ISupplierInvoiceService SIservice)
        {
            _context = ctx;
            _ciService = CIservice;
            _siService = SIservice;
        }

        public async Task<ICollection<SaleCustomerDTO>> GetAllSales(SaleFilter filter)
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSales(SaleFilter filter)
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<SaleCustomerDTO> ApplyFilter(SaleFilter filter)
        {
            int itemsPage = 10;
            var query = (from s in _context.Sales
                         join c in _context.Customers on s.CustomerId equals c.CustomerId into SaleGroup
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
            else if (filter.SaleRevenueFrom != null)
            {
                query = query.Where(s => s.Sale.TotalRevenue >= filter.SaleRevenueFrom);
            }
            else if (filter.SaleRevenueTo != null)
            {
                query = query.Where(s => s.Sale.TotalRevenue <= filter.SaleRevenueTo);
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

            if (filter.SaleCustomerId != null)
            {
                query = query.Where(s => s.Sale.CustomerId == filter.SaleCustomerId);
            }

            if (!string.IsNullOrEmpty(filter.SaleStatus))
            {
                query = query.Where(s => s.Sale.Status == filter.SaleStatus);
            }
            if (filter.SalePage != null)
            {
                query = query.Skip(((int)filter.SalePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => new SaleCustomerDTO(x.Sale, x.Customer));
        }

        public async Task<SaleCustomerDTO> GetSaleById(int id)
        {
            // Retrieve the sale from the database using the provided ID
            var sale = await _context.Sales.Where(x => x.SaleId == id).FirstOrDefaultAsync();
            var customer = await _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefaultAsync();
            var result = new SaleCustomerDTO(sale, customer);

            // Check if the sale exists
            if (result == null || sale == null)
                throw new NotFoundException("Sale not found!");

            // Map the sale entity to a DTO and return the result
            return result;
        }

        public async Task<SaleDTOGet> CreateSale(Sale sale)
        {
            // Check if the sale parameter is null
            if (sale == null)
                throw new NullPropertyException("Couldn't create sale");

            var nullFields = new List<string>();

            // Check if any required fields in the sale object are null or empty
            if (string.IsNullOrEmpty(sale.BookingNumber)) nullFields.Add("BN");
            if (string.IsNullOrEmpty(sale.BoLnumber)) nullFields.Add("BOL");
            if (sale.SaleDate == null) nullFields.Add("Date");
            if (sale.CustomerId == null) nullFields.Add("CustomerID");
            if (string.IsNullOrEmpty(sale.Status)) nullFields.Add("Status");

            // If any fields are null, throw an exception with the list of missing fields
            if (nullFields.Any())
                throw new NullPropertyException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            if (sale.BookingNumber.Length > 50)
                throw new ErrorInputPropertyException("Booking Number is too long");

            if (sale.BoLnumber.Length > 50)
                throw new ErrorInputPropertyException("BoL Number is too long");

            // Check if the provided status is valid
            if (!statusList.Contains(sale.Status.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            // Check if a customer exists with the provided CustomerId
            var customers = await _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefaultAsync();
            if (customers == null)
                throw new NotFoundException($"There is no customer with ID {sale.CustomerId}");
            else if ((bool)customers.Deprecated)
                throw new ErrorInputPropertyException($"The customer {sale.CustomerId} is deprecated");

            // Set the initial TotalRevenue to 0
            sale.TotalRevenue = 0;

            // Add the sale to the database and save the changes
            _context.Add(sale);
            await _context.SaveChangesAsync();

            // Map the sale to a DTO and return the result
            return SaleMapper.MapGet(sale);
        }

        public async Task<SaleDTOGet> UpdateSale(int id, Sale sale)
        {
            // Retrieve the existing sale from the database
            var sDB = await _context.Sales.Where(x => x.SaleId == id).FirstOrDefaultAsync();

            // Check if the sale exists
            if (sDB == null)
                throw new NotFoundException($"There is no sale with id {id}");

            // Update sale fields only if new values are provided
            sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
            sDB.Status = sale.Status ?? sDB.Status;
            sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
            sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
            sDB.CustomerId = sale.CustomerId ?? sDB.CustomerId;

            if (sale.BookingNumber != null)
                if (sale.BookingNumber.Length > 50)
                    throw new ErrorInputPropertyException("Booking Number is too long");

            if (sale.BoLnumber != null)
                if (sale.BoLnumber.Length > 50)
                    throw new ErrorInputPropertyException("BoL Number is too long");

            // Check if the provided status is valid
            if (!string.IsNullOrEmpty(sale.Status) && !statusList.Contains(sale.Status.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            // If a new CustomerId is provided, check if the customer exists
            if (sale.CustomerId != null)
            {
                var customers = await _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefaultAsync();
                if (customers == null)
                    throw new NotFoundException($"There is no customer with ID {sale.CustomerId}");
                else if ((bool)customers.Deprecated)
                    throw new ErrorInputPropertyException($"The customer {sale.CustomerId} is deprecated");
            }

            // Update the sale in the database
            _context.Sales.Update(sDB);
            await _context.SaveChangesAsync();

            // Return the updated sale mapped to DTO
            return SaleMapper.MapGet(sDB);
        }

        public async Task<SaleDTOGet> DeleteSale(int id)
        {
            // Retrieve the sale from the database using the provided ID
            var data = await _context.Sales.Where(x => x.SaleId == id).FirstOrDefaultAsync();

            // Check if the sale exists
            if (data == null)
                throw new NotFoundException("Sale not found!");


            // Retrieve all customer invoices associated with the sale
            var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleId == id).ToListAsync();

            // If there are any customer invoices, delete them
            if (customerInvoices.Count > 0)
                foreach (var invoice in customerInvoices)
                    await _ciService.DeleteCustomerInvoice(invoice.CustomerInvoiceId);

            // Retrieve all supplier invoices associated with the sale
            var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleId == id).ToListAsync();

            // If there are any supplier invoices, delete them
            if (supplierInvoices.Count > 0)
                foreach (var invoice in supplierInvoices)
                    await _siService.DeleteSupplierInvoice(invoice.InvoiceId);

            // Remove the sale from the database
            _context.Sales.Remove(data);

            // Save the changes to commit the deletion
            await _context.SaveChangesAsync();

            // Map the deleted sale to a DTO and return the result
            return SaleMapper.MapGet(data);
        }


        public async Task<string> MassDeleteSale(List<int> saleId)
        {
            int count = 0;
            foreach (int id in saleId)
            {

                // Retrieve the sale from the database using the provided ID
                var data = await _context.Sales.Where(x => x.SaleId == id).FirstOrDefaultAsync();

                // Check if the sale exists
                if (data == null)
                    continue;


                // Retrieve all customer invoices associated with the sale
                var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleId == id).ToListAsync();

                // If there are any customer invoices, delete them
                if (customerInvoices.Count > 0)
                    foreach (var invoice in customerInvoices)
                        await _ciService.DeleteCustomerInvoice(invoice.CustomerInvoiceId);

                // Retrieve all supplier invoices associated with the sale
                var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleId == id).ToListAsync();

                // If there are any supplier invoices, delete them
                if (supplierInvoices.Count > 0)
                    foreach (var invoice in supplierInvoices)
                        await _siService.DeleteSupplierInvoice(invoice.InvoiceId);

                // Remove the sale from the database
                _context.Sales.Remove(data);

                // Save the changes to commit the deletion
                await _context.SaveChangesAsync();
                count++;
            }
            // Map the deleted sale to a DTO and return the result
            return $"{count} Sales were deleted out of {saleId.Count} ";
        }

        public async Task<string> MassUpdateSale(List<SaleDTOGet> newSales)
        {
            int count = 0;

            foreach (SaleDTOGet sale in newSales)
            {
                var sDB = await _context.Sales.Where(x => x.SaleId == sale.SaleId).FirstOrDefaultAsync();

                // Check if the sale exists
                if (sDB == null)
                    throw new NotFoundException($"There is no sale with id {sale.SaleId}");

                // Update sale fields only if new values are provided
                sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
                sDB.Status = sale.Status ?? sDB.Status;
                sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
                sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
                sDB.CustomerId = sale.CustomerId ?? sDB.CustomerId;

                if (sale.BookingNumber != null)
                    if (sale.BookingNumber.Length > 50)
                        throw new ErrorInputPropertyException("Booking Number is too long");

                if (sale.BoLnumber != null)
                    if (sale.BoLnumber.Length > 50)
                        throw new ErrorInputPropertyException("BoL Number is too long");

                // Check if the provided status is valid
                if (!string.IsNullOrEmpty(sale.Status) && !statusList.Contains(sale.Status.ToLower()))
                    throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

                // If a new CustomerId is provided, check if the customer exists
                if (sale.CustomerId != null)
                {
                    var customers = await _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefaultAsync();
                    if (customers == null)
                        throw new NotFoundException($"There is no customer with ID {sale.CustomerId}");
                    else if ((bool)customers.Deprecated)
                        throw new ErrorInputPropertyException($"The customer {sale.CustomerId} is deprecated");
                }

                // Update the sale in the database
                _context.Sales.Update(sDB);
                await _context.SaveChangesAsync();

                count++;
            }

            return $"{count} Sales were updated out of {newSales.Count} ";
        }
    }
}
