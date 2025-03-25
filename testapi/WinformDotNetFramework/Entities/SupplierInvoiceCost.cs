namespace WinformDotNetFramework.Entities
{
    public partial class SupplierInvoiceCost
    {
        public int SupplierInvoiceCostsId { get; set; }
        public int? SupplierInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string CostRegistryCode { get; set; }
        public string SupplierInvoiceCode { get; set; }
    }
}
