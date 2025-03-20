using System;

namespace WinformDotNetFramework.Entities.Filters
{
    public class SupplierInvoiceFilter
    {
        public int? SupplierInvoiceSaleID { get; set; }
        public int? SupplierInvoiceSupplierID { get; set; }
        public DateTime? SupplierInvoiceInvoiceDateFrom { get; set; }
        public DateTime? SupplierInvoiceInvoiceDateTo { get; set; }

        public int? SupplierInvoiceInvoiceAmountFrom { get; set; }
        public int? SupplierInvoiceInvoiceAmountTo { get; set; }

        public string SupplierInvoiceStatus { get; set; }
        public int? SupplierInvoicePage { get; set; }

        public string SupplierInvoiceSupplierName { get; set; }
        public string SupplierInvoiceSupplierCountry { get; set; }
    }
}
