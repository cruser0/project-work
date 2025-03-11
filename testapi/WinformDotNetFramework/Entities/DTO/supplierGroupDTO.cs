using System.Collections.Generic;

namespace WinformDotNetFramework.Entities.DTO
{
    internal class supplierGroupDTO
    {
        public List<Supplier> suppliers { get; set; }
        public List<SupplierInvoice> invoices { get; set; }
        public List<SupplierInvoiceCost> invoiceCosts { get; set; }
    }
}
