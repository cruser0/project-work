using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerMapper
    {
        public static CustomerDTO Map(Customer customer)
        {
            if (customer == null)
                return null;
            return new CustomerDTO() { CustomerName = customer.CustomerName, Country = customer.Country, Deprecated = customer.Deprecated };
        }
        public static Customer Map(CustomerDTO customer)
        {
            if (customer == null)
                return null;
            return new Customer() { CustomerName = customer.CustomerName, Country = customer.Country, Deprecated = customer.Deprecated };
        }

        public static CustomerDTOGet MapGet(Customer customer)
        {
            if (customer == null)
                return null;
            return new CustomerDTOGet() { CustomerName = customer.CustomerName, Country = customer.Country, Deprecated = customer.Deprecated, CustomerId = customer.CustomerId };
        }
        public static Customer MapGet(CustomerDTOGet customer)
        {
            if (customer == null)
                return null;
            return new Customer() { CustomerName = customer.CustomerName, Country = customer.Country, Deprecated = customer.Deprecated, CustomerId = (int)customer.CustomerId };
        }

    }
}
