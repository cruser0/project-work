namespace Entity_Validator.Entity.Entities
{
    public class CustomerInvoiceAmountPaid
    {
        public int CustomerInvoiceAmountPaidID { get; set; }
        public decimal? AmountPaid { get; set; }
        public int? CustomerInvoiceID { get; set; }
        public virtual CustomerInvoice CustomerInvoice { get; set; }
    }
}
