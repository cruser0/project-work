using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerInvoiceCostMapper
    {
        public static CustomerInvoiceCostDTO Map(CustomerInvoiceCost customerInvoiceCost)
        {
            return new CustomerInvoiceCostDTO()
            {

                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceID,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,
                CostRegistryCode = customerInvoiceCost.CostRegistry!.CostRegistryUniqueCode,
                CustomerInvoiceCode = customerInvoiceCost.CustomerInvoice.CustomerInvoiceCode

            };
        }
        public static CustomerInvoiceCost Map(CustomerInvoiceCostDTO customerInvoiceCost, CostRegistry? costRegistry, CustomerInvoice? customerInvoice)
        {
            return new CustomerInvoiceCost()
            {

                CustomerInvoiceID = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,
                CostRegistryID = costRegistry?.CostRegistryID,
                CostRegistry = costRegistry,
                CustomerInvoice = customerInvoice,

            };
        }

        public static CustomerInvoiceCostDTOGet MapGet(CustomerInvoiceCost customerInvoiceCost)
        {
            return new CustomerInvoiceCostDTOGet()
            {
                CustomerInvoiceCostsId = customerInvoiceCost.CustomerInvoiceCostsID,
                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceID,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,
                CostRegistryCode = customerInvoiceCost.CostRegistry!.CostRegistryUniqueCode,
                CustomerInvoiceCode = customerInvoiceCost.CustomerInvoice.CustomerInvoiceCode

            };
        }
        public static CustomerInvoiceCost MapGet(CustomerInvoiceCostDTOGet customerInvoiceCost, CostRegistry? costRegistry, CustomerInvoice? customerInvoice)
        {
            return new CustomerInvoiceCost()
            {
                CustomerInvoiceCostsID = (int)customerInvoiceCost.CustomerInvoiceCostsId!,
                CustomerInvoiceID = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,
                CostRegistryID = costRegistry?.CostRegistryID,
                CostRegistry = costRegistry,
                CustomerInvoice = customerInvoice,

            };
        }
    }
}
