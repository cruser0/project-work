﻿using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
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
        // List of valid sale statuses
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
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountSales(SaleCustomerFilter filter)
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
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
            // Retrieve the sale from the database using the provided ID
            var sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();
            var customer = await _context.Customers.Include(x => x.Country).Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
            var result = new SaleCustomerDTO(sale, customer);

            // Check if the sale exists
            if (result == null || sale == null)
                throw new NotFoundException("Sale not found!");

            // Map the sale entity to a DTO and return the result
            return result;
        }

        public async Task<Sale?> GetOnlySaleById(int id)
        {
            // Retrieve the sale from the database using the provided ID
            var sale = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();
            return sale;
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
            if (sale.CustomerID == null) nullFields.Add("CustomerID");
            if (string.IsNullOrEmpty(sale.Status.StatusName)) nullFields.Add("Status");

            // If any fields are null, throw an exception with the list of missing fields
            if (nullFields.Any())
                throw new NullPropertyException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            if (sale.BookingNumber.Length > 50)
                throw new ErrorInputPropertyException("Booking Number is too long");

            if (sale.BoLnumber.Length > 50)
                throw new ErrorInputPropertyException("BoL Number is too long");

            // Check if the provided status is valid
            if (!statusList.Contains(sale.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            // Check if a customer exists with the provided CustomerId
            var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
            if (customers == null)
                throw new NotFoundException($"There is no customer with ID {sale.CustomerID}");
            else if ((bool)customers.Deprecated)
                throw new ErrorInputPropertyException($"The customer {sale.CustomerID} is deprecated");

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
            var sDB = await _context.Sales.Where(x => x.SaleID == id).FirstOrDefaultAsync();

            // Check if the sale exists
            if (sDB == null)
                throw new NotFoundException($"There is no sale with id {id}");

            // Update sale fields only if new values are provided
            sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
            sDB.StatusID = sale.StatusID ?? sDB.StatusID;
            sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
            sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
            sDB.CustomerID = sale.CustomerID ?? sDB.CustomerID;

            if (sale.BookingNumber != null)
                if (sale.BookingNumber.Length > 50)
                    throw new ErrorInputPropertyException("Booking Number is too long");

            if (sale.BoLnumber != null)
                if (sale.BoLnumber.Length > 50)
                    throw new ErrorInputPropertyException("BoL Number is too long");

            // Check if the provided status is valid
            if (!string.IsNullOrEmpty(sale.Status.StatusName) && !statusList.Contains(sale.Status.StatusName.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

            // If a new CustomerId is provided, check if the customer exists
            if (sale.CustomerID != null)
            {
                var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerID).FirstOrDefaultAsync();
                if (customers == null)
                    throw new NotFoundException($"There is no customer with ID {sale.CustomerID}");
                else if ((bool)customers.Deprecated)
                    throw new ErrorInputPropertyException($"The customer {sale.CustomerID} is deprecated");
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
            var data = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == id).FirstOrDefaultAsync();

            // Check if we're already in a transaction
            bool isInTransaction = _context.Database.CurrentTransaction != null;
            IDbContextTransaction? transaction = null;

            if (!isInTransaction)
            {
                transaction = await _context.Database.BeginTransactionAsync();
            }

            try
            {
                // Check if the sale exists
                if (data == null)
                    throw new NotFoundException("Sale not found!");
                if (data.Status.StatusName.ToLower().Equals("closed"))
                    throw new ErrorInputPropertyException("Sale is closed,can't delete!");

                // Retrieve all customer invoices associated with the sale
                var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleID == id).ToListAsync();
                // If there are any customer invoices, delete them
                if (customerInvoices.Count > 0)
                {
                    foreach (var invoice in customerInvoices)
                    {
                        await _siService.DeleteSupplierInvoice(invoice.CustomerInvoiceID);
                    }
                }

                // Retrieve all supplier invoices associated with the sale
                var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleID == id).ToListAsync();
                // If there are any supplier invoices, delete them
                if (supplierInvoices.Count > 0)
                {
                    foreach (var invoice in supplierInvoices)
                    {
                        await _siService.DeleteSupplierInvoice(invoice.SupplierInvoiceID);
                    }
                }

                // Remove the sale from the database
                _context.Sales.Remove(data);
                // Save the changes to commit the deletion
                await _context.SaveChangesAsync();

                // Only commit if we started the transaction
                if (!isInTransaction && transaction != null)
                {
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                // Only rollback if we started the transaction
                if (!isInTransaction && transaction != null)
                {
                    await transaction.RollbackAsync();
                }

                if (ex is ErrorInputPropertyException)
                    throw;
                else
                    throw new Exception($"Error deleting sale: {ex.Message}", ex);
            }

            // Map the deleted sale to a DTO and return the result
            return SaleMapper.MapGet(data);
        }


        public async Task<string> MassDeleteSale(List<int> saleId)
        {
            int count = 0;
            foreach (int id in saleId)
            {

                // Retrieve the sale from the database using the provided ID
                var data = await _context.Sales.Where(x => x.SaleID == id).FirstOrDefaultAsync();

                // Check if the sale exists
                if (data == null)
                    continue;


                // Retrieve all customer invoices associated with the sale
                var customerInvoices = await _context.CustomerInvoices.Where(x => x.SaleID == id).ToListAsync();
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // If there are any customer invoices, delete them
                    if (customerInvoices.Count > 0)
                    {
                        foreach (var invoice in customerInvoices)
                        {

                            await _siService.DeleteSupplierInvoice(invoice.CustomerInvoiceID);

                        }
                    }

                    // Retrieve all supplier invoices associated with the sale
                    var supplierInvoices = await _context.SupplierInvoices.Where(x => x.SaleID == id).ToListAsync();

                    // If there are any supplier invoices, delete them
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

                // Remove the sale from the database
                _context.Sales.Remove(data);

                // Save the changes to commit the deletion
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
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
                var sDB = await _context.Sales.Include(x => x.Status).Where(x => x.SaleID == sale.SaleId).FirstOrDefaultAsync();

                // Check if the sale exists
                if (sDB == null)
                    throw new NotFoundException($"There is no sale with id {sale.SaleId}");

                // Update sale fields only if new values are provided
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

                // Check if the provided status is valid
                string stat = (await _statusService.GetStatusByName(sale.Status)).StatusName;
                if (!string.IsNullOrEmpty(stat) && !statusList.Contains(stat.ToLower()))
                    throw new ErrorInputPropertyException("Incorrect status\nA sale is Active or Closed");

                // If a new CustomerId is provided, check if the customer exists
                if (sale.CustomerId != null)
                {
                    var customers = await _context.Customers.Where(x => x.CustomerID == sale.CustomerId).FirstOrDefaultAsync();
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
