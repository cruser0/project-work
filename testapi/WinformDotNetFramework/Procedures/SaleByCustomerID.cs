using System;

namespace WinformDotNetFramework.Procedures
{
    public class SaleByCustomerID
    {

        public int? SaleID { get; set; }
        public string BookingNumber { get; set; }
        public string BoLNumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? CustomerID { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string Status { get; set; }
    }
}
