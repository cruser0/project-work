﻿using System;

namespace Entity_Valdidator.Entity.Filters
{
    public class SupplierInvoiceFilter
    {
        public int? SupplierInvoiceSaleID { get; set; }
        public string SupplierInvoiceSaleBoL { get; set; }
        public string SupplierInvoiceSaleBk { get; set; }
        public string SupplierInvoiceCode { get; set; }
        public DateTime? SupplierInvoiceInvoiceDateFrom { get; set; }
        public DateTime? SupplierInvoiceInvoiceDateTo { get; set; }

        public int? SupplierInvoiceInvoiceAmountFrom { get; set; }
        public int? SupplierInvoiceInvoiceAmountTo { get; set; }

        public string SupplierInvoiceStatus { get; set; }
        public int? SupplierInvoicePage { get; set; }
    }

    public class SupplierInvoiceSupplierFilter : SupplierInvoiceFilter
    {
        public string SupplierInvoiceSupplierName { get; set; }
        public string SupplierInvoiceSupplierCountry { get; set; }
    }
}
