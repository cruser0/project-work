namespace Winform.Entities.DTO
{
    internal class CustomerGroupDTO
    {
        public List<Customer> customers { get; set; }
        public List<Sale> sales { get; set; }
        public List<CustomerInvoice> invoices { get; set; }
        public List<CustomerInvoiceCost> invoiceCosts { get; set; }
    }
}
