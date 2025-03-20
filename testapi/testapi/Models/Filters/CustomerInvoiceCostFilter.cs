namespace API.Models.Filters
{
    public class CustomerInvoiceCostFilter
    {
        public string? CustomerInvoiceCostCustomerInvoiceCode { get; set; }

        public int? CustomerInvoiceCostCostFrom { get; set; }
        public int? CustomerInvoiceCostCostTo { get; set; }
        public int? CustomerInvoiceCostQuantity { get; set; }
        public string? CustomerInvoiceCostName { get; set; }
        public int? CustomerInvoiceCostPage { get; set; }
        public string? RegistryCode { get; set; }
    }
}
