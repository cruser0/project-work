using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;

namespace API.Models.Services
{
    public interface ICustomerService
    {
        ICollection<CustomerDTOGet> GetAllCustomers(CustomerFilter filter);
        CustomerDTOGet GetCustomerById(int id);
        CustomerDTOGet CreateCustomer(Customer customer);
        CustomerDTOGet UpdateCustomer(int id, Customer customer);
        CustomerDTOGet DeleteCustomer(int id);
        int CountCustomers(CustomerFilter filter);


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

        public ICollection<CustomerDTOGet> GetAllCustomers(CustomerFilter filter)
        {
            // Retrieve all customers from the database and map them to DTOs
            return ApplyFilter(filter).ToList();
        }

        public int CountCustomers(CustomerFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        private IQueryable<CustomerDTOGet> ApplyFilter(CustomerFilter? filter)
        {
            int itemsPerPage = 10;
            var query = _context.Customers.AsQueryable();

            // Filtra per OriginalID se specificato
            if (filter.OriginalID != null)
            {
                query = query.Where(x => x.OriginalID == filter.OriginalID);
            }

            // Filtra per nome se specificato
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.CustomerName.Contains(filter.Name));
            }

            // Filtra per data di creazione
            if (filter.CreatedDateFrom != null || filter.CreatedDateTo != null)
            {
                if (filter.CreatedDateFrom != null)
                {
                    query = query.Where(s => s.CreatedAt >= filter.CreatedDateFrom);
                }
                if (filter.CreatedDateTo != null)
                {
                    query = query.Where(s => s.CreatedAt <= filter.CreatedDateTo);
                }
            }

            // Filtra per paese se specificato
            if (!string.IsNullOrEmpty(filter.Country))
            {
                query = query.Where(x => x.Country.Contains(filter.Country));
            }

            // Filtra per stato di deprecazione se specificato
            if (filter.Deprecated != null)
            {
                query = query.Where(x => x.Deprecated == filter.Deprecated);
            }

            // Applica paginazione se specificata
            if (filter.page != null && filter.page > 0)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPerPage).Take(itemsPerPage);
            }

            return query.Select(x => CustomerMapper.MapGet(x));
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

            if (customer.Deprecated != null)
                if ((bool)customer.Deprecated)
                    throw new ArgumentException("Can't create an already deprecated customer");
                else
                    customer.Deprecated = false;
            else
                customer.Deprecated = false;

            customer.CreatedAt = DateTime.Now;

            if (customer.CustomerName.Length > 100)
                throw new ArgumentException("Customer name is too long");

            if (customer.Country.Length > 50)
                throw new ArgumentException("Country is too long");

            if (!customer.Country.All(char.IsLetter))
                throw new ArgumentException("Country can't have special characters");

            // Add the new customer to the database
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customer.OriginalID = customer.CustomerId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return CustomerMapper.MapGet(customer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }


        }

        public CustomerDTOGet UpdateCustomer(int id, Customer customer)
        {
            // Retrieve the customer from the database based on the provided ID
            var cDB = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            // If the customer does not exist, throw an exception
            if (cDB == null)
                throw new Exception("Customer not found");

            if ((bool)cDB.Deprecated)
                throw new ArgumentException("Can't update deprecated customer");

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



            Customer newCustomer = new Customer
            {
                CustomerName = customer.CustomerName ?? cDB.CustomerName,
                Country = customer.Country ?? cDB.Country,
                Deprecated = false,
                OriginalID = cDB.OriginalID,
                CreatedAt = DateTime.Now,
            };

            cDB.Deprecated = true;

            try
            {
                // Save the changes to the database
                _context.Customers.Update(cDB);
                _context.SaveChanges();

                _context.Customers.Add(newCustomer);
                _context.SaveChanges();

                // Map and return the updated customer as a DTO
                return CustomerMapper.MapGet(newCustomer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Couldn't update customer: " + ex.InnerException.Message);
            }
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
