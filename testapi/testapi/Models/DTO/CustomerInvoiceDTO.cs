namespace API.Models.DTO;

public class CustomerInvoiceDTO
{
    public int? SaleId { get; set; }
    public decimal? InvoiceAmount { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string? Status { get; set; }

}
public class CustomerInvoiceDTOGet : CustomerInvoiceDTO
{
    public int? CustomerInvoiceId { get; set; }
}
