using System;

namespace Entity_Valdidator.Entity.DTO
{

public class CustomerInvoiceDTO
{
    public string CustomerInvoiceCode { get; set; }
    public int? SaleID { get; set; }
    public string SaleBookingNumber { get; set; }
    public string SaleBoL { get; set; }
    public decimal? InvoiceAmount { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string Status { get; set; }

}
public class CustomerInvoiceDTOGet : CustomerInvoiceDTO
{
    public int? CustomerInvoiceId { get; set; }
}
}

