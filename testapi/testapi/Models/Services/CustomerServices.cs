using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
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
        Task<string> MassDeleteCustomer(List<int> customerId);
        Task<string> MassUpdateCustomer(List<CustomerDTOGet> newCustomers);


    }
    public class CustomerServices : ICustomerService
    {
        private readonly Progetto_FormativoContext _context;
        private readonly ISalesService _sService;
        private readonly CountryService _countryService;
        public CustomerServices(Progetto_FormativoContext ctx, ISalesService SaleService, CountryService cs)
        {
            _context = ctx;
            _sService = SaleService;
            _countryService = cs;
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
            var query = _context.Customers.Include(x => x.Country).AsQueryable();

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
                query = query.Where(x => x.Country.CountryName.Contains(filter.CustomerCountry));
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
            var data = await _context.Customers.Include(x => x.Country).Where(x => x.CustomerID == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new NotFoundException("Customer not found!");
            }
            // Map and return the customer as a DTO
            return CustomerMapper.MapGet(data);
        }

        public async Task<CustomerDTOGet> CreateCustomer(Customer customer)
        {
            // Check if the provided customer object is null
            if (customer == null)
                throw new NullPropertyException("Couldn't create customer");

            // List to track missing required fields
            var nullFields = new List<string>();

            // Check if required fields are null or empty
            if (string.IsNullOrEmpty(customer.CustomerName)) nullFields.Add("CustomerName");
            if (string.IsNullOrEmpty(customer.Country.CountryName)) nullFields.Add("Country");

            // If any required field is missing, throw an exception with details
            if (nullFields.Any())
                throw new NullPropertyException($"{string.Join(", ", nullFields)} {(nullFields.Count > 1 ? "are" : "is")} null");

            if (customer.Deprecated != null)
                if ((bool)customer.Deprecated)
                    throw new ErrorInputPropertyException("Can't create an already deprecated customer");
                else
                    customer.Deprecated = false;
            else
                customer.Deprecated = false;

            customer.CreatedAt = DateTime.Now;

            if (customer.CustomerName.Length > 100)
                throw new ErrorInputPropertyException("Customer name is too long");

            if (customer.Country.CountryName.Length > 50)
                throw new ErrorInputPropertyException("Country is too long");


            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            customer.OriginalID = customer.CustomerID;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return CustomerMapper.MapGet(customer);


        }

        public async Task<CustomerDTOGet> UpdateCustomer(int id, Customer customer)
        {
            // Retrieve the customer from the database based on the provided ID
            var cDB = await _context.Customers.Where(x => x.CustomerID == id).Include(x => x.Country).FirstOrDefaultAsync();

            // If the customer does not exist, throw an exception
            if (cDB == null)
                throw new NotFoundException("Customer not found");

            if ((bool)cDB.Deprecated)
                throw new ErrorInputPropertyException("Can't update deprecated customer");

            if (customer.CustomerName != null)
                if (customer.CustomerName.Length > 100)
                    throw new ErrorInputPropertyException("Customer name is too long");
            if (customer.Country != null)
            {
                if (customer.Country.CountryName.Length > 50)
                    throw new ErrorInputPropertyException("Country is too long");

            }



            Customer newCustomer = new Customer
            {
                CustomerName = customer.CustomerName ?? cDB.CustomerName,
                Country = customer.Country ?? cDB.Country,
                CountryID = customer.CountryID ?? cDB.CountryID,
                Deprecated = false,
                OriginalID = cDB.OriginalID,
                CreatedAt = DateTime.Now,
            };

            cDB.Deprecated = true;
            // Save the changes to the database
            _context.Customers.Update(cDB);
            await _context.SaveChangesAsync();

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            // Map and return the updated customer as a DTO
            return CustomerMapper.MapGet(newCustomer);
        }

        public async Task<CustomerDTOGet> DeleteCustomer(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var data = await _context.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
            try
            {
                // Retrieve the customer from the database based on the provided ID

                // If the customer does not exist, throw an exception
                if (data == null)
                    throw new NotFoundException("Customer not found!");

                // Retrieve all sales associated with this customer
                var sales = await _context.Sales.Where(s => s.CustomerID == id).ToListAsync();

                // If there are any sales, delete them
                if (sales.Count > 0)
                {

                    foreach (var sale in sales)
                    {
                        await _sService.DeleteSale(sale.SaleID);

                    }
                }

                // Remove the customer from the database
                _context.Customers.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (ErrorInputPropertyException ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
            await transaction.CommitAsync();

            // Map the deleted customer to DTO and return it
            return CustomerMapper.MapGet(data);
        }

        public async Task<string> MassDeleteCustomer(List<int> customerId)
        {
            int count = 0;
            // Retrieve the customer from the database based on the provided ID
            foreach (var id in customerId)
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                var data = await _context.Customers.Where(x => x.CustomerID == id).FirstOrDefaultAsync();
                try
                {

                    // If the customer does not exist, continues with the loop
                    if (data == null)
                        continue;

                    // Retrieve all sales associated with this customer
                    var sales = await _context.Sales.Where(s => s.CustomerID == id).ToListAsync();

                    // If there are any sales, delete them


                    foreach (var sale in sales)
                    {
                        await _sService.DeleteSale(sale.SaleID);
                    }
                    // Remove the customer from the database
                    _context.Customers.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    continue;
                }
                await transaction.CommitAsync();
                count++;
            }

            // Map the deleted customer to DTO and return it
            return $"{count} Customers were deleted out of {customerId.Count}";
        }

        public async Task<string> MassUpdateCustomer(List<CustomerDTOGet> newCustomers)
        {
            int count = 0;
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (CustomerDTOGet customer in newCustomers)
                {
                    var c = await _context.Customers.Where(x => x.CustomerID == customer.CustomerId).Include(x => x.Country).FirstOrDefaultAsync();

                    if (c == null)
                        throw new NotFoundException("Customer not found");

                    if ((bool)c.Deprecated)
                        throw new ErrorInputPropertyException("Can't update deprecated customer");

                    if (customer.CustomerName != null)
                    {
                        if (customer.CustomerName.Length > 100)
                            throw new ErrorInputPropertyException("Customer name is too long");
                    }

                    if (customer.Country != null)
                    {
                        if (customer.Country.Length > 50)
                            throw new ErrorInputPropertyException("Country is too long");

                    }
                    Customer customerMapped = Mapper.CustomerMapper.Map(customer, _countryService.GetCountryByName(customer.CustomerName));
                    Customer newCustomer = new Customer
                    {
                        CustomerName = customerMapped.CustomerName ?? c.CustomerName,
                        Country = customerMapped.Country ?? c.Country,
                        CountryID = customerMapped.CountryID ?? c.CountryID,
                        Deprecated = false,
                        OriginalID = c.OriginalID,
                        CreatedAt = DateTime.Now,
                    };

                    c.Deprecated = true;
                    _context.Customers.Update(c);
                    _context.Customers.Add(newCustomer);
                    count++;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return $"{count} Customers were updated out of {newCustomers.Count}";
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
