using System;

namespace WinformDotNetFramework.Entities
{
    public class CustomerInvoice
    {

        public int CustomerInvoiceId { get; set; }
        public int? SaleId { get; set; }
        public string SaleBookingNumber { get; set; }
        public string SaleBoL { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }

    }
}
