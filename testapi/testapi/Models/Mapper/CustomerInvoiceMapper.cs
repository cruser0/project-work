using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;

namespace API.Models.Mapper
{
    public static class CustomerInvoiceMapper
    {
        public static CustomerInvoiceDTO Map(CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceDTO()
            {
                SaleID = customerInvoice.SaleID,
                SaleBoL = customerInvoice.Sale.BoLnumber,
                SaleBookingNumber = customerInvoice.Sale.BookingNumber,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status!.StatusName,
                CustomerInvoiceCode = customerInvoice.CustomerInvoiceCode,
                AmountPaidID = customerInvoice.CustomerInvoiceAmountPaid.CustomerInvoiceAmountPaidID
            };
        }


        public static CustomerInvoice Map(CustomerInvoiceDTO customerInvoice, Status? status, Sale? sale)
        {
            return new CustomerInvoice()
            {
                SaleID = customerInvoice.SaleID,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                CustomerInvoiceCode = customerInvoice.CustomerInvoiceCode,
                Status = status,
                StatusID = status?.StatusID,
                Sale = sale
            };
        }

        public static CustomerInvoiceDTOGet MapGet(CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceDTOGet()
            {
                CustomerInvoiceId = customerInvoice.CustomerInvoiceID,
                SaleID = customerInvoice.SaleID,
                SaleBoL = customerInvoice.Sale.BoLnumber,
                SaleBookingNumber = customerInvoice.Sale.BookingNumber,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                CustomerInvoiceCode = customerInvoice.CustomerInvoiceCode,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status!.StatusName,
                AmountPaidID = customerInvoice.CustomerInvoiceAmountPaid.CustomerInvoiceAmountPaidID
            };
        }


        public static CustomerInvoice MapGet(CustomerInvoiceDTOGet customerInvoice, Status? status, Sale? sale, CustomerInvoiceAmountPaid? amountPaid)
        {
            return new CustomerInvoice()
            {
                CustomerInvoiceID = (int)customerInvoice.CustomerInvoiceId!,
                SaleID = customerInvoice.SaleID,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                CustomerInvoiceCode = customerInvoice.CustomerInvoiceCode,
                Status = status,
                StatusID = status?.StatusID,
                Sale = sale,
                CustomerInvoiceAmountPaid = amountPaid,
            };
        }
    }
}
