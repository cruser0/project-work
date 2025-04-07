using System.Collections.Generic;

namespace Entity_Validator.Entity.DTO
{
    public class MakeCustomerInvoiceDTO
    {
        public int SaleID { get; set; }
        public List<int> SupplierInvoiceIDs { get; set; }
        public decimal? FixedSurcharge { get; set; }
        public decimal? PercentSurcharge { get; set; }
    }
}
