namespace API.Models.Entities
{
    public partial class CustomerInvoice
    {
        public CustomerInvoice()
        {
            CustomerInvoiceCosts = new HashSet<CustomerInvoiceCost>();
        }
        public int CustomerInvoiceID { get; set; }
        public int? SaleID { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? StatusID { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<CustomerInvoiceCost> CustomerInvoiceCosts { get; set; }
    }
}
