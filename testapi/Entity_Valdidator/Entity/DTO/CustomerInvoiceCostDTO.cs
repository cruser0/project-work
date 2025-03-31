using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public partial class CustomerInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? CustomerInvoiceId { get; set; }
        [RequiredIf("IsPost", true)]
        [Range(0.0, double.MaxValue)]
        public decimal? Cost { get; set; }
        [RequiredIf("IsPost", true)]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string Name { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string CostRegistryCode { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string CustomerInvoiceCode { get; set; }
        public bool IsPost { get; set; }

    }
    public class CustomerInvoiceCostDTOGet : CustomerInvoiceCostDTO
    {
        [RequiredIf("IsPost", true)]
        public int? CustomerInvoiceCostsId { get; set; }
    }
}
