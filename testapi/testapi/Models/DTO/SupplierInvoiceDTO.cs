namespace API.Models.DTO;

public class SupplierInvoiceDTO
{

    public int? SaleId { get; set; }
    public int? SupplierId { get; set; }
    public decimal? InvoiceAmount { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string? Status { get; set; }

}

public class SupplierInvoiceDTOGet : SupplierInvoiceDTO
{
    public int? InvoiceId { get; set; }
}
