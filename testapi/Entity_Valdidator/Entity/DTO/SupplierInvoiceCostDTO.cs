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
        [Range(0.0, int.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public int? Quantity { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string Name { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string CostRegistryCode { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SupplierInvoiceCode { get; set; }

        public bool IsPost { get; set; }

    }
    public class SupplierInvoiceCostDTOGet : SupplierInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? SupplierInvoiceCostsId { get; set; }
    }

}