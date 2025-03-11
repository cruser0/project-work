using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerInvoicesService
    {
        Task<ICollection<CustomerInvoiceDTOGet>> GetAllCustomerInvoices(CustomerInvoiceFilter filter);
        Task<CustomerInvoiceDTOGet> GetCustomerInvoiceById(int id);
        Task<CustomerInvoiceDTOGet> CreateCustomerInvoice(CustomerInvoice customer);
        Task<CustomerInvoiceDTOGet> UpdateCustomerInvoice(int id, CustomerInvoice customer);
        Task<CustomerInvoiceDTOGet> DeleteCustomerInvoice(int id);
        Task<int> CountCustomerInvoices(CustomerInvoiceFilter filter);
        Task<string> MassDeleteCustomerInvoice(List<int> customerInvoiceId);

        Task<string> MassUpdateCustomerInvoice(List<CustomerInvoiceDTOGet> newCustomerInvoices);

    }
    public class CustomerInvoicesServices : ICustomerInvoicesService
    {
        private readonly Progetto_FormativoContext _context;
        // List of valid invoice statuses
        List<string> statusList = new() { "paid", "unpaid" };
        public CustomerInvoicesServices(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<ICollection<CustomerInvoiceDTOGet>> GetAllCustomerInvoices(CustomerInvoiceFilter filter)
        {
            // Retrieve all customer invoices from the database and map each one to a CustomerInvoiceDTOGet
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountCustomerInvoices(CustomerInvoiceFilter filter)
        {
            // Retrieve all customer invoices from the database and map each one to a CustomerInvoiceDTOGet
            return await ApplyFilter(filter).CountAsync();
        }

        public IQueryable<CustomerInvoiceDTOGet> ApplyFilter(CustomerInvoiceFilter filter)
        {
            int itemsPage = 10;
            // Retrieve all customer invoices from the database and map each one to a CustomerInvoiceDTOGet
            var query = _context.CustomerInvoices.AsQueryable();

            if (filter.CustomerInvoiceSaleId != null)
            {
                query = query.Where(x => x.SaleId == filter.CustomerInvoiceSaleId);
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
                query = query.Where(s => s.Status == filter.CustomerInvoiceStatus);
            }
            if (filter.CustomerInvoicePage != null)
            {
                query = query.Skip(((int)filter.CustomerInvoicePage - 1) * itemsPage).Take(itemsPage);
            }
            return query.Select(x => CustomerInvoiceMapper.MapGet(x));
        }

        public async Task<CustomerInvoiceDTOGet> CreateCustomerInvoice(CustomerInvoice customerInvoice)
        {
            // Check if the customerInvoice parameter is null
            if (customerInvoice == null)
                throw new NullPropertyException("Couldn't create customer invoice,data is null");

            var nullFields = new List<string>();

            // Check if any required fields in the customerInvoice object are null or empty
            if (customerInvoice.SaleId == null) nullFields.Add("SaleID");
            if (customerInvoice.InvoiceDate == null) nullFields.Add("Date");
            if (string.IsNullOrEmpty(customerInvoice.Status)) nullFields.Add("Status");

            // If any fields are null, throw an exception with the list of missing fields
            if (nullFields.Any())
                throw new ErrorInputPropertyException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");
            // Check if the provided status is valid
            if (!statusList.Contains(customerInvoice.Status.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");
            // Check if a sale exists with the provided SaleId
            var sale = await _context.Sales.Where(x => x.SaleId == customerInvoice.SaleId).FirstOrDefaultAsync();
            if (sale == null)
                throw new NotFoundException($"There is no sale with id {customerInvoice.SaleId}");
            if (sale.Status.ToLower().Equals("closed"))
                throw new ErrorInputPropertyException($"The Sale is already closed");

            customerInvoice.InvoiceAmount = 0;
            // Add the customerInvoice to the database and save the changes
            _context.Add(customerInvoice);
            await _context.SaveChangesAsync();

            // Calculate the total revenue for the sale using a stored procedure
            var Total = (await _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{customerInvoice.SaleId}\"").ToListAsync()).FirstOrDefault()?.TotalRevenue;

            // Update the sale record with the new total revenue
            sale.TotalRevenue = Total;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            // Map the customerInvoice to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(customerInvoice);
        }

        public async Task<CustomerInvoiceDTOGet> UpdateCustomerInvoice(int id, CustomerInvoice customerInvoice)
        {
            // Retrieve the existing customer invoice from the database
            var ciDB = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefaultAsync();

            // Check if the customer invoice exists
            if (ciDB == null)
                throw new NotFoundException("Customer invoice not found");

            // Store the old SaleId before updating (used to recalculate revenue later)
            int? oldSaleId = ciDB.SaleId;

            // Update customer invoice fields only if a new one is provided
            ciDB.SaleId = customerInvoice.SaleId ?? ciDB.SaleId;
            if (!await _context.Sales.Where(x => x.SaleId == customerInvoice.SaleId).AnyAsync())
                throw new NotFoundException("SaleId not found");
            if (!await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).AnyAsync())
                throw new NotFoundException("Old SaleId not found");
            ciDB.InvoiceAmount = customerInvoice.InvoiceAmount ?? ciDB.InvoiceAmount;
            ciDB.InvoiceDate = customerInvoice.InvoiceDate ?? ciDB.InvoiceDate;
            ciDB.Status = customerInvoice.Status ?? ciDB.Status;

            // Check if the provided status is valid
            if (!string.IsNullOrEmpty(customerInvoice.Status) && !statusList.Contains(customerInvoice.Status.ToLower()))
                throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");
            Sale sale = await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).FirstAsync();
            if (sale.Status.ToLower().Equals("closed"))
                throw new ErrorInputPropertyException($"The current Sale is already closed");
            // Validate that the invoice amount is greater than zero
            if (customerInvoice.InvoiceAmount <= 0)
                throw new ErrorInputPropertyException("The amount can't be less or equal than 0");

            // Update the invoice in the database
            _context.CustomerInvoices.Update(ciDB);
            await _context.SaveChangesAsync();

            // If the sale ID was modified, update revenue calculations for the old and new sales
            if (oldSaleId.HasValue)
            {
                // Recalculate revenue for the old sale
                var newSale = await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).FirstOrDefaultAsync();
                if (newSale.Status.ToLower().Equals("closed"))
                    throw new ErrorInputPropertyException($"The current Sale is already closed");
                var TotalOldSale = (await _context.RevenuePerSaleIDs
                    .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{oldSaleId.Value}\"")
                    .FirstOrDefaultAsync())?.TotalRevenue;

                var oldSale = await _context.Sales.Where(x => x.SaleId == oldSaleId.Value).FirstOrDefaultAsync();
                oldSale.TotalRevenue = TotalOldSale;

                // Recalculate revenue for the new sale
                var TotalNewSale = (await _context.RevenuePerSaleIDs
                    .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{ciDB.SaleId}\"")
                    .FirstOrDefaultAsync())?.TotalRevenue;

                newSale.TotalRevenue = TotalNewSale;

                // Update the sales in the database
                _context.Sales.Update(oldSale);
                _context.Sales.Update(newSale);
                await _context.SaveChangesAsync();
            }

            // Return the updated customer invoice mapped to DTO
            return CustomerInvoiceMapper.MapGet(ciDB);
        }

        public async Task<CustomerInvoiceDTOGet> DeleteCustomerInvoice(int id)
        {
            // Retrieve the customer invoice from the database using the provided ID

            CustomerInvoice? data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefaultAsync();
            // Check if the customer invoice exists
            if (data == null)
                throw new NotFoundException("Customer invoice not found!");
            Sale? sale = await _context.Sales.Where(x => x.SaleId == data.SaleId).FirstOrDefaultAsync();
            if (sale == null)
                throw new NotFoundException("Sale not found!");

            if (sale.Status.ToLower().Equals("closed"))
                throw new ErrorInputPropertyException("Sale is closed,can't delete!");
            sale.TotalRevenue -= data.InvoiceAmount;
            List<CustomerInvoiceCost> listInvoiceCost = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceId == id).ToListAsync();
            if (listInvoiceCost.Count > 0)
            {
                _context.CustomerInvoiceCosts.RemoveRange(listInvoiceCost);
            }

            // Remove the customer invoice from the database
            _context.CustomerInvoices.Remove(data);
            _context.Sales.Update(sale);
            // Save the changes to commit the deletion
            await _context.SaveChangesAsync();

            // Map the deleted customer invoice to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(data);
        }

        public async Task<string> MassDeleteCustomerInvoice(List<int> customerInvoiceId)
        {
            int count = 0;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                // Retrieve the customer invoice from the database using the provided ID
                foreach (int id in customerInvoiceId)
                {
                    CustomerInvoice? data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefaultAsync();
                    // Check if the customer invoice exists
                    if (data == null)
                        throw new NotFoundException("Customer invoice not found!");
                    Sale? sale = await _context.Sales.Where(x => x.SaleId == data.SaleId).FirstOrDefaultAsync();
                    if (sale == null)
                        throw new NotFoundException("Sale not found!");

                    if (sale.Status.ToLower().Equals("closed"))
                        throw new ErrorInputPropertyException("Sale is closed,can't delete!");
                    sale.TotalRevenue -= data.InvoiceAmount;
                    List<CustomerInvoiceCost> listInvoiceCost = await _context.CustomerInvoiceCosts.Where(x => x.CustomerInvoiceId == id).ToListAsync();
                    if (listInvoiceCost.Count > 0)
                    {
                        _context.CustomerInvoiceCosts.RemoveRange(listInvoiceCost);
                    }

                    // Remove the customer invoice from the database
                    _context.CustomerInvoices.Remove(data);
                    _context.Sales.Update(sale);
                    // Save the changes to commit the deletion
                    await _context.SaveChangesAsync();

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
            // Map the deleted customer invoice to a DTO and return the result
            return $"{count} Customer Invoices deleted out of {customerInvoiceId.Count}";
        }
        public async Task<CustomerInvoiceDTOGet> GetCustomerInvoiceById(int id)
        {
            // Retrieve the customer invoice from the database using the provided ID
            var data = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefaultAsync();

            // Check if the customer invoice exists
            if (data == null)
                throw new NotFoundException("Customer invoice not found!");

            // Map the customer invoice entity to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(data);
        }

        public async Task<string> MassUpdateCustomerInvoice(List<CustomerInvoiceDTOGet> newCustomerInvoices)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (CustomerInvoiceDTOGet customerInvoice in newCustomerInvoices)
                {
                    var ciDB = await _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == customerInvoice.CustomerInvoiceId).FirstOrDefaultAsync();

                    // Check if the customer invoice exists
                    if (ciDB == null)
                        throw new NotFoundException("Customer invoice not found");

                    // Store the old SaleId before updating (used to recalculate revenue later)
                    int? oldSaleId = ciDB.SaleId;

                    // Update customer invoice fields only if a new one is provided
                    ciDB.SaleId = customerInvoice.SaleId ?? ciDB.SaleId;
                    if (!await _context.Sales.Where(x => x.SaleId == customerInvoice.SaleId).AnyAsync())
                        throw new NotFoundException("SaleId not found");
                    if (!await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).AnyAsync())
                        throw new NotFoundException("Old SaleId not found");
                    ciDB.InvoiceAmount = customerInvoice.InvoiceAmount ?? ciDB.InvoiceAmount;
                    ciDB.InvoiceDate = customerInvoice.InvoiceDate ?? ciDB.InvoiceDate;
                    ciDB.Status = customerInvoice.Status ?? ciDB.Status;

                    // Check if the provided status is valid
                    if (!string.IsNullOrEmpty(customerInvoice.Status) && !statusList.Contains(customerInvoice.Status.ToLower()))
                        throw new ErrorInputPropertyException("Incorrect status\nA customer invoice is Paid or Unpaid");
                    Sale sale = await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).FirstAsync();
                    if (sale.Status.ToLower().Equals("closed"))
                        throw new ErrorInputPropertyException($"The current Sale is already closed");
                    // Validate that the invoice amount is greater than zero
                    if (customerInvoice.InvoiceAmount <= 0)
                        throw new ErrorInputPropertyException("The amount can't be less or equal than 0");

                    // Update the invoice in the database
                    _context.CustomerInvoices.Update(ciDB);
                    await _context.SaveChangesAsync();

                    // If the sale ID was modified, update revenue calculations for the old and new sales
                    if (oldSaleId.HasValue)
                    {
                        // Recalculate revenue for the old sale
                        var newSale = await _context.Sales.Where(x => x.SaleId == ciDB.SaleId).FirstOrDefaultAsync();
                        if (newSale.Status.ToLower().Equals("closed"))
                            throw new ErrorInputPropertyException($"The current Sale is already closed");

                        var OldSale = _context.RevenuePerSaleIDs
                            .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{oldSaleId.Value}\"")
                            .AsEnumerable()
                            .FirstOrDefault();

                        var TotalOldSale = OldSale.TotalRevenue;

                        var oldSale = await _context.Sales.Where(x => x.SaleId == oldSaleId.Value).FirstOrDefaultAsync();
                        oldSale.TotalRevenue = TotalOldSale;

                        // Recalculate revenue for the new sale
                        var TotalNewSale = _context.RevenuePerSaleIDs
                            .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{ciDB.SaleId}\"")
                            .AsEnumerable()
                            .FirstOrDefault()?.TotalRevenue;

                        newSale.TotalRevenue = TotalNewSale;

                        // Update the sales in the database
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

    }
}
