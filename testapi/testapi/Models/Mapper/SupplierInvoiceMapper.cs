﻿using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class SupplierInvoiceMapper
    {
        public static SupplierInvoiceDTO Map(SupplierInvoice supplierInvoice)
        {
            return new SupplierInvoiceDTO()
            {

                SaleId = supplierInvoice.SaleID,
                SaleBoL = supplierInvoice.Sale.BoLnumber,
                SaleBookingNumber = supplierInvoice.Sale.BookingNumber,
                SupplierId = supplierInvoice.SupplierID,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                SupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status!.StatusName

            };
        }
        public static SupplierInvoice Map(SupplierInvoiceDTO supplierInvoice, Status? status, Sale? sale)
        {
            return new SupplierInvoice()
            {

                SaleID = supplierInvoice.SaleId,
                SupplierID = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                SupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = status,
                StatusID = status?.StatusID,
                Sale = sale
            };
        }

        public static SupplierInvoiceDTOGet MapGet(SupplierInvoice supplierInvoice)
        {
            return new SupplierInvoiceDTOGet()
            {

                InvoiceId = supplierInvoice.SupplierInvoiceID,
                SaleId = supplierInvoice.SaleID,
                SaleBoL = supplierInvoice.Sale.BoLnumber,
                SaleBookingNumber = supplierInvoice.Sale.BookingNumber,
                SupplierId = supplierInvoice.SupplierID,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                SupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = supplierInvoice.Status!.StatusName

            };
        }
        public static SupplierInvoice MapGet(SupplierInvoiceDTOGet supplierInvoice, Status? status, Sale? sale)
        {
            return new SupplierInvoice()
            {

                SupplierInvoiceID = (int)supplierInvoice.InvoiceId!,
                SaleID = supplierInvoice.SaleId,
                SupplierID = supplierInvoice.SupplierId,
                InvoiceAmount = supplierInvoice.InvoiceAmount,
                SupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode,
                InvoiceDate = supplierInvoice.InvoiceDate,
                Status = status,
                StatusID = status.StatusID,
                Sale = sale

            };
        }
    }
}
