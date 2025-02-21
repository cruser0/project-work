namespace API.Models.Filters
{
    public class CustomerInvoiceCostFilter
    {
        public int? CustomerInvoiceId { get; set; }

        public int? CostFrom { get; set; }
        public int? CostTo { get; set; }
        public int? Quantity { get; set; }
        public string? Name { get; set; }

        public int? page { get; set; }
    }
}
