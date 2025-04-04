using Entity_Validator.CustomAttributes;

namespace Entity_Validator.Entity.DTO
{
    public class CustomerInvoiceAmountPaidDTO
    {
        [AmountPaidRange("AmountToPay")]
        public decimal? AmountPaid { get; set; }
        public decimal? AmountToPay { get; set; }
        public int? CustomerInvoiceID { get; set; }
    }

    public class CustomerInvoiceAmountPaidDTOGet : CustomerInvoiceAmountPaidDTO
    {
        public int? CustomerInvoiceAmountPaidID { get; set; }
    }
}
