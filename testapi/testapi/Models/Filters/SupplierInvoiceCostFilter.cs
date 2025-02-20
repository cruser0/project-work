namespace API.Models.Filters
{
    public class SupplierInvoiceCostFilter
    {
        public int? SupplierInvoiceId { get; set; }

        public int? CostFrom { get; set; }
        public int? CostTo { get; set; }
        public int? Quantity { get; set; }

        public int? page { get; set; }
    }
}
