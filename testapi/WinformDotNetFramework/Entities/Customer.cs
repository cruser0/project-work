
using System;

namespace WinformDotNetFramework.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OriginalID { get; set; }
    }
}
