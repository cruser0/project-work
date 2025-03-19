using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierInvoiceCostMapper
    {
        public static SupplierInvoiceCostDTO Map(SupplierInvoiceCost supplierInvoiceCost)
        {
            return new SupplierInvoiceCostDTO()
            {

                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistryCode = supplierInvoiceCost.CostRegistry!.CostRegistryUniqueCode
            };
        }
        public static SupplierInvoiceCost Map(SupplierInvoiceCostDTO supplierInvoiceCost, CostRegistry costRegistry)
        {
            return new SupplierInvoiceCost()
            {

                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistry = costRegistry,
                CostRegistryID = costRegistry?.CostRegistryID
            };
        }

        public static SupplierInvoiceCostDTOGet MapGet(SupplierInvoiceCost supplierInvoiceCost)
        {
            return new SupplierInvoiceCostDTOGet()
            {
                SupplierInvoiceCostsId = supplierInvoiceCost.SupplierInvoiceCostsId,
                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistryCode = supplierInvoiceCost.CostRegistry!.CostRegistryUniqueCode
            };
        }
        public static SupplierInvoiceCost MapGet(SupplierInvoiceCostDTOGet supplierInvoiceCost, CostRegistry costRegistry)
        {
            return new SupplierInvoiceCost()
            {
                SupplierInvoiceCostsId = (int)supplierInvoiceCost.SupplierInvoiceCostsId!,
                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistry = costRegistry,
                CostRegistryID = costRegistry?.CostRegistryID

            };
        }
    }
}

