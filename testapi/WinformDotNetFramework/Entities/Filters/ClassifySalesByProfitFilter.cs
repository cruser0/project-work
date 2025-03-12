

namespace WinformDotNetFramework.Entities.Filters
{
    public class ClassifySalesByProfitFilter
    {
        public int? TotalSpentFrom { get; set; }
        public int? TotalSpentTo { get; set; }
        public int? TotalRevenueFrom { get; set; }
        public int? TotalRevenueTo { get; set; }
        public string FilterMargin { get; set; }
        public int? ProfitFrom { get; set; }
        public int? ProfitTo { get; set; }
        public string BoLNumber { get; set; }
        public string BKNumber { get; set; }
        public int? CustomerID { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public int? SaleID { get; set; }
    }
}
