using Entity_Validator.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{

    public class CustomerInvoiceDTO
    {
        [MaxLength(50)]
        public string CustomerInvoiceCode { get; set; }

        [RequiredIf("IsPost", true)]
        public int? SaleID { get; set; }

        public int? AmountPaidID { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SaleBookingNumber { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SaleBoL { get; set; }

        [Range(0.0, 0.0, ErrorMessage = "{0} must be equal to 0.")]
        public decimal? InvoiceAmount { get; set; }

        [RequiredIf("IsPost", true)]
        public DateTime? InvoiceDate { get; set; }

        [RequiredIf("IsPost", true)]
        public string Status { get; set; }

        public bool IsPost { get; set; }

    }
    public class CustomerInvoiceDTOGet : CustomerInvoiceDTO
    {
        public int? CustomerInvoiceId { get; set; }
    }
    public class CustomerInvoiceTotalAmountPaidDTO: CustomerInvoiceDTOGet
    {
        [AmountPaidRange("MaximumAmount")]
        public decimal? AmountPaid { get; set; }
        public decimal? MaximumAmount { get; set; }
    }
}

