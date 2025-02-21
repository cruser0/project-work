namespace API.Models.Entities
{
    public partial class CustomerInvoice
    {
        public int CustomerInvoiceId { get; set; }
        public int? SaleId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual ICollection<CustomerInvoiceCost> CustomerInvoiceCosts { get; set; }
    }
}
