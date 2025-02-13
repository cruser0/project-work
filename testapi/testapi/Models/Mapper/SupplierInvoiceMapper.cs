using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierInvoiceMapper
    {
        public static SupplierInvoiceDTO Map(SupplierInvoice supplierInvoice)
        {
            if (supplierInvoice == null)
                return null;
            return new SupplierInvoiceDTO()
            {

                SaleId = supplierInvoice.SaleId,
                SupplierId = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status

            };
        }
        public static SupplierInvoice Map(SupplierInvoiceDTO supplierInvoice)
        {
            if (supplierInvoice == null)
                return null;
            return new SupplierInvoice()
            {

                SaleId = supplierInvoice.SaleId,
                SupplierId = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status

            };
        }

        public static SupplierInvoiceDTOGet MapGet(SupplierInvoice supplierInvoice)
        {
            if (supplierInvoice == null)
                return null;
            return new SupplierInvoiceDTOGet()
            {

                InvoiceId = supplierInvoice.InvoiceId,
                SaleId = supplierInvoice.SaleId,
                SupplierId = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status

            };
        }
        public static SupplierInvoice MapGet(SupplierInvoiceDTOGet supplierInvoice)
        {
            if (supplierInvoice == null)
                return null;
            return new SupplierInvoice()
            {

                InvoiceId = (int)supplierInvoice.InvoiceId,
                SaleId = supplierInvoice.SaleId,
                SupplierId = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status

            };
        }
    }
}
