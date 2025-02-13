using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Repo;
using Xunit;

namespace testtest1.ServiceTest
{
    public class CustomerInvoiceInvoiceREPOTest
    {

        private readonly CustomerInvoicesREPO _customerInvoiceRepo;
        List<string> statusList = new() { "paid", "unpaid" };
        private readonly Progetto_FormativoContext _context;

        public CustomerInvoiceInvoiceREPOTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);

            // Initialize repository
            _customerInvoiceRepo = new CustomerInvoicesREPO(_context);
        }

        [Fact]
        public async Task Create_CustomerInvoice()//correct customer
        {
            //Arrange
            var sale=new Sale {};
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice {SaleId=1,Status="paid",InvoiceAmount=100.0m,InvoiceDate=DateTime.Now };

            //Act
            var result = _customerInvoiceRepo.CreateCustomerInvoice(customerInvoice);

            //Assert
            Assert.NotNull(result);
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            Assert.True(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customerInvoice.CustomerInvoiceId));
            Assert.Equal(customerInvoice.SaleId, actionResult.SaleId);
            Assert.Equal(customerInvoice.InvoiceDate, actionResult.InvoiceDate);
            Assert.Equal(customerInvoice.Status, actionResult.Status);
        }
        [Fact]
        public async Task Create_CustomerInvoice_null()//customer null
        {
            //Act Arrange
            var exception = Assert.Throws<ArgumentNullException>(() => _customerInvoiceRepo.CreateCustomerInvoice(null));

            //Assert

            var actionResult = Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("Value cannot be null. (Parameter 'Couldn't create customer invoice')", actionResult.Message);
        }

        [Theory]
        [InlineData(null, null,null, null, null, null)]
        [InlineData(null, "Paid", 100.0, 2023, 12, 10)]
        [InlineData(1, null, 100.0, 2023, 12, 10)]
        [InlineData(1, "Paid", null, 2023, 12, 10)]
        [InlineData(1, "Paid", 100.0, null, null, null)]
        [InlineData(null, null, 100.0, 2023, 12, 10)]
        [InlineData(null, "Paid", null, 2023, 12, 10)]
        [InlineData(null, "Paid", 100.0, null, null, null)]
        [InlineData(1, null, null, 2023, 12, 10)]
        [InlineData(1, null, 100.0, null, null, null)]
        [InlineData(1, "Paid", null, null, null, null)]
        [InlineData(null, null, null, 2023, 12, 10)]
        [InlineData(null, null, 100.0, null, null, null)]
        [InlineData(null, "Paid", null, null, null, null)]
        [InlineData(1, null, null, null, null, null)]

        public async Task Create_CustomerInvoice_attributes_null(int? saleId, string status, double? amount, int? y, int? m, int? d)
        {
            // Arrange
            DateTime? date = null;
            if (y.HasValue && m.HasValue && d.HasValue)
            {
                date = new DateTime(y.Value, m.Value, d.Value);
            }
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = saleId, Status = status, InvoiceAmount = (decimal?)amount, InvoiceDate = date };

            // Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceRepo.CreateCustomerInvoice(customerInvoice));

            // Assert
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customerInvoice.CustomerInvoiceId));
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId ==1));
            List<string> errors = new List<string>();
            if (!saleId.HasValue) errors.Add("SaleID");
            if (!amount.HasValue) errors.Add("InvoiceAmount");
            if (!date.HasValue) errors.Add("Date");
            if (string.IsNullOrEmpty(status)) errors.Add("Status");
            if (errors.Any())
            {
                string expectedMessage = $"{string.Join(", ", errors)} {(errors.Count > 1 ? "are" : "is")} null";
                Assert.Equal(expectedMessage, actionResult);
            }
        }
        [Fact]
        public async Task Create_Customer_Invoice_Negative_Amount()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = -100.0m, InvoiceDate = DateTime.Now };

            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceRepo.CreateCustomerInvoice(customerInvoice));

            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == 1));
            
        }
        /*
        [Fact]
        public async Task Delete_CustomerInvoice_with_sale()
        {
            //Arrange
            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            _context.CustomerInvoices.Add(customer);
            _context.SaveChanges();
            var sales = new Sale { BoLnumber = "1", BookingNumber = "2", CustomerInvoiceId = 1, SaleDate = DateTime.Now, SaleId = 1, Status = "paid", TotalRevenue = 1000 };
            _context.Sales.Add(sales);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.DeleteCustomerInvoice(1);

            //Assert
            _mockSalesRepo.Verify(s => s.DeleteSale(sales.SaleId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerInvoiceId, result.CustomerInvoiceId);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customer.CustomerInvoiceId));
        }
        [Fact]
        public async Task Delete_CustomerInvoice()
        {
            //Arrange
            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            _context.CustomerInvoices.Add(customer);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.DeleteCustomerInvoice(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerInvoiceId, result.CustomerInvoiceId);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customer.CustomerInvoiceId));
        }

        [Fact]
        public async Task GetAll_CustomerInvoice()
        {
            //Arrange
            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            var customer1 = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "Italy" };
            _context.CustomerInvoices.Add(customer);
            _context.CustomerInvoices.Add(customer1);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.GetAllCustomerInvoices();

            //Assert
            var actionResult = Assert.IsType<List<CustomerInvoiceDTOGet>>(result);
            Assert.Equal(2, actionResult.Count);

        }
        [Fact]
        public async Task GetAll_CustomerInvoice_Empty()
        {
            //Act
            var result = _customerRepo.GetAllCustomerInvoices();
            //Assert
            var actionResult = Assert.IsType<List<CustomerInvoiceDTOGet>>(result);
            Assert.Empty(actionResult);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Get_CustomerInvoice_BY_Id(int id)
        {
            //Arrange
            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            var customer1 = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "Italy" };
            _context.CustomerInvoices.Add(customer);
            _context.CustomerInvoices.Add(customer1);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.GetCustomerInvoiceById(id);
            //Assert
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            Assert.Equal(id, actionResult.CustomerInvoiceId);

        }

        [Theory]
        [InlineData(3)]
        [InlineData(null)]
        [InlineData(-1)]
        public async Task Get_CustomerInvoice_BY_Non_Existing_Id(int id)
        {
            //Arrange
            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            var customer1 = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "Italy" };
            _context.CustomerInvoices.Add(customer);
            _context.CustomerInvoices.Add(customer1);
            _context.SaveChanges();

            //Act Assert
            var exception = Assert.Throws<Exception>(() => _customerRepo.GetCustomerInvoiceById(id));

            var action = Assert.IsType<Exception>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);

            Assert.Equal("CustomerInvoice not found!", actionResult);
        }

        [Fact]
        public async Task Update_CustomerInvoice()
        {
            //Arrange

            var customer = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            var customerUpdate = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "France" };
            _context.CustomerInvoices.Add(customer);
            _context.SaveChanges();
            //Act
            var result = _customerRepo.UpdateCustomerInvoice(1, customerUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            Assert.Equal(customerUpdate.CustomerInvoiceName, actionResult.CustomerInvoiceName);
            Assert.Equal(customerUpdate.Country, actionResult.Country);
        }

        [Theory]
        [InlineData("Marco", null)]
        [InlineData("Marco", "")]
        [InlineData("", "Italy")]
        [InlineData(null, "Italy")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public async Task Update_CustomerInvoice_Not_Present_Params(string name, string country)
        {
            //Arrange
            var customerUpdate = new CustomerInvoice { CustomerInvoiceName = name, Country = country };
            var customer = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "France" };
            _context.CustomerInvoices.Add(customer);
            _context.SaveChanges();
            //Act
            var result = _customerRepo.UpdateCustomerInvoice(1, customerUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            if (string.IsNullOrEmpty(name))
                Assert.Equal(customer.CustomerInvoiceName, actionResult.CustomerInvoiceName);
            if (string.IsNullOrEmpty(country))
                Assert.Equal(customer.Country, actionResult.Country);
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(country))
            {
                Assert.Equal(customerUpdate.Country, actionResult.Country);
                Assert.Equal(customerUpdate.Country, actionResult.Country);

            }

        }

        [Theory]
        [InlineData(null)]
        [InlineData(4)]
        [InlineData(-1)]
        public async Task Update_CustomerInvoice_Wrong_Id(int id)
        {
            //Arrange
            var customerUpdate = new CustomerInvoice { CustomerInvoiceName = "Marco", Country = "Italy" };
            var customer = new CustomerInvoice { CustomerInvoiceName = "Luca", Country = "France" };
            _context.CustomerInvoices.Add(customer);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<Exception>(() => _customerRepo.UpdateCustomerInvoice(id, customerUpdate));
            //Assert
            var action = Assert.IsType<Exception>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("CustomerInvoice not found", actionResult);

        }
        */

    }
}
