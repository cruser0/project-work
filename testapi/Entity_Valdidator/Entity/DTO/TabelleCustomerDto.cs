using System.Collections.Generic;

namespace Entity_Validator.Entity.DTO
{
    public class TabelleCustomerDto
    {
        public TabelleCustomerDto(List<CustomerDTOGet> c, List<SaleDTOGet> s, List<CustomerInvoiceDTOGet> ci, List<CustomerInvoiceCostDTOGet> cic)
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

    public class TabelleSupplierDto
    {
        public TabelleSupplierDto(List<SupplierDTOGet> c, List<SupplierInvoiceDTOGet> ci, List<SupplierInvoiceCostDTOGet> cic)
        {
            suppliers = c;
            invoices = ci;
            invoiceCosts = cic;
        }

        public List<SupplierDTOGet> suppliers { get; set; }
        public List<SupplierInvoiceDTOGet> invoices { get; set; }
        public List<SupplierInvoiceCostDTOGet> invoiceCosts { get; set; }


    }
}
