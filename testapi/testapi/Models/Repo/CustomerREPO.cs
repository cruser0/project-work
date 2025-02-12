using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;

namespace testapi.Repo
{
    public interface ICustomerREPO
    {
        ICollection<CustomerDTOGet> GetAllCustomers();
        CustomerDTOGet GetCustomerById(int id);
        CustomerDTOGet CreateCustomer(Customer customer);
        CustomerDTOGet UpdateCustomer(int id, Customer customer);
        CustomerDTOGet DeleteCustomer(int id);


    }
    public class CustomerREPO : ICustomerREPO
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISalesREPO _sRepo;
        public CustomerREPO(Progetto_FormativoContext ctx, ISalesREPO Srepo)
        {
            _context = ctx;
            _sRepo = Srepo;
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

            // Add the new customer to the database
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Map the created customer entity to a DTO and return it
            return CustomerMapper.MapGet(customer);
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
                    _sRepo.DeleteSale(sale.SaleId);

            // Remove the customer from the database
            _context.Customers.Remove(data);
            _context.SaveChanges();

            // Map the deleted customer to DTO and return it
            return CustomerMapper.MapGet(data);
        }


        public ICollection<CustomerDTOGet> GetAllCustomers()
        {
            // Retrieve all customers from the database and map them to DTOs
            return _context.Customers.Select(x => CustomerMapper.MapGet(x)).ToList();
        }


        public CustomerDTOGet GetCustomerById(int id)
        {
            // Retrieve the customer from the database based on the provided ID
            var data = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            // Map and return the customer as a DTO
            return CustomerMapper.MapGet(data);
        }



        public CustomerDTOGet UpdateCustomer(int id, Customer customer)
        {
            // Retrieve the customer from the database based on the provided ID
            var cDB = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            // If the customer does not exist, throw an exception
            if (cDB == null)
                throw new Exception("Customer not found");

            // Update only the fields that are not null in the input object
            cDB.CustomerName = customer.CustomerName ?? cDB.CustomerName;
            cDB.Country = customer.Country ?? cDB.Country;

            // Save the changes to the database
            _context.Customers.Update(cDB);
            _context.SaveChanges();

            // Map and return the updated customer as a DTO
            return CustomerMapper.MapGet(cDB);
        }

    }
}
