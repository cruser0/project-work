using System.Collections.Generic;

namespace Entity_Valdidator.Entity.Entities
{
    public class Status
    {
        public Status()
        {
            Sales = new HashSet<Sale>();
            CustomerInvoices = new HashSet<CustomerInvoice>();
            SupplierInvoices = new HashSet<SupplierInvoice>();
        }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}
