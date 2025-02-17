namespace API.Models.Filters
{
    public class SupplierInvoiceCostFilter
    {
        public int? SupplierInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }

    }
}
