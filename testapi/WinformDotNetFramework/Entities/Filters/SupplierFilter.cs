using System;

namespace WinformDotNetFramework.Entities.Filters
{
    public class SupplierFilter
    {
        public string SupplierName { get; set; }
        public string SupplierCountry { get; set; }
        public bool? SupplierDeprecated { get; set; }
        public int? SupplierPage { get; set; }
        public DateTime? SupplierCreatedDateFrom { get; set; }
        public DateTime? SupplierCreatedDateTo { get; set; }
        public int? SupplierOriginalID { get; set; }
    }
}
