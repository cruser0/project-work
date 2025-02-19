namespace API.Models.Filters
{
    public class CustomerInvoiceFilter
    {
        public int? SaleId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDateFrom { get; set; }
        public DateTime? InvoiceDateTo { get; set; }
        public string? Status { get; set; }
        public int? page { get; set; }
    }
}
