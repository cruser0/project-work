namespace API.Models.DTO
{
    public class testDTO
    {
        public testDTO(CustomerDTOGet c, SaleDTOGet s, CustomerInvoiceDTOGet ci, CustomerInvoiceCostDTOGet cic)
        {
            customers = c;
            sales = s;
            invoices = ci;
            invoiceCosts = cic;
        }

        public CustomerDTOGet customers { get; set; }
        public SaleDTOGet sales { get; set; }
        public CustomerInvoiceDTOGet invoices { get; set; }
        public CustomerInvoiceCostDTOGet invoiceCosts { get; set; }


    }
}
