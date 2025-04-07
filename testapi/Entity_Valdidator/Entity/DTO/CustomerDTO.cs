using Entity_Validator.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class CustomerDTO
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        public string CustomerName { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
        [RegularExpression("^[A-Za-z\\s]+$", ErrorMessage = "Only alphabetical characters are allowed.")]
        public string Country { get; set; }

        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsPost { get; set; }

    }

    public class CustomerDTOGet : CustomerDTO
    {
        public int? CustomerId { get; set; }

        public int? OriginalID { get; set; }
    }
}
