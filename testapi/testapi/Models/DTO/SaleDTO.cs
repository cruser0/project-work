namespace testapi.Models.DTO;

public class SaleDTO
{

    public string? BookingNumber { get; set; }
    public string? BoLnumber { get; set; }
    public DateTime? SaleDate { get; set; }
    public int? CustomerId { get; set; }
    public decimal? TotalRevenue { get; set; }
    public string? Status { get; set; } //active/closed
}

public class SaleDTOGet : SaleDTO
{
    public int? SaleId { get; set; }
}
