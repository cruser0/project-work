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
    public class SupplierServiceTest
    {
        private readonly SupplierService _supplierService;
        private readonly Mock<ISupplierInvoiceService> _mockSupplierInvoiceService;
        private readonly Progetto_FormativoContext _context;

        public SupplierServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);
            _mockSupplierInvoiceService = new Mock<ISupplierInvoiceService>();

            // Initialize repository
            _supplierService = new SupplierService(_context, _mockSupplierInvoiceService.Object);
        }

        [Fact]
        public void supplierServicesTest_ReturnCorrect_GetAllSuppliers()
        {
            var suppliers = new List<Supplier>() { new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" } };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = _supplierService.GetAllSuppliers();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void supplierServicesTest_ReturnCorrect_GetAllSuppliers_NoSuppliers()
        {

            var result = _supplierService.GetAllSuppliers();

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void supplierService_ReturnCorrect_GetSupplierById()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = _supplierService.GetSupplierById(1);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
        }

        [Fact]
        public void supplierService_ThrowException_GetSupplierById()
        {

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.GetSupplierById(1));
            Assert.Equal("Supplier not found!", exception.Message);
        }

        [Fact]
        public void supplierService_ReturnCorrect_CreateSupplier()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" };
            var result = _supplierService.CreateSupplier(supplier);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
            Assert.True(_context.Suppliers.Any(x => x.SupplierId == supplier.SupplierId));
        }

        [Fact]
        public void supplierService_ThrowException_CreateSupplier_NullSupplier()
        {

            var exception = Assert.Throws<ArgumentNullException>(
                () => _supplierService.CreateSupplier(null));
            Assert.Equal("Couldn't create supplier", exception.ParamName);
        }

        [Theory]
        [InlineData(null, "country", "Supplier name")]
        [InlineData("name", null, "Country")]
        public void supplierService_ThrowException_CreateSupplier_NullFields(string name, string country, string erroreMessage)
        {

            var supplier = new Supplier() { SupplierId = 1, SupplierName = name, Country = country };

            var exception = Assert.Throws<ArgumentNullException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal($"{erroreMessage} can't be null", exception.ParamName);
        }

        [Fact]
        public void supplierService_ThrowError_CreateSupplier_NameTooLong()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name".PadRight(101, 'X'), Country = "Country" };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Supplier name is too long", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowError_CreateSupplier_CountryTooLong()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country".PadRight(51, 'X') };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Country is too long", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowError_CreateSupplier_CountrySpecialChar()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "@" };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Country can't have special characters", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowError_CreateSupplier_DuplicateSupplier()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("This supplier already exists", exception.Message);
        }

        [Fact]
        public void supplierService_ReturnCorrect_UpdateSupplier()
        {
            //Arrange

            var supplier = new Supplier { SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var result = _supplierService.UpdateSupplier(1, supplierUpdate);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplierUpdate.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplierUpdate.Country, actionResult.Country);
        }

        [Fact]
        public void supplierService_ThrowError_UpdateSupplier()
        {
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France" };

            var exception = Assert.Throws<ArgumentNullException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Supplier not found", exception.ParamName);
        }

        [Fact]
        public void supplierService_ThrowError_UpdateSupplier_NameTooLong()
        {
            //Arrange

            var supplier = new Supplier { SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierName = "Luca".PadRight(101, 'X'), Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Supplier name is too long", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowError_UpdateSupplier_CountryTooLong()
        {
            //Arrange

            var supplier = new Supplier { SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France".PadRight(51, 'X') };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Country is too long", exception.Message);
        }

        [Fact]
        public void supplierService_ThrowError_UpdateSupplier_CountrySpecialChar()
        {
            //Arrange

            var supplier = new Supplier { SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "@" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Country can't have special characters", exception.Message);
        }

        [Theory]
        [InlineData("Name", "Country")]
        [InlineData("AltroName", null)]
        [InlineData(null, "Country")]
        [InlineData("AltroName", "AltroCountry")]
        public void supplierService_ThrowError_UpdateSupplier_DuplicateSupplier(string name, string country)
        {
            var supplier1 = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" };
            _context.Suppliers.Add(supplier1);
            var supplier2 = new Supplier() { SupplierId = 2, SupplierName = "AltroName", Country = "AltroCountry" };
            _context.Suppliers.Add(supplier2);
            var supplier3 = new Supplier() { SupplierId = 3, SupplierName = "Name", Country = "AltroCountry" };
            _context.Suppliers.Add(supplier3);

            _context.SaveChanges();

            var supplierToUpdate = new Supplier() { SupplierId = 3, SupplierName = name, Country = country };

            var exception = Assert.Throws<ArgumentException>(
                () => _supplierService.UpdateSupplier(3, supplierToUpdate));
            Assert.Equal("This supplier already exists", exception.Message);
        }

        [Fact]
        public void supplierService_ReturnCorrect_DeleteSupplier_NoCascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            //Act
            var result = _supplierService.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
        }

        [Fact]
        public void supplierService_ReturnCorrect_DeleteSupplier_Cascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice { SupplierId = 1 };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            //Act
            var result = _supplierService.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
            _mockSupplierInvoiceService.Verify(s => s.DeleteSupplierInvoice(1), Times.Once);
        }

        [Fact]
        public void supplierService_ThrowException_DeleteSupplier()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => _supplierService.DeleteSupplier(1));

            Assert.Equal("Supplier not found!", exception.ParamName);
        }

    }
}
