using System;

namespace WinformDotNetFramework.Entities.Filters

{
    public class TotalAmountGainedPerCustomerInvoiceFilter
    {
        public int? customerInvoiceID { get; set; }
        public int? TotalGainedFrom { get; set; }
        public int? TotalGainedTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
    }
}
