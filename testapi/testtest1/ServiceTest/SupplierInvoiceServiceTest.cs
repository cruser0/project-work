using API.Models;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API_Test.ServiceTest
{
    public class SupplierInvoiceServiceTest
    {
        private readonly SupplierInvoiceService _supplierInvoiceService;
        private readonly Mock<ISupplierInvoiceCostService> _mockSupplierInvoiceCostService;
        private readonly Progetto_FormativoContext _context;

        public SupplierInvoiceServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);
            _mockSupplierInvoiceCostService = new Mock<ISupplierInvoiceCostService>();

            // Initialize repository
            _supplierInvoiceService = new SupplierInvoiceService(_context, _mockSupplierInvoiceCostService.Object);
        }

        [Fact]
        public void supplierInvoiceService_ReturnCorrect_GetAllSupplierInvoices()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };

            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var result = _supplierInvoiceService.GetAllSupplierInvoices();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void saleService_ReturnCorrect_GetAllSupplierInvoices_NoInvoices()
        {

            var result = _supplierInvoiceService.GetAllSupplierInvoices();

            Assert.Equal(0, result.Count);

        }

        [Fact]
        public void supplierInvoiceService_ReturnCorrect_GetSupplierInvoiceById()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };

            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var result = _supplierInvoiceService.GetSupplierInvoiceById(1);

            Assert.NotNull(result);
            Assert.IsType<SupplierInvoiceDTOGet>(result);
            Assert.Equal(1, result.InvoiceId);
        }

        [Fact]
        public void supplierService_ThrowException_GetSupplierInvoiceById()
        {

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.GetSupplierInvoiceById(1));
            Assert.Equal("Supplier Invoice not found!", exception.Message);
        }

        [Fact]
        public void supplierInvoiceService_ReturnCorrect_CreateSupplierInvoice()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();


            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };
            _context.Sales.Add(sale);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };
            var createdSI = _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice);

            Assert.NotNull(createdSI);
            Assert.IsType<SupplierInvoiceDTOGet>(createdSI);
            Assert.Equal(1, createdSI.InvoiceId);
            Assert.True(_context.SupplierInvoices.Any(x => x.InvoiceId == supplierInvoice.InvoiceId));
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplierInvoice_NullSupplInvoice()
        {

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.CreateSupplierInvoice((SupplierInvoice)null));
            Assert.Equal("Couldn't create supplier Invoice", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplierInvoice_WrongSupplierId()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice));
            Assert.Equal("SupplierID not found", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplierInvoice_WrongSaleId()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice));
            Assert.Equal("SaleID not found", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplierInvoice_WrongStatus()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };
            _context.Sales.Add(sale);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "status"
            };


            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice));
            Assert.Equal("Status is not valid", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplierInvoice_InvalidDate()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };
            _context.Sales.Add(sale);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = null,
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice));
            Assert.Equal("Date is not valid", exception.Message);
        }

        [Fact]
        public void supplierInvoiceService_ReturnCorrect_UpdateSupplierInvoice()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" },
                new Supplier() { SupplierId = 2, SupplierName = "ciao", Country = "ciao" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();


            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn1", BoLnumber = "bol1", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" },
                new Sale() { SaleId = 2, BookingNumber = "bn2", BoLnumber = "bol2", SaleDate = new DateTime(2025, 1, 2, 0, 0, 0), CustomerId = 2, TotalRevenue = 100, Status = "Closed" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            var createdSI = _supplierInvoiceService.CreateSupplierInvoice(supplierInvoice);

            var updatedSupplierInvoice = new SupplierInvoice()
            {
                SaleId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2025, 1, 2, 0, 0, 0),
                Status = "Approved"
            };

            var updatedSI = _supplierInvoiceService.UpdateSupplierInvoice(1, supplierInvoice);

            Assert.NotNull(updatedSI);
            Assert.IsType<SupplierInvoiceDTOGet>(updatedSI);
            Assert.Equal(1, updatedSI.InvoiceId);
            Assert.True(_context.SupplierInvoices.Any(x => x.InvoiceId == updatedSI.InvoiceId));
        }

        [Fact]
        public void supplierService_ThrowException_UpdateSupplierInvoice_NullSupplInvoice()
        {
            var updatedSupplierInvoice = new SupplierInvoice()
            {
                SaleId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2025, 1, 2, 0, 0, 0),
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.UpdateSupplierInvoice(1, updatedSupplierInvoice));
            Assert.Equal("Supplier Invoice not found", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_UpdateSupplierInvoice_WrongSaleId()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var updatedSupplierInvoice = new SupplierInvoice()
            {
                SaleId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2025, 1, 2, 0, 0, 0),
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.UpdateSupplierInvoice(1, updatedSupplierInvoice));
            Assert.Equal("SaleID not present", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_UpdateSupplierInvoice_WrongSupplierId()
        {
            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn1", BoLnumber = "bol1", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" },
                new Sale() { SaleId = 2, BookingNumber = "bn2", BoLnumber = "bol2", SaleDate = new DateTime(2025, 1, 2, 0, 0, 0), CustomerId = 2, TotalRevenue = 100, Status = "Closed" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var updatedSupplierInvoice = new SupplierInvoice()
            {
                SaleId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2025, 1, 2, 0, 0, 0),
                Status = "Approved"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.UpdateSupplierInvoice(1, updatedSupplierInvoice));
            Assert.Equal("SupplierID not present", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowException_UpdateSupplierInvoice_WrongStatus()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { SupplierId = 1, SupplierName = "ciao", Country = "ciao" },
                new Supplier() { SupplierId = 2, SupplierName = "ciao", Country = "ciao" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();


            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn1", BoLnumber = "bol1", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" },
                new Sale() { SaleId = 2, BookingNumber = "bn2", BoLnumber = "bol2", SaleDate = new DateTime(2025, 1, 2, 0, 0, 0), CustomerId = 2, TotalRevenue = 100, Status = "Closed" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var updatedSupplierInvoice = new SupplierInvoice()
            {
                SaleId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2025, 1, 2, 0, 0, 0),
                Status = "Status"
            };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierInvoiceService.UpdateSupplierInvoice(1, updatedSupplierInvoice));
            Assert.Equal("Status not correct", exception.Message);
        }

        [Fact]
        public void supplierService_ReturnCorrect_DeleteSupplierinvoice_NoCascade()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var supplierInvoiceDeleted = _supplierInvoiceService.DeleteSupplierInvoice(1);

            Assert.NotNull(supplierInvoiceDeleted);
            Assert.IsType<SupplierInvoiceDTOGet>(supplierInvoiceDeleted);
            Assert.Equal(1, supplierInvoiceDeleted.InvoiceId);
        }

        [Fact]
        public void supplierService_ReturnCorrect_DeleteSupplierinvoice_Cascade()
        {
            var supplierInvoice = new SupplierInvoice()
            {
                SaleId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unapproved"
            };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            var supplierInvoiceCosts = new List<SupplierInvoiceCost>
            {
                new SupplierInvoiceCost() { SupplierInvoiceId = 1, Cost = 100, Quantity = 1 },
                new SupplierInvoiceCost() { SupplierInvoiceId = 1, Cost = 100, Quantity = 1 },
                new SupplierInvoiceCost() { SupplierInvoiceId = 1, Cost = 100, Quantity = 1 }
            };
            _context.SupplierInvoiceCosts.AddRange(supplierInvoiceCosts);
            _context.SaveChanges();

            var supplierInvoiceDeleted = _supplierInvoiceService.DeleteSupplierInvoice(1);

            Assert.NotNull(supplierInvoiceDeleted);
            Assert.IsType<SupplierInvoiceDTOGet>(supplierInvoiceDeleted);
            Assert.Equal(1, supplierInvoiceDeleted.InvoiceId);
            _mockSupplierInvoiceCostService.Verify(s => s.DeleteSupplierInvoiceCost((int)supplierInvoiceDeleted.InvoiceId), Times.Once);
        }

        [Fact]
        public void supplierService_ThrowException_DeleteSupplierinvoice()
        {

            var exception = Assert.Throws<ArgumentNullException>(
                () => _supplierInvoiceService.DeleteSupplierInvoice(1));
            Assert.Equal("Supplier Invoice not found!", exception.ParamName);

        }
    }
}
