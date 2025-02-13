using API.Models.DTO;
using API.Models.Entities;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerInvoicesService
    {
        ICollection<CustomerInvoiceDTOGet> GetAllCustomerInvoices();
        CustomerInvoiceDTOGet GetCustomerInvoiceById(int id);
        CustomerInvoiceDTOGet CreateCustomerInvoice(CustomerInvoice customer);
        CustomerInvoiceDTOGet UpdateCustomerInvoice(int id, CustomerInvoice customer);
        CustomerInvoiceDTOGet DeleteCustomerInvoice(int id);


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

        public ICollection<CustomerInvoiceDTOGet> GetAllCustomerInvoices()
        {
            // Retrieve all customer invoices from the database and map each one to a CustomerInvoiceDTOGet
            return _context.CustomerInvoices
                           .Select(x => CustomerInvoiceMapper.MapGet(x))
                           .ToList();
        }

        public CustomerInvoiceDTOGet CreateCustomerInvoice(CustomerInvoice customerInvoice)
        {
            // Check if the customerInvoice parameter is null
            if (customerInvoice == null)
                throw new ArgumentNullException("Couldn't create customer invoice");

            var nullFields = new List<string>();

            // Check if any required fields in the customerInvoice object are null or empty
            if (customerInvoice.SaleId == null) nullFields.Add("SaleID");
            if (customerInvoice.InvoiceAmount == null) nullFields.Add("InvoiceAmount");
            if (customerInvoice.InvoiceDate == null) nullFields.Add("Date");
            if (string.IsNullOrEmpty(customerInvoice.Status)) nullFields.Add("Status");

            // If any fields are null, throw an exception with the list of missing fields
            if (nullFields.Any())
                throw new ArgumentException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            // Check if the invoice amount is less than or equal to 0
            if (customerInvoice.InvoiceAmount <= 0)
                throw new ArgumentException("The amount can't be less or equal than 0");

            // Check if the provided status is valid
            if (!statusList.Contains(customerInvoice.Status.ToLower()))
                throw new ArgumentException("Incorrect status\nA customer invoice is Paid or Unpaid");

            // Check if a sale exists with the provided SaleId
            var sale = _context.Sales.Where(x => x.SaleId == customerInvoice.SaleId).FirstOrDefault();
            if (sale == null)
                throw new ArgumentException($"There is no sale with id {customerInvoice.SaleId}");

            // Add the customerInvoice to the database and save the changes
            _context.Add(customerInvoice);
            _context.SaveChanges();

            // Calculate the total revenue for the sale using a stored procedure
            var Total = _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{customerInvoice.SaleId}\"").ToList().FirstOrDefault()?.TotalRevenue;

            // Update the sale record with the new total revenue
            sale.TotalRevenue = Total;
            _context.Sales.Update(sale);
            _context.SaveChanges();

            // Map the customerInvoice to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(customerInvoice);
        }

        public CustomerInvoiceDTOGet UpdateCustomerInvoice(int id, CustomerInvoice customerInvoice)
        {
            // Retrieve the existing customer invoice from the database
            var ciDB = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefault();

            // Check if the customer invoice exists
            if (ciDB == null)
                throw new ArgumentNullException("Customer invoice not found");

            // Store the old SaleId before updating (used to recalculate revenue later)
            int? oldSaleId = ciDB.SaleId;

            // Update customer invoice fields only if a new one is provided
            ciDB.SaleId = customerInvoice.SaleId ?? ciDB.SaleId;
            if (!_context.Sales.Where(x => x.SaleId == customerInvoice.SaleId).Any())
                throw new ArgumentException("SaleId not found");
            ciDB.InvoiceAmount = customerInvoice.InvoiceAmount ?? ciDB.InvoiceAmount;
            ciDB.InvoiceDate = customerInvoice.InvoiceDate ?? ciDB.InvoiceDate;
            ciDB.Status = customerInvoice.Status ?? ciDB.Status;

            // Check if the provided status is valid
            if (!string.IsNullOrEmpty(customerInvoice.Status) && !statusList.Contains(customerInvoice.Status.ToLower()))
                throw new ArgumentException("Incorrect status\nA customer invoice is Paid or Unpaid");

            // Validate that the invoice amount is greater than zero
            if (customerInvoice.InvoiceAmount <= 0)
                throw new ArgumentException("The amount can't be less or equal than 0");

            // Update the invoice in the database
            _context.CustomerInvoices.Update(ciDB);
            _context.SaveChanges();

            // If the sale ID was modified, update revenue calculations for the old and new sales
            if (oldSaleId.HasValue)
            {
                // Recalculate revenue for the old sale
                var TotalOldSale = _context.RevenuePerSaleIDs
                    .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{oldSaleId.Value}\"")
                    .ToList()
                    .FirstOrDefault()?.TotalRevenue;

                var oldSale = _context.Sales.Where(x => x.SaleId == oldSaleId.Value).FirstOrDefault();
                oldSale.TotalRevenue = TotalOldSale;

                // Recalculate revenue for the new sale
                var TotalNewSale = _context.RevenuePerSaleIDs
                    .FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{ciDB.SaleId}\"")
                    .ToList()
                    .FirstOrDefault()?.TotalRevenue;

                var newSale = _context.Sales.Where(x => x.SaleId == ciDB.SaleId).FirstOrDefault();
                newSale.TotalRevenue = TotalNewSale;

                // Update the sales in the database
                _context.Sales.Update(oldSale);
                _context.Sales.Update(newSale);
                _context.SaveChanges();
            }

            // Return the updated customer invoice mapped to DTO
            return CustomerInvoiceMapper.MapGet(ciDB);
        }

        public CustomerInvoiceDTOGet DeleteCustomerInvoice(int id)
        {
            // Retrieve the customer invoice from the database using the provided ID
            var data = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefault();

            // Check if the customer invoice exists
            if (data == null)
                throw new ArgumentNullException("Customer invoice not found!");

            // Remove the customer invoice from the database
            _context.CustomerInvoices.Remove(data);

            // Save the changes to commit the deletion
            _context.SaveChanges();

            // Map the deleted customer invoice to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(data);
        }

        public CustomerInvoiceDTOGet GetCustomerInvoiceById(int id)
        {
            // Retrieve the customer invoice from the database using the provided ID
            var data = _context.CustomerInvoices.Where(x => x.CustomerInvoiceId == id).FirstOrDefault();

            // Check if the customer invoice exists
            if (data == null)
                throw new ArgumentException("Customer invoice not found!");

            // Map the customer invoice entity to a DTO and return the result
            return CustomerInvoiceMapper.MapGet(data);
        }

    }
}
