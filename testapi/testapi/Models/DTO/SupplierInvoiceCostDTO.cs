namespace API.Models.DTO;

public partial class SupplierInvoiceCostDTO
{
    public int? SupplierInvoiceId { get; set; }
    public decimal? Cost { get; set; }
    public int? Quantity { get; set; }
    public string? Name { get; set; }

}
public class SupplierInvoiceCostDTOGet : SupplierInvoiceCostDTO
{
    public int SupplierInvoiceCostsId { get; set; }
}

