using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public partial class CustomerInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? CustomerInvoiceId { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(0.0, double.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public decimal? Cost { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public int? Quantity { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string Name { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CostRegistryCode { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50, ErrorMessage = "Must be at most {1} characters.")]
        public string CustomerInvoiceCode { get; set; }

        public bool IsPost { get; set; }


    }
    public class CustomerInvoiceCostDTOGet : CustomerInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? CustomerInvoiceCostsId { get; set; }
    }
}
