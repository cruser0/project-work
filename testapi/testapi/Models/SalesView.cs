namespace API.Models
{
    public partial class SalesView
    {
        public string? CustomerName { get; set; }
        public string? Country { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }
        public string? BoLnumber { get; set; }
        public string? BookingNumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? TotalRevenue { get; set; }
        public string? Expr1 { get; set; }
        public string? SupplierName { get; set; }
    }
}
