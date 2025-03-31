using System;

namespace Entity_Validator.Entity.Filters
{
    public class CustomerFilter
    {
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public bool? CustomerDeprecated { get; set; }
        public DateTime? CustomerCreatedDateFrom { get; set; }
        public DateTime? CustomerCreatedDateTo { get; set; }
        public int? CustomerOriginalID { get; set; }
        public int? CustomerPage { get; set; }
    }
}
