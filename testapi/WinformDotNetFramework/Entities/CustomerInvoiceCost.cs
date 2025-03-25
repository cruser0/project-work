namespace WinformDotNetFramework.Entities
{
    internal class CustomerInvoiceCost
    {
        public int CustomerInvoiceCostsId { get; set; }
        public int? CustomerInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string CostRegistryCode { get; set; }
        public string CustomerInvoiceCode { get; set; }
    }
    internal class CustomerInvoiceCostDTO
    {
        public int? CustomerInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public string CostRegistryCode { get; set; }
        public string CustomerInvoiceCode { get; set; }
    }
}
