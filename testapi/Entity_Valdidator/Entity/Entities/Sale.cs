using System;
using System.Collections.Generic;

namespace Entity_Validator.Entity.Entities

{
    public partial class Sale
    {
        public Sale()
        {
            CustomerInvoices = new HashSet<CustomerInvoice>();
            SupplierInvoices = new HashSet<SupplierInvoice>();
        }

        public int SaleID { get; set; }
        public string BookingNumber { get; set; }
        public string BoLnumber { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? CustomerID { get; set; }
        public decimal? TotalRevenue { get; set; }
        public int? StatusID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual ICollection<SupplierInvoice> SupplierInvoices { get; set; }
    }
}
