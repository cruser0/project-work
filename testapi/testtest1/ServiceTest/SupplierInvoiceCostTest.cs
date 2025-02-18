using API.Models;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API_Test.ServiceTest
{
    public class SupplierInvoiceCostTest
    {
        private readonly SupplierInvoiceCostServices _supplierService;
        private readonly Progetto_FormativoContext _context;

        public SupplierInvoiceCostTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            _context = new Progetto_FormativoContext(options);
            // Initialize repository
            _supplierService = new SupplierInvoiceCostServices(_context);
        }

        [Fact]
        public void Supplier_Invoice_Cost_Test_ReturnCorrect_GetAllSuppliers()
        {
            var supplierInvoice = new SupplierInvoice();
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var suppliers = new List<SupplierInvoiceCost>() { new SupplierInvoiceCost() { Quantity = 1, Cost = 100.0m, SupplierInvoiceId = 1 } };

            _context.SupplierInvoiceCosts.AddRange(suppliers);
            _context.SaveChanges();

            var filter = new SupplierInvoiceCostFilter();
            var result = _supplierService.GetAllSupplierInvoiceCosts(filter);

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void Supplier_Invoice_Cost_Test_ThrowException_GetAllSuppliers()
        {
            var filter = new SupplierInvoiceCostFilter();
            var result = _supplierService.GetAllSupplierInvoiceCosts(filter);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ReturnCorrect_GetSupplierById()
        {
            var supplierInvoice = new SupplierInvoice();
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var suppliers = new List<SupplierInvoiceCost>() { new SupplierInvoiceCost() { Quantity = 1, Cost = 100.0m, SupplierInvoiceId = 1 } };

            _context.SupplierInvoiceCosts.AddRange(suppliers);
            _context.SaveChanges();

            var result = _supplierService.GetSupplierInvoiceCostById(1);

            Assert.NotNull(result);
            Assert.IsType<SupplierInvoiceCostDTOGet>(result);
            Assert.Equal(1, result.SupplierInvoiceCostsId);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ThrowException_GetSupplierById()
        {

            var exception = Assert.Throws<ArgumentException>(() => _supplierService.GetSupplierInvoiceCostById(1));
            Assert.Equal("Supplier Invoice Cost not found!", exception.Message);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ReturnCorrect_CreateSupplier()
        {
            var supplierInvoice = new SupplierInvoice();
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var supplier = new SupplierInvoiceCost() { Quantity = 1, Cost = 100.0m, SupplierInvoiceId = 1 };

            var result = _supplierService.CreateSupplierInvoiceCost(supplier);

            Assert.NotNull(result);
            Assert.IsType<SupplierInvoiceCostDTOGet>(result);
            Assert.Equal(1, result.SupplierInvoiceCostsId);
            Assert.True(_context.SupplierInvoiceCosts.Any(x => x.SupplierInvoiceCostsId == supplier.SupplierInvoiceCostsId));
        }

        [Fact]
        public void Supplier_Invoice_Cost_ThrowException_CreateSupplier_NullSupplier()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierService.CreateSupplierInvoiceCost(null));
            Assert.Equal("Value cannot be null. (Parameter 'Couldn't create supplier Invoice Cost')", exception.Message);
        }

        [Theory]
        [InlineData(null, 100, 1)]
        [InlineData(1, null, 1)]
        [InlineData(1, 100, null)]
        [InlineData(1, 100, 13)]
        public void Supplier_Invoice_Cost__ThrowException_CreateSupplier_NullFields(int? quantity, double? cost, int? supplierInvoiceId)
        {

            var supplierInvoice = new SupplierInvoice();
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var supplier = new SupplierInvoiceCost() { Quantity = quantity, Cost = (decimal?)cost, SupplierInvoiceId = supplierInvoiceId };

            var exception = Assert.Throws<ArgumentException>(() => _supplierService.CreateSupplierInvoiceCost(supplier));
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            if (supplierInvoiceId == null)
                Assert.Equal("Supplier Invoice Id can't be null!", actionResult);
            if (!_context.SupplierInvoices.Any(x => x.InvoiceId == 1))
                Assert.Equal("Supplier Invoice Id not found!", actionResult);
            if (cost < 0 || quantity < 1 || cost == null || quantity == null)
                Assert.Equal("Values can't be lesser than 1 or null", actionResult);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ReturnCorrect_UpdateSupplier()
        {
            //Arrange
            var supplierInvoice = new SupplierInvoice { InvoiceId = 1 };
            var supplierInvoice1 = new SupplierInvoice { InvoiceId = 2 };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SupplierInvoices.Add(supplierInvoice1);
            _context.SaveChanges();
            var supplier = new SupplierInvoiceCost() { Quantity = 1, Cost = 100.0m, SupplierInvoiceId = 1 };
            var supplierUpdate = new SupplierInvoiceCost() { Quantity = 13, Cost = 1200.0m, SupplierInvoiceId = 2 };
            _context.SupplierInvoiceCosts.Add(supplier);
            _context.SaveChanges();
            //Act
            var result = _supplierService.UpdateSupplierInvoiceCost(1, supplierUpdate);
            //Assert
            var actionResult = Assert.IsType<SupplierInvoiceCostDTOGet>(result);
            Assert.Equal(supplierUpdate.Quantity, actionResult.Quantity);
            Assert.Equal(supplierUpdate.Cost, actionResult.Cost);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ThrowError_Update_Supplier_Invoice()
        {
            var supplierInvoice = new SupplierInvoice();
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var supplier = new SupplierInvoiceCost() { Quantity = 1, Cost = 100.0m, SupplierInvoiceId = 1 };
            var supplierUpdate = new SupplierInvoiceCost() { Quantity = 13, Cost = 1200.0m, SupplierInvoiceId = 2 };
            _context.SupplierInvoiceCosts.Add(supplier);
            _context.SaveChanges();

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierService.UpdateSupplierInvoiceCost(1, supplierUpdate));
            var action = Assert.IsType<ArgumentNullException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Value cannot be null. (Parameter 'Supplier Invoice not Found')", actionResult);
        }
        public void Supplier_Invoice_Cost_ThrowError_Update_Id_not_found()
        {


            var supplierUpdate = new SupplierInvoiceCost() { Quantity = 13, Cost = 1200.0m, SupplierInvoiceId = 2 };
            var exception = Assert.Throws<ArgumentNullException>(() => _supplierService.UpdateSupplierInvoiceCost(1, supplierUpdate));
            var action = Assert.IsType<ArgumentNullException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Supplier Invoice Cost not found", actionResult);
        }

        [Fact]
        public void Supplier_Invoice_Cost_ReturnCorrect_DeleteSupplier()
        {
            //Arrange
            var supplierInvoice = new SupplierInvoice { InvoiceAmount = 100.0m };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();
            var supplier = new SupplierInvoiceCost() { Quantity = 1, Cost = 50.0m, SupplierInvoiceId = 1 };
            _context.SupplierInvoiceCosts.Add(supplier);
            _context.SaveChanges();

            //Act
            var result = _supplierService.DeleteSupplierInvoiceCost(1);
            //Assert
            var actionResult = Assert.IsType<SupplierInvoiceCostDTOGet>(result);
            Assert.False(_context.SupplierInvoiceCosts.Any(x => x.SupplierInvoiceCostsId == 1));
            Assert.Equal(supplier.SupplierInvoiceCostsId, actionResult.SupplierInvoiceCostsId);
        }

        [Fact]
        public void Supplier_Invoice_Cost__ReturnCorrect_DeleteSupplier_Cascade_Remove_Amount()
        {
            var supplierUpdate = new SupplierInvoiceCost() { Quantity = 1, Cost = 50.0m, SupplierInvoiceId = 1 };

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierService.UpdateSupplierInvoiceCost(1, supplierUpdate));
            var action = Assert.IsType<ArgumentNullException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Value cannot be null. (Parameter 'Supplier Invoice Cost not found')", actionResult);
        }
    }
}
