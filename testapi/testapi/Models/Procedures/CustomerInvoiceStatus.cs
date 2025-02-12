namespace testapi.Models
{
    public class CustomerInvoiceStatus
    {

        public int? CustomerInvoiceID { get; set; }
        public int? SaleID { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }
    }
}
