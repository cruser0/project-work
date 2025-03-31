using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class SupplierDTO
    {
        [RequiredIf("IsPost",true)]
        [MaxLength(100)]
        public string SupplierName { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only alphabetical characters are allowed.")]
        public string Country { get; set; }

        [RequiredIf("IsPost", true)]
        public bool? Deprecated { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsPost { get; set; }
    }
    public class SupplierDTOGet : SupplierDTO
    {
        [RequiredIf("IsPost", true)]
        public int? SupplierId { get; set; }

        [RequiredIf("IsPost", true)]
        public int? OriginalID { get; set; }
    }
}