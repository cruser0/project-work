using API.Models;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API_Test.ServiceTest
{
    public class SaleServiceTest
    {
        private readonly SaleServices _saleService;
        private readonly Mock<ICustomerInvoicesService> _mockciService;
        private readonly Mock<ISupplierInvoiceService> _mocksiService;
        private readonly Progetto_FormativoContext _context;

        public SaleServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new Progetto_FormativoContext(options);
            _mockciService = new Mock<ICustomerInvoicesService>();
            _mocksiService = new Mock<ISupplierInvoiceService>();

            // Initialize repository
            _saleService = new SaleServices(_context, _mockciService.Object, _mocksiService.Object);

        }

        [Fact]
        public void saleService_ReturnCorrect_GetAllSales()
        {
            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1,1,0,0,0), CustomerId = 1, TotalRevenue = 100, Status = "Active" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var result = _saleService.GetAllSales();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void saleService_ReturnCorrect_GetAllSales_NoSales()
        {

            var result = _saleService.GetAllSales();

            Assert.Equal(0, result.Count);

        }

        [Fact]
        public void saleService_ReturnCorrect_GetSaleById()
        {
            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1,1,0,0,0), CustomerId = 1, TotalRevenue = 100, Status = "Active" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var result = _saleService.GetSaleById(1);

            Assert.NotNull(result);
            Assert.IsType<SaleDTOGet>(result);
            Assert.Equal(1, result.SaleId);
        }

        [Fact]
        public void saleService_ThrowException_GetSaleById()
        {

            var exception = Assert.Throws<ArgumentException>(() => _saleService.GetSaleById(1));
            Assert.Equal("Sale not found!", exception.Message);
        }

        [Fact]
        public void saleService_ReturnCorrect_CreateSale()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };
            var result = _saleService.CreateSale(sale);

            Assert.NotNull(result);
            Assert.IsType<SaleDTOGet>(result);
            Assert.Equal(1, result.SaleId);
            Assert.True(_context.Sales.Any(x => x.SaleId == sale.SaleId));
        }

        [Fact]
        public void saleService_ThrowException_CreateSale_NullSale()
        {
            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(null));

            Assert.Equal("Couldn't create sale", exception.Message);
        }


        [Theory]
        [InlineData(null, "bolValue", "2025-02-13", 1, "statusValue", "BN", "is")]
        [InlineData(null, null, "2025-02-13", 1, "statusValue", "BN, BOL", "are")]
        [InlineData("bnValue", null, "2025-02-13", 1, "statusValue", "BOL", "is")]
        [InlineData("bnValue", "bolValue", null, 1, "statusValue", "Date", "is")]
        [InlineData("bnValue", "bolValue", "2025-02-13", null, "statusValue", "CustomerID", "is")]
        [InlineData("bnValue", "bolValue", "2025-02-13", 1, null, "Status", "is")]
        public void saleService_ThrowException_CreateSale_NullFields(string bn, string bol, string dateString, int? cID, string status, string ErrorMess, string verbo)
        {

            Sale wrongSale = new()
            {
                SaleId = 1,
                BookingNumber = bn,
                BoLnumber = bol,
                SaleDate = DateTime.TryParse(dateString, out DateTime parsedDate) ? parsedDate : null,
                CustomerId = cID,
                TotalRevenue = 0,
                Status = status
            };

            _context.Sales.Add(wrongSale);
            _context.SaveChanges();

            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(wrongSale));

            Assert.Equal($"{ErrorMess} {verbo} null", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_CreateSale_IncorrectStatus()
        {
            Sale wrongSale = new()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Status"
            };

            _context.Sales.Add(wrongSale);
            _context.SaveChanges();

            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(wrongSale));

            Assert.Equal("Incorrect status\nA sale is Active or Closed", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_CreateSale_WrongCustomerID()
        {
            Sale wrongSale = new()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Active"
            };

            _context.Sales.Add(wrongSale);
            _context.SaveChanges();

            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(wrongSale));

            Assert.Equal($"There is no customer with ID {wrongSale.CustomerId}", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_CreateSale_BookingNumberLength()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale() { SaleId = 1, BookingNumber = "bn".PadRight(51, 'X'), BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(sale));

            Assert.Equal("Booking Number is too long", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_CreateSale_BoLNumberLength()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol".PadRight(51, 'X'), SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.CreateSale(sale));

            Assert.Equal("BoL Number is too long", exception.Message);
        }

        [Fact]
        public void saleService_ReturnCorrect_UpdateSale()
        {
            var customer1 = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer1);
            var customer2 = new Customer() { CustomerId = 2, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer2);
            _context.SaveChanges();


            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var oldSale = _saleService.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn",
                BoLnumber = "new bol",
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var newSale = _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO));



            Assert.NotNull(newSale);
            Assert.IsType<SaleDTOGet>(newSale);
            Assert.Equal(oldSale.SaleId, newSale.SaleId);
            Assert.Equal(newSaleDTO.BookingNumber, newSale.BookingNumber);
            Assert.Equal(newSaleDTO.BoLnumber, newSale.BoLnumber);
            Assert.Equal(newSaleDTO.SaleDate, newSale.SaleDate);
            Assert.Equal(newSaleDTO.CustomerId, newSale.CustomerId);
            Assert.Equal(newSaleDTO.Status, newSale.Status);

        }

        [Fact]
        public void saleService_ThrowException_UpdateSale_WrongSaleID()
        {

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn",
                BoLnumber = "new bol",
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("There is no sale with id 1", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_UpdateSale_IncorrectStatus()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var oldSale = _saleService.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                Status = "Status"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("Incorrect status\nA sale is Active or Closed", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_UpdateSale_IncorrectCustomerID()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var oldSale = _saleService.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                CustomerId = 2
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal($"There is no customer with ID {newSaleDTO.CustomerId}", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_UpdateSale_BookingNumberLength()
        {
            var customer1 = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer1);
            var customer2 = new Customer() { CustomerId = 2, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer2);
            _context.SaveChanges();


            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var oldSale = _saleService.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn".PadRight(51, 'X'),
                BoLnumber = "new bol",
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("Booking Number is too long", exception.Message);
        }

        [Fact]
        public void saleService_ThrowException_UpdateSale_BoLNumberLength()
        {
            var customer1 = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer1);
            var customer2 = new Customer() { CustomerId = 2, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer2);
            _context.SaveChanges();


            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var oldSale = _saleService.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn",
                BoLnumber = "new bol".PadRight(51, 'X'),
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleService.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("BoL Number is too long", exception.Message);
        }

        [Fact]
        public void saleService_ReturnCorrect_DeleteSale_NoCascade()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var saleToDelete = _saleService.CreateSale(sale);
            var saleDeleted = _saleService.DeleteSale(sale.SaleId);

            Assert.NotNull(saleDeleted);
            Assert.IsType<SaleDTOGet>(saleDeleted);
            Assert.Equal(saleToDelete.SaleId, saleDeleted.SaleId);
        }

        [Fact]
        public void saleService_ReturnCorrect_DeleteSale_Cascade()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var sale = new Sale()
            {
                SaleId = 1,
                BookingNumber = "bn",
                BoLnumber = "bol",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                Status = "Active"
            };

            var saleToDelete = _saleService.CreateSale(sale);

            var cusInvoice = new CustomerInvoice()
            {
                CustomerInvoiceId = 1,
                SaleId = 1,
                InvoiceAmount = 100,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Unpaid"
            };
            _context.CustomerInvoices.Add(cusInvoice);
            _context.SaveChanges();

            var supplier = new Supplier() { SupplierId = 1, SupplierName = "Nome", Country = "Country" };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var supInvoice = new SupplierInvoice()
            {
                InvoiceId = 1,
                SaleId = 1,
                SupplierId = 1,
                InvoiceAmount = 0,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Approved"
            };
            _context.SupplierInvoices.Add(supInvoice);
            _context.SaveChanges();

            var saleDeleted = _saleService.DeleteSale(sale.SaleId);

            Assert.NotNull(saleDeleted);
            Assert.IsType<SaleDTOGet>(saleDeleted);
            Assert.Equal(saleDeleted.SaleId, saleDeleted.SaleId);
            _mockciService.Verify(s => s.DeleteCustomerInvoice((int)saleDeleted.SaleId), Times.Once);
            _mocksiService.Verify(s => s.DeleteSupplierInvoice((int)saleDeleted.SaleId), Times.Once);
        }

        [Fact]
        public void saleService_ThrowException_DeleteSale()
        {
            var exception = Assert.Throws<ArgumentException>(() => _saleService.DeleteSale(1));

            Assert.Equal("Sale not found!", exception.Message);
        }
    }
}
