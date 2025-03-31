using System.Collections.Generic;

namespace Entity_Validator.Entity.Entities
{
    public class CostRegistry
    {
        public CostRegistry()
        {
            CustomerInvoiceCosts = new HashSet<CustomerInvoiceCost>();
            SupplierInvoiceCosts = new HashSet<SupplierInvoiceCost>();

        }
        public int CostRegistryID { get; set; }
        public string CostRegistryUniqueCode { get; set; }
        public string CostRegistryName { get; set; }
        public decimal? CostRegistryPrice { get; set; }
        public int? CostRegistryQuantity { get; set; }

        public virtual ICollection<CustomerInvoiceCost> CustomerInvoiceCosts { get; set; }
        public virtual ICollection<SupplierInvoiceCost> SupplierInvoiceCosts { get; set; }
    }
}
