using System;

namespace Entity_Valdidator.Entity.Procedures
{
    public class TotalAmountSpentPerSupplierInvoice
    {

        public int? SupplierInvoiceID { get; set; }
        public int? SaleID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public string CountryRegion { get; set; }
        public decimal? TotalSpent { get; set; }
    }
}
