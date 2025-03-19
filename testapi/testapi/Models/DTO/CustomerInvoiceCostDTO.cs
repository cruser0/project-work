namespace API.Models.DTO
{
    public partial class CustomerInvoiceCostDTO
    {
        public int? CustomerInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string? Name { get; set; }
        public string? CostRegistryCode { get; set; }

    }
    public class CustomerInvoiceCostDTOGet : CustomerInvoiceCostDTO
    {
        public int? CustomerInvoiceCostsId { get; set; }
    }
}
