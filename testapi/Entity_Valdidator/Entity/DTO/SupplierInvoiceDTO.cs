
using Entity_Valdidator.Entity.Entities;
using System;

namespace Entity_Valdidator.Entity.DTO
{
    public class SupplierInvoiceDTO
    {
        public string SupplierInvoiceCode { get; set; }
        public int? SaleId { get; set; }
        public string SaleBookingNumber { get; set; }
        public string SaleBoL { get; set; }
        public int? SupplierId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }

    }

    public class SupplierInvoiceDTOGet : SupplierInvoiceDTO
    {
        public int? InvoiceId { get; set; }
    }

    public class SupplierInvoiceSupplierDTO : SupplierInvoiceDTOGet
    {
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public SupplierInvoiceSupplierDTO(SupplierInvoice si, Supplier s)
        {
            SupplierInvoiceCode = si.SupplierInvoiceCode;
            InvoiceId = si.SupplierInvoiceID;
            InvoiceDate = si.InvoiceDate;
            SupplierName = s.SupplierName;
            Country = s.Country.CountryName;
            SupplierId = si.SupplierID;
            SaleId = si.SaleID;
            SaleBookingNumber = si.Sale.BookingNumber;
            SaleBoL = si.Sale.BoLnumber;
            InvoiceAmount = si.InvoiceAmount;
            InvoiceDate = si.InvoiceDate;
            Status = si.Status.StatusName;
        }
    }
}