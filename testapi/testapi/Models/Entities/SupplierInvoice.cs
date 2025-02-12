namespace testapi.Models
{
    public partial class SupplierInvoice
    {
        public SupplierInvoice()
        {
            SupplierInvoiceCosts = new HashSet<SupplierInvoiceCost>();
        }

        public int InvoiceId { get; set; }
        public int? SaleId { get; set; }
        public int? SupplierId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<SupplierInvoiceCost> SupplierInvoiceCosts { get; set; }
    }
}
