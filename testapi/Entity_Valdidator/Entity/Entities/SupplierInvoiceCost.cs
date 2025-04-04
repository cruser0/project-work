namespace Entity_Validator.Entity.Entities
{
    public partial class SupplierInvoiceCost
    {
        public int SupplierInvoiceCostsId { get; set; }
        public int? CostRegistryID { get; set; }
        public int? SupplierInvoiceId { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalCost { get; set; }

        public string Name { get; set; }
        public int? CustomerInvoiceCostID { get; set; }


        public virtual CostRegistry CostRegistry { get; set; }
        public virtual CustomerInvoiceCost CustomerInvoiceCost { get; set; }

        public virtual SupplierInvoice SupplierInvoice { get; set; }
    }
}
