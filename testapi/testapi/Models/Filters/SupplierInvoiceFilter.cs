namespace API.Models.Filters
{
    public class SupplierInvoiceFilter
    {
        public int? SaleID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }
    }
}
