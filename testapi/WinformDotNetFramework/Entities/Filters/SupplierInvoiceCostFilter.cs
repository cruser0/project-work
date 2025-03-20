namespace WinformDotNetFramework.Entities.Filters
{
    public class SupplierInvoiceCostFilter
    {
        public int? SupplierInvoiceCostSupplierInvoiceId { get; set; }

        public int? SupplierInvoiceCostCostFrom { get; set; }
        public int? SupplierInvoiceCostCostTo { get; set; }
        public int? SupplierInvoiceCostQuantity { get; set; }
        public string SupplierInvoiceCostName { get; set; }

        public string SupplierInvoiceCostRegistryCode { get; set; }

        public int? SupplierInvoiceCostPage { get; set; }
    }
}
