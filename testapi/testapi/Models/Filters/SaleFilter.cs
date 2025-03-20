namespace API.Models.Filters
{
    public class SaleFilter
    {
        public string? SaleBookingNumber { get; set; }
        public string? SaleBoLnumber { get; set; }
        public DateTime? SaleDateFrom { get; set; }
        public DateTime? SaleDateTo { get; set; }

        public int? SaleRevenueFrom { get; set; }
        public int? SaleRevenueTo { get; set; }

        public string? SaleStatus { get; set; }
        public int? SalePage { get; set; }
    }

    public class SaleCustomerFilter : SaleFilter
    {
        public string? SaleCustomerName { get; set; }
        public string? SaleCustomerCountry { get; set; }
    }
}
