using API.Models.Entities;

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

public class SupplierInvoiceSupplierDTO : SupplierInvoiceDTOGet
{
    public string? SupplierName { get; set; }
    public string? Country { get; set; }
    public SupplierInvoiceSupplierDTO(SupplierInvoice si, Supplier s)
    {
        InvoiceId = si.InvoiceId;
        InvoiceDate = si.InvoiceDate;
        SupplierName = s.SupplierName;
        Country = s.Country;
        SupplierId = si.SupplierId;
        SaleId = si.SaleId;
        InvoiceAmount = si.InvoiceAmount;
        InvoiceDate = si.InvoiceDate;
        Status = si.Status;
    }
}
