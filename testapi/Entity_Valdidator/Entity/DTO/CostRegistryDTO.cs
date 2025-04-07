using Entity_Validator.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class CostRegistryDTO
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CostRegistryUniqueCode { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CostRegistryName { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(0.0, double.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public decimal? CostRegistryPrice { get; set; }

        [RequiredIf("IsPost", true)]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be grater than 0.")]
        public int? CostRegistryQuantity { get; set; }


        public bool IsPost { get; set; }
    }
    public class CostRegistryDTOGet : CostRegistryDTO
    {
        public int? CostRegistryID { get; set; }
    }
}
