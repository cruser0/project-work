using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerInvoiceMapper
    {
        public static CustomerInvoiceDTO Map(CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceDTO()
            {
                SaleId = customerInvoice.SaleID,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status!.StatusName
            };
        }


        public static CustomerInvoice Map(CustomerInvoiceDTO customerInvoice, Status? status)
        {
            return new CustomerInvoice()
            {
                SaleID = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = status,
                StatusID = status?.StatusID
            };
        }

        public static CustomerInvoiceDTOGet MapGet(CustomerInvoice customerInvoice)
        {
            return new CustomerInvoiceDTOGet()
            {
                CustomerInvoiceId = customerInvoice.CustomerInvoiceID,
                SaleId = customerInvoice.SaleID,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status!.StatusName
            };
        }


        public static CustomerInvoice MapGet(CustomerInvoiceDTOGet customerInvoice, Status? status)
        {
            return new CustomerInvoice()
            {
                CustomerInvoiceID = (int)customerInvoice.CustomerInvoiceId!,
                SaleID = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = status,
                StatusID = status?.StatusID
            };
        }
    }
}
