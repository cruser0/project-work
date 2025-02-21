namespace API.Models.Entities
{
    public class CustomerInvoiceCost
    {
        public int CustomerInvoiceCostsId { get; set; }
        public int? CustomerInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string? Name { get; set; }

        public virtual CustomerInvoice? CustomerInvoice { get; set; }
    }
}
