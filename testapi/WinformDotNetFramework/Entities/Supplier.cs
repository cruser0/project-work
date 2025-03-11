using System;

namespace WinformDotNetFramework.Entities
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Country { get; set; }
        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OriginalID { get; set; }

    }
}
