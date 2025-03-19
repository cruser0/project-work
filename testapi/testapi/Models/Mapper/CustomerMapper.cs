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
            return new CustomerDTO()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country,
                Deprecated = customer.Deprecated,
                CreatedAt = customer.CreatedAt
            };
        }
        public static Customer Map(CustomerDTO customer)
        {
            if (customer == null)
                return null;
            return new Customer()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country,
                Deprecated = customer.Deprecated,
                CreatedAt = customer.CreatedAt
            };
        }

        public static CustomerDTOGet MapGet(Customer customer)
        {
            if (customer == null)
                return null;
            return new CustomerDTOGet()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country,
                Deprecated = customer.Deprecated,
                CustomerId = customer.CustomerID,
                CreatedAt = customer.CreatedAt,
                OriginalID = customer.OriginalID
            };
        }
        public static Customer MapGet(CustomerDTOGet customer)
        {
            if (customer == null)
                return null;
            return new Customer()
            {
                CustomerName = customer.CustomerName,
                Country = customer.Country,
                Deprecated = customer.Deprecated,
                CustomerID = (int)customer.CustomerId,
                CreatedAt = customer.CreatedAt,
                OriginalID = (int)customer.OriginalID
            };
        }

    }
}
