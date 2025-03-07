using API.Models;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task supplierServicesTest_ReturnCorrect_GetAllSuppliers()
        {
            var suppliers = new List<Supplier>() { new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" } };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = await _supplierService.GetAllSuppliers(new SupplierFilter());

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Theory]
        [InlineData("a", null, null, null, null)]
        [InlineData(null, "a", null, null, null)]
        [InlineData(null, null, "2025-06-01", null, null)]
        [InlineData(null, null, null, "2025-06-01", null)]
        [InlineData(null, null, null, null, false)]
        public async Task supplierServicesTest_ReturnCorrect_GetAllSuppliersFiltered(string name, string country, string dateTo, string dateFrom, bool? deprecated)
        {

            SupplierFilter filter = new SupplierFilter
            {
                SupplierName = name,
                SupplierCountry = country,
                SupplierCreatedDateFrom = DateTime.TryParse(dateFrom, out DateTime parsedDateF) ? parsedDateF : null,
                SupplierCreatedDateTo = DateTime.TryParse(dateTo, out DateTime parsedDateT) ? parsedDateT : null,
                SupplierDeprecated = deprecated
            };

            var suppliers = new List<Supplier>() { new Supplier() { SupplierId = 1, SupplierName = "aaa", Country = "aaa", CreatedAt = new DateTime(2025,1,1,0,0,0), Deprecated = false },
                                                   new Supplier() { SupplierId = 2, SupplierName = "bbb", Country = "bbb", CreatedAt = new DateTime(2025,12,31,0,0,0), Deprecated = true} };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = await _supplierService.GetAllSuppliers(filter);

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public async Task supplierServicesTest_ReturnCorrect_GetAllSuppliersPage()
        {

            var suppliers = new List<Supplier>() { new Supplier() { SupplierName = "aaa", Country = "aaa"},
                                                   new Supplier() { SupplierName = "bbb", Country = "bbb"},
                                                   new Supplier() { SupplierName = "ccc", Country = "ccc"},
                                                   new Supplier() { SupplierName = "ddd", Country = "ddd"},
                                                   new Supplier() { SupplierName = "eee", Country = "eee"},
                                                   new Supplier() { SupplierName = "fff", Country = "fff"},
                                                   new Supplier() { SupplierName = "ggg", Country = "ggg"},
                                                   new Supplier() { SupplierName = "hhh", Country = "hhh"},
                                                   new Supplier() { SupplierName = "iii", Country = "iii"},
                                                   new Supplier() { SupplierName = "jjj", Country = "jjj"},
                                                   new Supplier() { SupplierName = "kkk", Country = "kkk"},
                                                   new Supplier() { SupplierName = "lll", Country = "lll"},
                                                   new Supplier() { SupplierName = "mmm", Country = "mmm"},
                                                   new Supplier() { SupplierName = "nnn", Country = "nnn"},
                                                   new Supplier() { SupplierName = "ooo", Country = "ooo"}
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = await _supplierService.GetAllSuppliers(new SupplierFilter() { SupplierPage = 1 });

            Assert.NotNull(result);
            Assert.Equal(10, result.Count);
        }

        [Fact]
        public async Task supplierServicesTest_ReturnCorrect_GetAllSuppliers_NoSuppliers()
        {

            var result = await _supplierService.GetAllSuppliers(new SupplierFilter());

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public async Task supplierService_ReturnCorrect_GetSupplierById()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();

            var result = await _supplierService.GetSupplierById(1);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
        }

        [Fact]
        public async Task supplierService_ThrowException_GetSupplierById()
        {

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _supplierService.GetSupplierById(1));
            Assert.Equal("Supplier not found!", exception.Message);
        }

        [Fact]
        public async Task supplierService_ReturnCorrect_CreateSupplier()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country" };
            var result = await _supplierService.CreateSupplier(supplier);

            Assert.NotNull(result);
            Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(1, result.SupplierId);
            Assert.True(_context.Suppliers.Any(x => x.SupplierId == supplier.SupplierId));
        }

        [Fact]
        public async Task supplierService_ThrowException_CreateSupplier_NullSupplier()
        {

            var exception = await Assert.ThrowsAsync<NullPropertyException>(
                () => _supplierService.CreateSupplier(null));
            Assert.Equal("Couldn't create supplier", exception.Message);
        }

        [Theory]
        [InlineData(null, "country", "Supplier name")]
        [InlineData("name", null, "Country")]
        public async Task supplierService_ThrowException_CreateSupplier_NullFields(string name, string country, string erroreMessage)
        {

            var supplier = new Supplier() { SupplierId = 1, SupplierName = name, Country = country };

            var exception = await Assert.ThrowsAsync<NullPropertyException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal($"{erroreMessage} can't be null", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_CreateSupplier_NameTooLong()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name".PadRight(101, 'X'), Country = "Country" };

            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Supplier name is too long", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_CreateSupplier_CountryTooLong()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "Country".PadRight(51, 'X') };

            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Country is too long", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_CreateSupplier_CountrySpecialChar()
        {
            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Name", Country = "@" };

            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Equal("Country can't have special characters", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_CreateSupplier_DuplicateSupplier()
        {
            var supplier = new Supplier() { SupplierName = "Name", Country = "Country" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var exception = await Assert.ThrowsAsync<DbUpdateException>(
                () => _supplierService.CreateSupplier(supplier));
            Assert.Contains("The statement has been terminated.", exception.InnerException.Message);
        }

        [Fact]
        public async Task supplierService_ReturnCorrect_UpdateSupplier()
        {
            //Arrange

            var supplier = new Supplier { SupplierId = 1, SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierId = 1, SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var result = await _supplierService.UpdateSupplier(1, supplierUpdate);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplierUpdate.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplierUpdate.Country, actionResult.Country);
        }

        [Fact]
        public async Task supplierService_ThrowError_UpdateSupplier()
        {
            var supplierUpdate = new Supplier { SupplierName = "Luca", Country = "France" };

            var exception = await Assert.ThrowsAsync<NotFoundException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Supplier not found", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_UpdateSupplier_NameTooLong()
        {
            //Arrange

            var supplier = new Supplier { SupplierId = 1, SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierId = 1, SupplierName = "Luca".PadRight(101, 'X'), Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Supplier name is too long", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_UpdateSupplier_CountryTooLong()
        {
            //Arrange

            var supplier = new Supplier { SupplierId = 1, SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierId = 1, SupplierName = "Luca", Country = "France".PadRight(51, 'X') };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Country is too long", exception.Message);
        }

        [Fact]
        public async Task supplierService_ThrowError_UpdateSupplier_CountrySpecialChar()
        {
            //Arrange

            var supplier = new Supplier { SupplierId = 1, SupplierName = "Marco", Country = "Italy" };
            var supplierUpdate = new Supplier { SupplierId = 1, SupplierName = "Luca", Country = "@" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            //Act
            var exception = await Assert.ThrowsAsync<ErrorInputPropertyException>(
                () => _supplierService.UpdateSupplier(1, supplierUpdate));
            Assert.Equal("Country can't have special characters", exception.Message);
        }

        [Fact]
        public async Task supplierService_ReturnCorrect_DeleteSupplier_NoCascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierId = 1, SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            //Act
            var result = await _supplierService.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
        }

        [Fact]
        public async Task supplierService_ReturnCorrect_DeleteSupplier_Cascade()
        {
            //Arrange
            var supplier = new Supplier { SupplierId = 1, SupplierName = "Luca", Country = "France" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var supplierInvoice = new SupplierInvoice { SupplierId = 1 };
            _context.SupplierInvoices.Add(supplierInvoice);
            _context.SaveChanges();

            //Act
            var result = await _supplierService.DeleteSupplier(1);
            //Assert
            var actionResult = Assert.IsType<SupplierDTOGet>(result);
            Assert.Equal(supplier.SupplierName, actionResult.SupplierName);
            Assert.Equal(supplier.Country, actionResult.Country);
            _mockSupplierInvoiceService.Verify(s => s.DeleteSupplierInvoice(1), Times.Once);
        }

        [Fact]
        public async Task supplierService_ThrowException_DeleteSupplier()
        {
            var exception = await Assert.ThrowsAsync<NotFoundException>(
                () => _supplierService.DeleteSupplier(1));

            Assert.Equal("Supplier not found!", exception.Message);
        }

    }
}
