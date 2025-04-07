
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;

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
                CostRegistryCode = supplierInvoiceCost.CostRegistry!.CostRegistryUniqueCode,
                SupplierInvoiceCode = supplierInvoiceCost.SupplierInvoice.SupplierInvoiceCode,
                TotalCost = supplierInvoiceCost.TotalCost,
            };
        }
        public static SupplierInvoiceCost Map(SupplierInvoiceCostDTO supplierInvoiceCost, CostRegistry? costRegistry, SupplierInvoice? supplierInvoice)
        {
            return new SupplierInvoiceCost()
            {

                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistry = costRegistry,
                CostRegistryID = costRegistry?.CostRegistryID,
                SupplierInvoice = supplierInvoice,
                TotalCost = supplierInvoiceCost.TotalCost,
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
                CostRegistryCode = supplierInvoiceCost.CostRegistry!.CostRegistryUniqueCode,
                SupplierInvoiceCode = supplierInvoiceCost.SupplierInvoice.SupplierInvoiceCode,
                TotalCost = supplierInvoiceCost.TotalCost,
            };
        }
        public static SupplierInvoiceCost MapGet(SupplierInvoiceCostDTOGet supplierInvoiceCost, CostRegistry costRegistry, SupplierInvoice? supplierInvoice)
        {
            return new SupplierInvoiceCost()
            {
                SupplierInvoiceCostsId = (int)supplierInvoiceCost.SupplierInvoiceCostsId!,
                SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId,
                Cost = supplierInvoiceCost.Cost,
                Quantity = supplierInvoiceCost.Quantity,
                Name = supplierInvoiceCost.Name,
                CostRegistry = costRegistry,
                CostRegistryID = costRegistry?.CostRegistryID,
                SupplierInvoice = supplierInvoice,
                TotalCost = supplierInvoiceCost.TotalCost,
            };
        }
    }
}

