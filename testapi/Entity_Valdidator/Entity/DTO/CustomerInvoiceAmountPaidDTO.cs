using Entity_Validator.CustomAttributes;

namespace Entity_Validator.Entity.DTO
{
    public class CustomerInvoiceAmountPaidDTO
    {
        [AmountPaidRange("MaximumAmount")]
        public decimal? AmountPaid { get; set; }
        public decimal? MaximumAmount { get; set; }
        public int? CustomerInvoiceID { get; set; }
    }

    public class CustomerInvoiceAmountPaidDTOGet : CustomerInvoiceAmountPaidDTO
    {
        public int? CustomerInvoiceAmountPaidID { get; set; }
    }
}
