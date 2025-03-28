using System;

namespace WinformDotNetFramework.Entities.Filters
{
    public class SaleFilter
    {
        public string SaleBoLnumber { get; set; }
        public string SaleBookingNumber { get; set; }
        public DateTime? SaleDateFrom { get; set; }
        public DateTime? SaleDateTo { get; set; }

        public int? SaleRevenueFrom { get; set; }
        public int? SaleRevenueTo { get; set; }

        public string SaleStatus { get; set; }
        public int? SalePage { get; set; }


        public string SaleCustomerName { get; set; }
        public string SaleCustomerCountry { get; set; }
    }
}
