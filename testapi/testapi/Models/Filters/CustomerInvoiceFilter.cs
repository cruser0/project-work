namespace API.Models.Filters
{
    public class CustomerInvoiceFilter
    {
        public int? CustomerInvoiceSaleId { get; set; }

        public int? CustomerInvoiceInvoiceAmountFrom { get; set; }
        public int? CustomerInvoiceInvoiceAmountTo { get; set; }

        public DateTime? CustomerInvoiceInvoiceDateFrom { get; set; }
        public DateTime? CustomerInvoiceInvoiceDateTo { get; set; }
        public string? CustomerInvoiceStatus { get; set; }
        public int? CustomerInvoicePage { get; set; }
    }
}
