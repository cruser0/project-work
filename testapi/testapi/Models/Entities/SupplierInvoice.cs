namespace API.Models.Entities
{
    public partial class SupplierInvoice
    {
        public SupplierInvoice()
        {
            SupplierInvoiceCosts = new HashSet<SupplierInvoiceCost>();
        }

        public int SupplierInvoiceID { get; set; }
        public string? SupplierInvoiceCode { get; set; }
        public int? SaleID { get; set; }
        public int? SupplierID { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? StatusID { get; set; }

        public virtual Sale? Sale { get; set; }
        public virtual Status? Status { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<SupplierInvoiceCost> SupplierInvoiceCosts { get; set; }
    }
}
