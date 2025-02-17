namespace API.Models.Filters
{
    public class SaleFilter
    {
        public string? BookingNumber { get; set; }
        public string? BoLnumber { get; set; }
        public DateTime? SaleDateFrom { get; set; }
        public DateTime? SaleDateTo { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string? Status { get; set; }
    }
}
