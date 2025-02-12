namespace testapi.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierInvoices = new HashSet<SupplierInvoice>();
        }

        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}
