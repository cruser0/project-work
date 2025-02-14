using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ICustomerService
    {
        ICollection<CustomerDTOGet> GetAllCustomers(CustomerFilter? filter);
        CustomerDTOGet GetCustomerById(int id);
        CustomerDTOGet CreateCustomer(Customer customer);
        CustomerDTOGet UpdateCustomer(int id, Customer customer);
        CustomerDTOGet DeleteCustomer(int id);


    }
    public class CustomerServices : ICustomerService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISalesService _sService;
        public CustomerServices(Progetto_FormativoContext ctx, ISalesService SaleService)
        {
            _context = ctx;
            _sService = SaleService;
        }

        public ICollection<CustomerDTOGet> GetAllCustomers(CustomerFilter? filter)
        {
            // Retrieve all customers from the database and map them to DTOs
            return ApplyFilter(filter);
        }

        private ICollection<CustomerDTOGet> ApplyFilter(CustomerFilter? filter)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.CustomerName.Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.Country))
            {
                query = query.Where(x => x.Country.Contains(filter.Country));
            }

            return query.Select(x => CustomerMapper.MapGet(x)).ToList();
        }

        public CustomerDTOGet GetCustomerById(int id)
        {
            // Retrieve the customer from the database based on the provided ID
            var data = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (data == null)
            {
                throw new Exception("Customer not found!");
            }
            // Map and return the customer as a DTO
            return CustomerMapper.MapGet(data);
        }

        public CustomerDTOGet CreateCustomer(Customer customer)
        {
            // Check if the provided customer object is null
            if (customer == null)
                throw new Exception("Couldn't create customer");

            // List to track missing required fields
            var nullFields = new List<string>();

            // Check if required fields are null or empty
            if (string.IsNullOrEmpty(customer.CustomerName)) nullFields.Add("CustomerName");
            if (string.IsNullOrEmpty(customer.Country)) nullFields.Add("Country");

            // If any required field is missing, throw an exception with details
            if (nullFields.Any())
                throw new ArgumentException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            if (customer.CustomerName.Length > 100)
                throw new ArgumentException("Customer name is too long");

            if (customer.Country.Length > 50)
                throw new ArgumentException("Country is too long");

            if (!customer.Country.All(char.IsLetter))
                throw new ArgumentException("Country can't have special characters");

            if (_context.Customers.Any(x => x.CustomerName.Equals(customer.CustomerName) && x.Country.Equals(customer.Country)))
                throw new ArgumentException("This customer already exists");

            // Add the new customer to the database
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Map the created customer entity to a DTO and return it
            return CustomerMapper.MapGet(customer);
        }

        public CustomerDTOGet UpdateCustomer(int id, Customer customer)
        {
            // Retrieve the customer from the database based on the provided ID
            var cDB = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            // If the customer does not exist, throw an exception
            if (cDB == null)
                throw new Exception("Customer not found");

            if (customer.CustomerName != null && customer.Country != null)
            {
                if (_context.Customers.Any(x => x.CustomerName.Equals(customer.CustomerName) && x.Country.Equals(customer.Country)))
                    throw new ArgumentException("This customer already exists");
            }
            else if (customer.CustomerName != null)
            {
                if (_context.Customers.Any(x => x.CustomerName.Equals(customer.CustomerName) && x.Country.Equals(cDB.Country)))
                    throw new ArgumentException("This customer already exists");
            }
            else if (customer.Country != null)
            {
                if (_context.Customers.Any(x => x.CustomerName.Equals(cDB.CustomerName) && x.Country.Equals(customer.Country)))
                    throw new ArgumentException("This customer already exists");
            }

            // Update only the fields that are not null in the input object
            cDB.CustomerName = customer.CustomerName ?? cDB.CustomerName;
            cDB.Country = customer.Country ?? cDB.Country;

            if (customer.CustomerName != null)
                if (customer.CustomerName.Length > 100)
                    throw new ArgumentException("Customer name is too long");

            if (customer.Country != null)
            {
                if (customer.Country.Length > 50)
                    throw new ArgumentException("Country is too long");

                if (!customer.Country.All(char.IsLetter))
                    throw new ArgumentException("Country can't have special characters");
            }



            // Save the changes to the database
            _context.Customers.Update(cDB);
            _context.SaveChanges();

            // Map and return the updated customer as a DTO
            return CustomerMapper.MapGet(cDB);
        }

        public CustomerDTOGet DeleteCustomer(int id)
        {
            // Retrieve the customer from the database based on the provided ID
            var data = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            // If the customer does not exist, throw an exception
            if (data == null)
                throw new Exception("Customer not found!");

            // Retrieve all sales associated with this customer
            var sales = _context.Sales.Where(s => s.CustomerId == id).ToList();

            // If there are any sales, delete them
            if (sales.Count > 0)
                foreach (var sale in sales)
                    _sService.DeleteSale(sale.SaleId);

            // Remove the customer from the database
            _context.Customers.Remove(data);
            _context.SaveChanges();

            // Map the deleted customer to DTO and return it
            return CustomerMapper.MapGet(data);
        }

    }
}
