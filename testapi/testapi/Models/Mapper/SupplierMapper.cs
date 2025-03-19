using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierMapper
    {
        public static SupplierDTO Map(Supplier supplier)
        {
            return new SupplierDTO()
            {

                SupplierName = supplier.SupplierName,
                Country = supplier.Country.CountryName,
                Deprecated = supplier.Deprecated,
                CreatedAt = supplier.CreatedAt,

            };
        }
        public static Supplier Map(SupplierDTO supplier, Country country)
        {
            return new Supplier()
            {

                SupplierName = supplier.SupplierName,
                Country = country,
                CountryID = country.CountryID,
                Deprecated = supplier.Deprecated,
                CreatedAt = supplier.CreatedAt,

            };
        }

        public static SupplierDTOGet MapGet(Supplier supplier)
        {
            return new SupplierDTOGet()
            {
                SupplierId = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
                Country = supplier.Country.CountryName,
                Deprecated = supplier.Deprecated,
                CreatedAt = supplier.CreatedAt,
                OriginalID = supplier.OriginalID,
            };
        }
        public static Supplier MapGet(SupplierDTOGet supplier, Country country)
        {
            return new Supplier()
            {
                SupplierID = (int)supplier.SupplierId!,
                SupplierName = supplier.SupplierName,
                Country = country,
                CountryID = country.CountryID,
                Deprecated = supplier.Deprecated,
                CreatedAt = supplier.CreatedAt,
                OriginalID = (int)supplier.OriginalID!,
            };
        }
    }
}
