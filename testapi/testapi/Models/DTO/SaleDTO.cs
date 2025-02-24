using API.Models.Entities;

namespace API.Models.DTO;

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
public class SaleCustomerDTO : SaleDTOGet
{
    public string? CustomerName { get; set; }
    public string? Country { get; set; }
    public SaleCustomerDTO(Sale sale,Customer customer)
    {
        SaleId = sale.SaleId;
        BookingNumber = sale.BookingNumber;
        BoLnumber = sale.BoLnumber;
        SaleDate=sale.SaleDate;
        CustomerId = sale.CustomerId;
        TotalRevenue=sale.TotalRevenue;
        Status = sale.Status;
        CustomerName = customer.CustomerName;
        Country = customer.Country;
    }
}