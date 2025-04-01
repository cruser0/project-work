using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class SupplierDTO
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string SupplierName { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        [RegularExpression("^[A-Za-z\\s]+$", ErrorMessage = "Only alphabetical characters are allowed.")]
        public string Country { get; set; }

        [RequiredIf("IsPost", true)]
        public bool? Deprecated { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsPost { get; set; }
    }
    public class SupplierDTOGet : SupplierDTO
    {
        public int? SupplierId { get; set; }

        public int? OriginalID { get; set; }
    }
}