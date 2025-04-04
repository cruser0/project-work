using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{


    public partial class SupplierInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? SupplierInvoiceId { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(0.0, double.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public decimal? Cost { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be grater than 1.")]
        public int? Quantity { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string Name { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CostRegistryCode { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50, ErrorMessage = "Must be at most {1} characters.")]
        public string SupplierInvoiceCode { get; set; }

        public decimal? TotalCost { get; set; }

        public bool IsPost { get; set; }

    }
    public class SupplierInvoiceCostDTOGet : SupplierInvoiceCostDTO
    {
        public int? SupplierInvoiceCostsId { get; set; }
    }

}