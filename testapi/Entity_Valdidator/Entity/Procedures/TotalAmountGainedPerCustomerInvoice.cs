
using System;

namespace Entity_Valdidator.Entity.Procedures
{
    public class TotalAmountGainedPerCustomerInvoice
    {
        public int? CustomerInvoiceID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? SaleID { get; set; }
        public string Status { get; set; }
        public decimal? TotalGained { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string CountryRegion { get; set; }
    }
}
