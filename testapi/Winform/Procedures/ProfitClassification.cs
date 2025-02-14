namespace Winform.Procedures
{
    public class ProfitClassification
    {
        public int SaleID { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalSpent { get; set; }
        public decimal? Profit { get; set; }
        public string? SaleMargins { get; set; } // profit, no profit, risky
    }
}
