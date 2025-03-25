using System;

namespace WinformDotNetFramework.Entities
{
    public partial class SupplierInvoice
    {

        public int InvoiceId { get; set; }
        public int? SaleId { get; set; }
        public string SupplierInvoiceCode { get; set; }
        public int? SupplierId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }
    }
}
