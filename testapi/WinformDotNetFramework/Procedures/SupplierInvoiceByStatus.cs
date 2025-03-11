using System;

namespace WinformDotNetFramework.Procedures
{
    public class SupplierInvoiceByStatus
    {
        public int? InvoiceID { get; set; }
        public int? SaleID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }

    }
}
