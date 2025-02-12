namespace testapi.Models
{
    public partial class Sale
    {
        public Sale()
        {
            CustomerInvoices = new HashSet<CustomerInvoice>();
            SupplierInvoices = new HashSet<SupplierInvoice>();
        }

        public int SaleId { get; set; }
        public string? BookingNumber { get; set; }
        public string? BoLnumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string? Status { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}
