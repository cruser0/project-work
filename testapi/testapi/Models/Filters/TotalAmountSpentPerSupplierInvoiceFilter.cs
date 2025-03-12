namespace API.Models.Filters
{
    public class TotalAmountSpentPerSupplierInvoiceFilter
    {
        public int? SupplierInvoiceID { get; set; }
        public int? TotalSpentFrom { get; set; }
        public int? TotalSpentTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? Status { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierCountry { get; set; }
    }
}
