namespace API.Models.Filters
{
    public class SupplierInvoiceFilter
    {
        public int? SaleID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? InvoiceDateFrom { get; set; }
        public DateTime? InvoiceDateTo { get; set; }
        public string? Status { get; set; }
        public int? page { get; set; }
    }
}
