using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerInvoiceCostMapper
    {
        public static CustomerInvoiceCostDTO Map(CustomerInvoiceCost customerInvoiceCost)
        {
            if (customerInvoiceCost == null)
                return null;
            return new CustomerInvoiceCostDTO()
            {

                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,

            };
        }
        public static CustomerInvoiceCost Map(CustomerInvoiceCostDTO customerInvoiceCost)
        {
            if (customerInvoiceCost == null)
                return null;
            return new CustomerInvoiceCost()
            {

                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,

            };
        }

        public static CustomerInvoiceCostDTOGet MapGet(CustomerInvoiceCost customerInvoiceCost)
        {
            if (customerInvoiceCost == null)
                return null;
            return new CustomerInvoiceCostDTOGet()
            {
                CustomerInvoiceCostsId = customerInvoiceCost.CustomerInvoiceCostsId,
                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,

            };
        }
        public static CustomerInvoiceCost MapGet(CustomerInvoiceCostDTOGet customerInvoiceCost)
        {
            if (customerInvoiceCost == null)
                return null;
            return new CustomerInvoiceCost()
            {
                CustomerInvoiceCostsId = customerInvoiceCost.CustomerInvoiceCostsId,
                CustomerInvoiceId = customerInvoiceCost.CustomerInvoiceId,
                Cost = customerInvoiceCost.Cost,
                Quantity = customerInvoiceCost.Quantity,
                Name = customerInvoiceCost.Name,

            };
        }
    }
}
