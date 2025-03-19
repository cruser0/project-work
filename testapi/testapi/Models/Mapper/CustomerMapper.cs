using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerMapper
    {
        public static CustomerDTO Map(Customer customer)
        {
            return new CustomerDTO()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country.CountryName,
                Deprecated = customer.Deprecated,
                CreatedAt = customer.CreatedAt
            };
        }
        public static Customer Map(CustomerDTO customer, Country? country)
        {
            return new Customer()
            {
                CustomerName = customer.CustomerName,
                Country = country,
                CountryID = country?.CountryID,
                Deprecated = customer.Deprecated,
                CreatedAt = customer.CreatedAt
            };
        }

        public static CustomerDTOGet MapGet(Customer customer)
        {
            return new CustomerDTOGet()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country.CountryName,
                Deprecated = customer.Deprecated,
                CustomerId = customer.CustomerID,
                CreatedAt = customer.CreatedAt,
                OriginalID = customer.OriginalID
            };
        }
        public static Customer MapGet(CustomerDTOGet customer, Country? country)
        {
            return new Customer()
            {
                CustomerName = customer.CustomerName,
                Country = country,
                CountryID = country?.CountryID,
                Deprecated = customer.Deprecated,
                CustomerID = (int)customer.CustomerId!,
                CreatedAt = customer.CreatedAt,
                OriginalID = (int)customer.OriginalID!
            };
        }

    }
}
