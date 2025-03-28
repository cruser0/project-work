using System;

namespace Entity_Valdidator.Entity.Procedures
{
    public class TotalAmountSpentPerSuppliers
    {
        public int? SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OriginalID { get; set; }
        public decimal? TotalAmountInvoiced { get; set; }
    }
}
