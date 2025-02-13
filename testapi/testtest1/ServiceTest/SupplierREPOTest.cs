using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Repo;
using Xunit;
namespace testtest1.ServiceTest
{
    public class SupplierREPOTest
    {
        private readonly SupplierREPO _supplierRepo;
        private readonly Mock<ISupplierInvoiceREPO> _mockSupplierInvoiceRepo;
        private readonly Progetto_FormativoContext _context;

        public SupplierREPOTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);
            _mockSupplierInvoiceRepo = new Mock<ISupplierInvoiceREPO>();

            // Initialize repository
            _supplierRepo = new SupplierREPO(_context, _mockSupplierInvoiceRepo.Object);
        }

        [Fact]
        public void supplierREPOTest_ReturnCorrect_GetAllSuppliers()
        {
            var suppliers = new List<Supplier>() { new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" } };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = _supplierRepo.GetAllSuppliers();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void supplierREPOTest_ThrowException_GetAllSuppliers()
        {

            var result = _supplierRepo.GetAllSuppliers();

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void supplierREPO_ReturnCorrect_GetSupplierById()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = _supplierRepo.GetSupplierById(1);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
        }

        [Fact]
        public void supplierREPO_ThrowException_GetSupplierById()
        {

            var exception = Assert.Throws<ArgumentException>(() => _supplierRepo.GetSupplierById(1));
            Assert.Equal("Supplier not found!", exception.Message);
        }

        [Fact]
        public void supplierREPO_ReturnCorrect_CreateSupplier()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" };
            var result = _supplierRepo.CreateSupplier(supplier);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
            Assert.True(_context.Suppliers.Any(x => x.SupplierId == supplier.SupplierId));
        }

        [Fact]
        public void supplierREPO_ThrowException_CreateSupplier_NullSupplier()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierRepo.CreateSupplier((Supplier)null));
            Assert.Equal("Couldn't create supplier", exception.ParamName);
        }

        [Theory]
        [InlineData(null, "country", "Supplier name")]
        [InlineData("name", null, "Country")]
        public void supplierREPO_ThrowException_CreateSupplier_NullFields(string name, string country, string erroreMessage)
        {

            var supplier = new Supplier() { SupplierId = 1, SupplierName = name, Country = country };

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierRepo.CreateSupplier(supplier));
            Assert.Equal($"{erroreMessage} can't be null", exception.ParamName);
        }

        [Fact]
        public void supplierREPO_ReturnCorrect_UpdateSupplier()
        {
            //Arrange

            var supplier = new Supplier { SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var result = _supplierRepo.UpdateSupplier(1, supplierUpdate);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplierUpdate.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplierUpdate.Country, actionResult.Country);
        }

        [Fact]
        public void supplierREPO_ThrowError_UpdateSupplier()
        {
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France" };

            var exception = Assert.Throws<ArgumentNullException>(() => _supplierRepo.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Supplier not found", exception.ParamName);
        }

        [Fact]
        public void supplierREPO_ReturnCorrect_DeleteSupplier_NoCascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            //Act
            var result = _supplierRepo.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
        }

        [Fact]
        public void supplierREPO_ReturnCorrect_DeleteSupplier_Cascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice { SupplierId = 1 };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            //Act
            var result = _supplierRepo.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
            _mockSupplierInvoiceRepo.Verify(s => s.DeleteSupplierInvoice(1), Times.Once);
        }

    }
}
