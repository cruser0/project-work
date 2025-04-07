using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;

namespace API.Models.Mapper
{
    public class CustomerInvoiceAmountPaidMapper
    {
        public static CustomerInvoiceAmountPaidDTO Map(CustomerInvoiceAmountPaid customerInvoiceAmountPaid)
        {
            return new CustomerInvoiceAmountPaidDTO
            {
                CustomerInvoiceID = customerInvoiceAmountPaid.CustomerInvoiceID,
                AmountPaid = customerInvoiceAmountPaid.AmountPaid,
                MaximumAmount = customerInvoiceAmountPaid.CustomerInvoice.InvoiceAmount
            };
        }
        public static CustomerInvoiceAmountPaid Map(CustomerInvoiceAmountPaidDTO customerInvoiceAmountPaid, CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceAmountPaid
            {
                CustomerInvoiceID = customerInvoiceAmountPaid.CustomerInvoiceID ?? null,
                AmountPaid = customerInvoiceAmountPaid.AmountPaid ?? null,
                CustomerInvoice = customerInvoice
            };
        }

        public static CustomerInvoiceAmountPaidDTOGet MapGet(CustomerInvoiceAmountPaid customerInvoiceAmountPaid)
        {
            return new CustomerInvoiceAmountPaidDTOGet
            {
                CustomerInvoiceAmountPaidID = customerInvoiceAmountPaid.CustomerInvoiceID,
                CustomerInvoiceID = customerInvoiceAmountPaid.CustomerInvoiceID,
                AmountPaid = customerInvoiceAmountPaid.AmountPaid,
                MaximumAmount = customerInvoiceAmountPaid.CustomerInvoice.InvoiceAmount
            };
        }
        public static CustomerInvoiceAmountPaid MapGet(CustomerInvoiceAmountPaidDTOGet customerInvoiceAmountPaid, CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceAmountPaid
            {
                CustomerInvoiceAmountPaidID = (int)customerInvoiceAmountPaid.CustomerInvoiceAmountPaidID!,
                CustomerInvoiceID = customerInvoiceAmountPaid.CustomerInvoiceID ?? null,
                AmountPaid = customerInvoiceAmountPaid.AmountPaid ?? null,
                CustomerInvoice = customerInvoice
            };
        }

    }
}
