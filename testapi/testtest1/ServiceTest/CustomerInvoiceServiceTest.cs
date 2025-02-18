using API.Models;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.ServiceTest
{
    public class CustomerInvoiceInvoiceServiceTest
    {

        private readonly CustomerInvoicesServices _customerInvoiceService;
        List<string> statusList = new() { "paid", "unpaid" };
        private readonly Progetto_FormativoContext _context;

        public CustomerInvoiceInvoiceServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);

            // Initialize repository
            _customerInvoiceService = new CustomerInvoicesServices(_context);
        }

        [Fact]
        public async Task Create_CustomerInvoice()//correct customer
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };

            //Act
            var result = _customerInvoiceService.CreateCustomerInvoice(customerInvoice);

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
            var exception = Assert.Throws<ArgumentNullException>(() => _customerInvoiceService.CreateCustomerInvoice(null));

            //Assert

            var actionResult = Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("Value cannot be null. (Parameter 'Couldn't create customer invoice')", actionResult.Message);
        }

        [Theory]
        [InlineData(null, null, null, null, null, null)]
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
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.CreateCustomerInvoice(customerInvoice));

            // Assert
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customerInvoice.CustomerInvoiceId));
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == 1));
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
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.CreateCustomerInvoice(customerInvoice));

            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == 1));

        }
        [Fact]

        public async Task Create_Customer_Invoice_Wrong_Status()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "apple", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };

            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.CreateCustomerInvoice(customerInvoice));

            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == 1));
            Assert.Equal("Incorrect status\nA customer invoice is Paid or Unpaid", actionResult);

        }

        [Fact]
        public async Task Create_CustomerInvoice_Wrong_Sale_Id()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 3, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };

            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.CreateCustomerInvoice(customerInvoice));

            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == 1));
            Assert.Equal($"There is no sale with id {customerInvoice.SaleId}", actionResult);
        }

        [Fact]
        public async Task Delete_CustomerInvoice()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();

            //Act
            var result = _customerInvoiceService.DeleteCustomerInvoice(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customerInvoice.CustomerInvoiceId, result.CustomerInvoiceId);
            Assert.False(_context.CustomerInvoices.Any(c => c.CustomerInvoiceId == customerInvoice.CustomerInvoiceId));
        }

        [Fact]
        public async Task Delete_CustomerInvoice_null()
        {

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => _customerInvoiceService.DeleteCustomerInvoice(1));

            //Assert
            var action = Assert.IsType<ArgumentNullException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Value cannot be null. (Parameter 'Customer invoice not found!')", actionResult);
        }

        [Fact]
        public async Task GetAll_CustomerInvoice()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            var customerInvoice1 = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.CustomerInvoices.Add(customerInvoice1);
            _context.SaveChanges();

            //Act
            var filter = new CustomerInvoiceFilter();
            var result = _customerInvoiceService.GetAllCustomerInvoices(filter);

            //Assert
            var actionResult = Assert.IsType<List<CustomerInvoiceDTOGet>>(result);
            Assert.Equal(2, actionResult.Count);

        }
        [Fact]
        public async Task GetAll_CustomerInvoice_Empty()
        {
            //Act
            var filter = new CustomerInvoiceFilter();
            var result = _customerInvoiceService.GetAllCustomerInvoices(filter);
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
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "unpaid", InvoiceAmount = 1200.0m, InvoiceDate = DateTime.Now };
            var customerInvoice1 = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.CustomerInvoices.Add(customerInvoice1);
            _context.SaveChanges();

            //Act
            var result = _customerInvoiceService.GetCustomerInvoiceById(id);
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
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "unpaid", InvoiceAmount = 1200.0m, InvoiceDate = DateTime.Now };
            var customerInvoice1 = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.CustomerInvoices.Add(customerInvoice1);
            _context.SaveChanges();

            //Act Assert
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.GetCustomerInvoiceById(id));

            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(exception.Message);

            Assert.Equal("Customer invoice not found!", actionResult);
        }

        [Fact]
        public async Task Update_CustomerInvoice()
        {
            //Arrange

            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = 1, Status = "unpaid", InvoiceAmount = 1200.0m, InvoiceDate = DateTime.Now };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var result = _customerInvoiceService.UpdateCustomerInvoice(1, customerInvoiceUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            Assert.Equal(customerInvoiceUpdate.Status, actionResult.Status);
            Assert.Equal(customerInvoiceUpdate.SaleId, actionResult.SaleId);
            Assert.Equal(customerInvoiceUpdate.InvoiceAmount, actionResult.InvoiceAmount);
            Assert.Equal(customerInvoiceUpdate.InvoiceDate, actionResult.InvoiceDate);
        }

        [Theory]
        [InlineData(1, "Paid", 100.0, null, null, null)]
        [InlineData(1, "Paid", null, 2023, 11, 12)]
        [InlineData(1, "Paid", 100.0, 2023, 11, 12)]

        public async Task Update_CustomerInvoice_Not_Present_Params(int? saleId, string status, double? amount, int? y, int? m, int? d)
        {
            //Arrange
            DateTime? date = null;
            if (y.HasValue && m.HasValue && d.HasValue)
            {
                date = new DateTime(y.Value, m.Value, d.Value);
            }
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = saleId, Status = status, InvoiceAmount = (decimal?)amount, InvoiceDate = date };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var result = _customerInvoiceService.UpdateCustomerInvoice(1, customerInvoiceUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerInvoiceDTOGet>(result);
            if (amount == null)
                Assert.Equal(customerInvoice.InvoiceAmount, actionResult.InvoiceAmount);
            else
                Assert.Equal(customerInvoiceUpdate.InvoiceAmount, actionResult.InvoiceAmount);
            if (date == null)
                Assert.Equal(customerInvoice.InvoiceDate, actionResult.InvoiceDate);



        }



        [Theory]
        [InlineData(null)]
        [InlineData(4)]
        [InlineData(-1)]
        public async Task Update_CustomerInvoice_Wrong_Id(int id)
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = 1, Status = "unpaid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => _customerInvoiceService.UpdateCustomerInvoice(id, customerInvoiceUpdate));
            //Assert
            var action = Assert.IsType<ArgumentNullException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Value cannot be null. (Parameter 'Customer invoice not found')", actionResult);

        }

        [Theory]
        [InlineData(1, "apple", 100.0, 2023, 11, 12)]
        public async Task Update_CustomerInvoice_Status_null_not_Correct(int? saleId, string status, double? amount, int? y, int? m, int? d)
        {
            //Arrange
            DateTime? date = null;
            if (y.HasValue && m.HasValue && d.HasValue)
            {
                date = new DateTime(y.Value, m.Value, d.Value);
            }
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = saleId, Status = status, InvoiceAmount = (decimal?)amount, InvoiceDate = date };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.UpdateCustomerInvoice(1, customerInvoiceUpdate));
            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);

            Assert.Equal("Incorrect status\nA customer invoice is Paid or Unpaid", actionResult);

        }
        [Fact]
        public async Task Update_CustomerInvoice_Negative_Amount()
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = -100.0m, InvoiceDate = DateTime.Now };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.UpdateCustomerInvoice(1, customerInvoiceUpdate));
            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);

            Assert.Equal("The amount can't be less or equal than 0", actionResult);

        }
        [Theory]
        [InlineData(2)]
        [InlineData(null)]

        public async Task Update_CustomerInvoice_SaleID_not_found(int id)
        {
            //Arrange
            var sale = new Sale { };
            _context.Sales.Add(sale);
            _context.SaveChanges();
            var customerInvoiceUpdate = new CustomerInvoice { SaleId = id, Status = "paid", InvoiceAmount = -100.0m, InvoiceDate = DateTime.Now };
            var customerInvoice = new CustomerInvoice { SaleId = 1, Status = "paid", InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now };
            _context.CustomerInvoices.Add(customerInvoice);
            _context.SaveChanges();
            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerInvoiceService.UpdateCustomerInvoice(1, customerInvoiceUpdate));
            //Assert
            var action = Assert.IsType<ArgumentException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);

            Assert.Equal("SaleId not found", actionResult);

        }
    }
}
