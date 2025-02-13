using API.Models.DTO;
using API.Models.Entities;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ISalesService
    {
        ICollection<SaleDTOGet> GetAllSales();
        SaleDTOGet GetSaleById(int id);
        SaleDTOGet CreateSale(Sale sale);
        SaleDTOGet UpdateSale(int id, Sale sale);
        SaleDTOGet DeleteSale(int id);


    }
    public class SaleServices : ISalesService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ICustomerInvoicesService _ciRepo;
        private readonly ISupplierInvoiceService _siRepo;
        // List of valid sale statuses
        List<string> statusList = new() { "active", "closed" };
        public SaleServices(Progetto_FormativoContext ctx, ICustomerInvoicesService CIrepo, ISupplierInvoiceService SIrepo)
        {
            _context = ctx;
            _ciRepo = CIrepo;
            _siRepo = SIrepo;
        }

        public SaleDTOGet CreateSale(Sale sale)
        {
            // Check if the sale parameter is null
            if (sale == null)
                throw new ArgumentException("Couldn't create sale");

            var nullFields = new List<string>();

            // Check if any required fields in the sale object are null or empty
            if (string.IsNullOrEmpty(sale.BookingNumber)) nullFields.Add("BN");
            if (string.IsNullOrEmpty(sale.BoLnumber)) nullFields.Add("BOL");
            if (sale.SaleDate == null) nullFields.Add("Date");
            if (sale.CustomerId == null) nullFields.Add("CustomerID");
            if (string.IsNullOrEmpty(sale.Status)) nullFields.Add("Status");

            // If any fields are null, throw an exception with the list of missing fields
            if (nullFields.Any())
                throw new ArgumentException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            // Check if the provided status is valid
            if (!statusList.Contains(sale.Status.ToLower()))
                throw new ArgumentException("Incorrect status\nA sale is Active or Closed");

            // Check if a customer exists with the provided CustomerId
            var customers = _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefault();
            if (customers == null)
                throw new ArgumentException($"There is no customer with ID {sale.CustomerId}");

            // Set the initial TotalRevenue to 0
            sale.TotalRevenue = 0;

            // Add the sale to the database and save the changes
            _context.Add(sale);
            _context.SaveChanges();

            // Map the sale to a DTO and return the result
            return SaleMapper.MapGet(sale);
        }


        public SaleDTOGet DeleteSale(int id)
        {
            // Retrieve the sale from the database using the provided ID
            var data = _context.Sales.Where(x => x.SaleId == id).FirstOrDefault();

            // Check if the sale exists
            if (data == null)
                throw new ArgumentException("Sale not found!");


            // Retrieve all customer invoices associated with the sale
            var customerInvoices = _context.CustomerInvoices.Where(x => x.SaleId == id).ToList();

            // If there are any customer invoices, delete them
            if (customerInvoices.Count > 0)
                foreach (var invoice in customerInvoices)
                    _ciRepo.DeleteCustomerInvoice(invoice.CustomerInvoiceId);

            // Retrieve all supplier invoices associated with the sale
            var supplierInvoices = _context.SupplierInvoices.Where(x => x.SaleId == id).ToList();

            // If there are any supplier invoices, delete them
            if (supplierInvoices.Count > 0)
                foreach (var invoice in supplierInvoices)
                    _siRepo.DeleteSupplierInvoice(invoice.InvoiceId);

            // Remove the sale from the database
            _context.Sales.Remove(data);

            // Save the changes to commit the deletion
            _context.SaveChanges();

            // Map the deleted sale to a DTO and return the result
            return SaleMapper.MapGet(data);
        }


        public ICollection<SaleDTOGet> GetAllSales()
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return _context.Sales
                           .Select(s => SaleMapper.MapGet(s))
                           .ToList();
        }


        public SaleDTOGet GetSaleById(int id)
        {
            // Retrieve the sale from the database using the provided ID
            var data = _context.Sales.Where(x => x.SaleId == id).FirstOrDefault();

            // Check if the sale exists
            if (data == null)
                throw new ArgumentException("Sale not found!");

            // Map the sale entity to a DTO and return the result
            return SaleMapper.MapGet(data);
        }


        public SaleDTOGet UpdateSale(int id, Sale sale)
        {
            // Retrieve the existing sale from the database
            var sDB = _context.Sales.Where(x => x.SaleId == id).FirstOrDefault();

            // Check if the sale exists
            if (sDB == null)
                throw new ArgumentException($"There is no sale with id {id}");

            // Update sale fields only if new values are provided
            sDB.BoLnumber = sale.BoLnumber ?? sDB.BoLnumber;
            sDB.Status = sale.Status ?? sDB.Status;
            sDB.BookingNumber = sale.BookingNumber ?? sDB.BookingNumber;
            sDB.SaleDate = sale.SaleDate ?? sDB.SaleDate;
            sDB.CustomerId = sale.CustomerId ?? sDB.CustomerId;

            // Check if the provided status is valid
            if (!string.IsNullOrEmpty(sale.Status) && !statusList.Contains(sale.Status.ToLower()))
                throw new ArgumentException("Incorrect status\nA sale is Active or Closed");

            // If a new CustomerId is provided, check if the customer exists
            if (sale.CustomerId != null)
            {
                var customers = _context.Customers.Where(x => x.CustomerId == sale.CustomerId).FirstOrDefault();
                if (customers == null)
                    throw new ArgumentException($"There is no customer with ID {sale.CustomerId}");
            }

            // Update the sale in the database
            _context.Sales.Update(sDB);
            _context.SaveChanges();

            // Return the updated sale mapped to DTO
            return SaleMapper.MapGet(sDB);
        }

    }
}
