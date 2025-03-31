
using Entity_Validator.Entity.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class SupplierInvoiceDTO
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SupplierInvoiceCode { get; set; }

        [RequiredIf("IsPost", true)]
        public int? SaleId { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SaleBookingNumber { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(50)]
        public string SaleBoL { get; set; }

        [RequiredIf("IsPost", true)]
        public int? SupplierId { get; set; }

        [Range(0.0, 0.0, ErrorMessage = "{0} must be equal to 0.")]
        public decimal? InvoiceAmount { get; set; }

        [RequiredIf("IsPost", true)]
        public DateTime? InvoiceDate { get; set; }

        [RequiredIf("IsPost", true)]
        public string Status { get; set; }

        public bool IsPost { get; set; }
    }

    public class SupplierInvoiceDTOGet : SupplierInvoiceDTO
    {
        [RequiredIf("IsPost", true)]
        public int? SupplierInvoiceId { get; set; }
    }

    public class SupplierInvoiceSupplierDTO : SupplierInvoiceDTOGet
    {
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string SupplierName { get; set; }

        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only alphabetical characters and spaces are allowed.")]
        public string Country { get; set; }
        public SupplierInvoiceSupplierDTO(SupplierInvoice si, Supplier s)
        {
            SupplierInvoiceCode = si.SupplierInvoiceCode;
            SupplierInvoiceId = si.SupplierInvoiceID;
            InvoiceDate = si.InvoiceDate;
            SupplierName = s.SupplierName;
            Country = s.Country.CountryName;
            SupplierId = si.SupplierID;
            SaleId = si.SaleID;
            SaleBookingNumber = si.Sale.BookingNumber;
            SaleBoL = si.Sale.BoLnumber;
            InvoiceAmount = si.InvoiceAmount;
            InvoiceDate = si.InvoiceDate;
            Status = si.Status.StatusName;
        }
    }
}