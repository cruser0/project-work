namespace API.Models.DTO
{
    public class testDTO
    {
        public testDTO(List<CustomerDTOGet> c, List<SaleDTOGet> s, List<CustomerInvoiceDTOGet> ci, List<CustomerInvoiceCostDTOGet> cic)
        {
            customers = c;
            sales = s;
            invoices = ci;
            invoiceCosts = cic;
        }

        public List<CustomerDTOGet> customers { get; set; }
        public List<SaleDTOGet> sales { get; set; }
        public List<CustomerInvoiceDTOGet> invoices { get; set; }
        public List<CustomerInvoiceCostDTOGet> invoiceCosts { get; set; }


    }
}
