using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierInvoiceCostMapper
    {
        public static SupplierInvoiceCostDTO Map(SupplierInvoiceCost supplierInvoiceCost)
        {
            if (supplierInvoiceCost == null)
                return null;
            return new SupplierInvoiceCostDTO()
            {

                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,

            };
        }
        public static SupplierInvoiceCost Map(SupplierInvoiceCostDTO supplierInvoiceCost)
        {
            if (supplierInvoiceCost == null)
                return null;
            return new SupplierInvoiceCost()
            {

                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,

            };
        }

        public static SupplierInvoiceCostDTOGet MapGet(SupplierInvoiceCost supplierInvoiceCost)
        {
            if (supplierInvoiceCost == null)
                return null;
            return new SupplierInvoiceCostDTOGet()
            {
                SupplierInvoiceCostsId = supplierInvoiceCost.SupplierInvoiceCostsId,
                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,

            };
        }
        public static SupplierInvoiceCost MapGet(SupplierInvoiceCostDTOGet supplierInvoiceCost)
        {
            if (supplierInvoiceCost == null)
                return null;
            return new SupplierInvoiceCost()
            {
                SupplierInvoiceCostsId = (int)supplierInvoiceCost.SupplierInvoiceCostsId,
                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,

            };
        }
    }
}

