namespace Entity_Valdidator.Entity.Entities
{
    public class CustomerInvoiceCost
    {
        public int CustomerInvoiceCostsID { get; set; }
        public int? CustomerInvoiceID { get; set; }
        public decimal? Cost { get; set; }
        public int? CostRegistryID { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }


        public virtual CustomerInvoice CustomerInvoice { get; set; }
        public virtual CostRegistry CostRegistry { get; set; }
    }
}
