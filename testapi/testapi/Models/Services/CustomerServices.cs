using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerDTOGet>> GetAllCustomers(CustomerFilter filter);
        Task<CustomerDTOGet> GetCustomerById(int id);
        Task<CustomerDTOGet> CreateCustomer(Customer customer);
        Task<CustomerDTOGet> UpdateCustomer(int id, Customer customer);
        Task<CustomerDTOGet> DeleteCustomer(int id);
        Task<int> CountCustomers(CustomerFilter filter);


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

        public async Task<ICollection<CustomerDTOGet>> GetAllCustomers(CustomerFilter filter)
        {
            // Retrieve all customers from the database and map them to DTOs
            return await ApplyFilter(filter).ToListAsync();
        }

        public async Task<int> CountCustomers(CustomerFilter filter)
        {
            return await ApplyFilter(filter).CountAsync();
        }

        private IQueryable<CustomerDTOGet> ApplyFilter(CustomerFilter? filter)
        {
            int itemsPerPage = 10;
            var query = _context.Customers.AsQueryable();

            // Filtra per OriginalID se specificato
            if (filter.CustomerOriginalID != null)
            {
                query = query.Where(x => x.OriginalID == filter.CustomerOriginalID);
            }

            // Filtra per nome se specificato
            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
                query = query.Where(x => x.CustomerName.Contains(filter.CustomerName));
            }

            // Filtra per data di creazione
            if (filter.CustomerCreatedDateFrom != null || filter.CustomerCreatedDateTo != null)
            {
                if (filter.CustomerCreatedDateFrom != null)
                {
                    query = query.Where(s => s.CreatedAt >= filter.CustomerCreatedDateFrom);
                }
                if (filter.CustomerCreatedDateTo != null)
                {
                    query = query.Where(s => s.CreatedAt <= filter.CustomerCreatedDateTo);
                }
            }

            // Filtra per paese se specificato
            if (!string.IsNullOrEmpty(filter.CustomerCountry))
            {
                query = query.Where(x => x.Country.Contains(filter.CustomerCountry));
            }

            // Filtra per stato di deprecazione se specificato
            if (filter.CustomerDeprecated != null)
            {
                query = query.Where(x => x.Deprecated == filter.CustomerDeprecated);
            }

            // Applica paginazione se specificata
            if (filter.CustomerPage != null && filter.CustomerPage > 0)
            {
                query = query.Skip(((int)filter.CustomerPage - 1) * itemsPerPage).Take(itemsPerPage);
            }

            return query.Select(x => CustomerMapper.MapGet(x));
        }

        public async Task<CustomerDTOGet> GetCustomerById(int id)
        {
            // Retrieve the customer from the database based on the provided ID
            var data = await _context.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception("Customer not found!");
            }
            // Map and return the customer as a DTO
            return CustomerMapper.MapGet(data);
        }

        public async Task<CustomerDTOGet> CreateCustomer(Customer customer)
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
                await _context.SaveChangesAsync();
                customer.OriginalID = customer.CustomerId;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return CustomerMapper.MapGet(customer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }


        }

        public async Task<CustomerDTOGet> UpdateCustomer(int id, Customer customer)
        {
            // Retrieve the customer from the database based on the provided ID
            var cDB = await _context.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();

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
                await _context.SaveChangesAsync();

                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();

                // Map and return the updated customer as a DTO
                return CustomerMapper.MapGet(newCustomer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Couldn't update customer: " + ex.InnerException.Message);
            }
        }

        public async Task<CustomerDTOGet> DeleteCustomer(int id)
        {
            // Retrieve the customer from the database based on the provided ID
            var data = await _context.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();

            // If the customer does not exist, throw an exception
            if (data == null)
                throw new Exception("Customer not found!");

            // Retrieve all sales associated with this customer
            var sales = await _context.Sales.Where(s => s.CustomerId == id).ToListAsync();

            // If there are any sales, delete them
            if (sales.Count > 0)
                foreach (var sale in sales)
                    await _sService.DeleteSale(sale.SaleId);

            // Remove the customer from the database
            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();

            // Map the deleted customer to DTO and return it
            return CustomerMapper.MapGet(data);
        }


    }
}
