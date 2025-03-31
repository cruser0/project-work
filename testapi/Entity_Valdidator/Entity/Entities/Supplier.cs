using System;
using System.Collections.Generic;

namespace Entity_Validator.Entity.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierInvoices = new HashSet<SupplierInvoice>();
        }

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public bool? Deprecated { get; set; }
        public int? CountryID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int OriginalID { get; set; }

        public virtual ICollection<SupplierInvoice> SupplierInvoices { get; set; }
        public virtual Country Country { get; set; }
    }
}
