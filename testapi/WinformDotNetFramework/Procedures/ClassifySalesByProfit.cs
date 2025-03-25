using System;

namespace WinformDotNetFramework.Procedures
{
    public class ClassifySalesByProfit
    {
        public int? SaleID { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string BoLNumber { get; set; }
        public string BookingNumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string CountryRegion { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal Profit { get; set; }
        public string SaleMargins { get; set; }

    }
}
