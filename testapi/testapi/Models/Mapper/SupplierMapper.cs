using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierMapper
    {
        public static SupplierDTO Map(Supplier supplier)
        {
            if (supplier == null)
                return null;
            return new SupplierDTO()
            {

                SupplierName = supplier.SupplierName,
                Country = supplier.Country

            };
        }
        public static Supplier Map(SupplierDTO supplier)
        {
            if (supplier == null)
                return null;
            return new Supplier()
            {

                SupplierName = supplier.SupplierName,
                Country = supplier.Country

            };
        }

        public static SupplierDTOGet MapGet(Supplier supplier)
        {
            if (supplier == null)
                return null;
            return new SupplierDTOGet()
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Country = supplier.Country

            };
        }
        public static Supplier MapGet(SupplierDTOGet supplier)
        {
            if (supplier == null)
                return null;
            return new Supplier()
            {
                SupplierId = (int)supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                Country = supplier.Country

            };
        }
    }
}
