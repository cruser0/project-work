using System;

namespace WinformDotNetFramework.Entities
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public string BookingNumber { get; set; }
        public string BoLnumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string Status { get; set; }

    }
}
