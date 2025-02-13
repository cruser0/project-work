using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;
using Xunit;

namespace testtest1.ServiceTest
{
    public class saleREPOTest
    {
        private readonly SaleREPO _saleRepo;
        private readonly Mock<ICustomerInvoicesREPO> _mockciRepo;
        private readonly Mock<ISupplierInvoiceREPO> _mocksiRepo;
        private readonly Progetto_FormativoContext _context;

        public saleREPOTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new Progetto_FormativoContext(options);
            _mockciRepo = new Mock<ICustomerInvoicesREPO>();
            _mocksiRepo = new Mock<ISupplierInvoiceREPO>();

            // Initialize repository
            _saleRepo = new SaleREPO(_context, _mockciRepo.Object, _mocksiRepo.Object);

        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_GetAllSales()
        {
            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1,1,0,0,0), CustomerId = 1, TotalRevenue = 100, Status = "Active" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var result = _saleRepo.GetAllSales();

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public async Task saleREPO_ThrowException_GetAllSales()
        {

            var result = _saleRepo.GetAllSales();

            Assert.Equal(0, result.Count);

        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_GetSaleById()
        {
            var sales = new List<Sale>()
            {
                new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1,1,0,0,0), CustomerId = 1, TotalRevenue = 100, Status = "Active" }
            };

            _context.Sales.AddRange(sales);
            _context.SaveChanges();

            var result = _saleRepo.GetSaleById(1);

            Assert.NotNull(result);
            Assert.IsType<SaleDTOGet>(result);
            Assert.Equal(1, result.SaleId);
        }

        [Fact]
        public async Task saleREPO_ThrowException_GetSaleById()
        {

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.GetSaleById(1));
            Assert.Equal("Sale not found!", exception.Message);
        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_CreateSale()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "ciao", Country = "ciao" };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            var sale = new Sale() { SaleId = 1, BookingNumber = "bn", BoLnumber = "bol", SaleDate = new DateTime(2025, 1, 1, 0, 0, 0), CustomerId = 1, TotalRevenue = 100, Status = "Active" };
            var result = _saleRepo.CreateSale(sale);

            Assert.NotNull(result);
            Assert.IsType<SaleDTOGet>(result);
            Assert.Equal(1, result.SaleId);
            Assert.True(_context.Sales.Any(x => x.SaleId == sale.SaleId));
        }

        [Fact]
        public void saleREPO_ThrowException_CreateSale_NullSale()
        {
            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.CreateSale((Sale)null));

            Assert.Equal("Couldn't create sale", exception.Message);
        }


        [Theory]
        [InlineData(null, "bolValue", "2025-02-13", 1, "statusValue", "BN")]
        [InlineData("bnValue", null, "2025-02-13", 1, "statusValue", "BOL")]
        [InlineData("bnValue", "bolValue", null, 1, "statusValue", "Date")]
        [InlineData("bnValue", "bolValue", "2025-02-13", null, "statusValue", "CustomerID")]
        [InlineData("bnValue", "bolValue", "2025-02-13", 1, null, "Status")]
        public async Task saleREPO_ThrowException_CreateSale_NullFields(string bn, string bol, string dateString, int? cID, string status, string ErrorMess)
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

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.CreateSale(wrongSale));

            Assert.Equal($"{ErrorMess} is null", exception.Message);
        }

        [Fact]
        public async Task saleREPO_ThrowException_CreateSale_IncorrectStatus()
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

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.CreateSale(wrongSale));

            Assert.Equal("Incorrect status\nA sale is Active or Closed", exception.Message);
        }

        [Fact]
        public async Task saleREPO_ThrowException_CreateSale_WrongCustomerID()
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

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.CreateSale(wrongSale));

            Assert.Equal($"There is no customer with ID {wrongSale.CustomerId}", exception.Message);
        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_UpdateSale()
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

            var oldSale = _saleRepo.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn",
                BoLnumber = "new bol",
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var newSale = _saleRepo.UpdateSale(1, SaleMapper.Map(newSaleDTO));



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
        public void saleREPO_ThrowException_UpdateSale_WrongSaleID()
        {

            var newSaleDTO = new SaleDTO()
            {
                BookingNumber = "new bn",
                BoLnumber = "new bol",
                SaleDate = new DateTime(2025, 1, 2, 0, 0, 0),
                CustomerId = 2,
                Status = "Closed"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("There is no sale with id 1", exception.Message);
        }

        [Fact]
        public void saleREPO_ThrowException_UpdateSale_IncorrectStatus()
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

            var oldSale = _saleRepo.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                Status = "Status"
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal("Incorrect status\nA sale is Active or Closed", exception.Message);
        }

        [Fact]
        public void saleREPO_ThrowException_UpdateSale_IncorrectCustomerID()
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

            var oldSale = _saleRepo.CreateSale(sale);

            var newSaleDTO = new SaleDTO()
            {
                CustomerId = 2
            };

            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.UpdateSale(1, SaleMapper.Map(newSaleDTO)));

            Assert.Equal($"There is no customer with ID {newSaleDTO.CustomerId}", exception.Message);
        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_DeleteSale_NoCascade()
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

            var saleToDelete = _saleRepo.CreateSale(sale);
            var saleDeleted = _saleRepo.DeleteSale(sale.SaleId);

            Assert.NotNull(saleDeleted);
            Assert.IsType<SaleDTOGet>(saleDeleted);
            Assert.Equal(saleToDelete.SaleId, saleDeleted.SaleId);
        }

        [Fact]
        public async Task saleREPO_ReturnCorrect_DeleteSale_Cascade()
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

            var saleToDelete = _saleRepo.CreateSale(sale);

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

            var saleDeleted = _saleRepo.DeleteSale(sale.SaleId);

            Assert.NotNull(saleDeleted);
            Assert.IsType<SaleDTOGet>(saleDeleted);
            Assert.Equal(saleDeleted, saleDeleted);
            _mockciRepo.Verify(s => s.DeleteCustomerInvoice((int)saleDeleted.SaleId), Times.Once);
            _mocksiRepo.Verify(s => s.DeleteSupplierInvoice((int)saleDeleted.SaleId), Times.Once);
        }

        [Fact]
        public async Task saleREPO_ThrowException_DeleteSale()
        {
            var exception = Assert.Throws<ArgumentException>(() => _saleRepo.DeleteSale(1));

            Assert.Equal("Sale not found!", exception.Message);
        }
    }
}
