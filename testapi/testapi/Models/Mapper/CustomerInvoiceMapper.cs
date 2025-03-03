using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CustomerInvoiceMapper
    {
        public static CustomerInvoiceDTO Map(CustomerInvoice customerInvoice)
        {
            if (customerInvoice == null)
                return null;
            return new CustomerInvoiceDTO()
            {
                SaleId = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status
            };
        }


        public static CustomerInvoice Map(CustomerInvoiceDTO customerInvoice)
        {
            if (customerInvoice == null)
                return null;
            return new CustomerInvoice()
            {
                SaleId = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status
            };
        }

        public static CustomerInvoiceDTOGet MapGet(CustomerInvoice customerInvoice)
        {
            if (customerInvoice == null)
                return null;
            return new CustomerInvoiceDTOGet()
            {
                CustomerInvoiceId = customerInvoice.CustomerInvoiceId,
                SaleId = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status
            };
        }


        public static CustomerInvoice MapGet(CustomerInvoiceDTOGet customerInvoice)
        {
            if (customerInvoice == null)
                return null;
            return new CustomerInvoice()
            {
                CustomerInvoiceId = (int)customerInvoice.CustomerInvoiceId,
                SaleId = customerInvoice.SaleId,
                InvoiceAmount = customerInvoice.InvoiceAmount,
                InvoiceDate = customerInvoice.InvoiceDate,
                Status = customerInvoice.Status
            };
        }
    }
}
