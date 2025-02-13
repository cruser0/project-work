using Microsoft.EntityFrameworkCore;
using Moq;
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
    public class CustomerREPOTest
    {
        private readonly CustomerREPO _customerRepo;
        private readonly Mock<ISalesREPO> _mockSalesRepo;
        private readonly Progetto_FormativoContext _context;

        public CustomerREPOTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);
            _mockSalesRepo = new Mock<ISalesREPO>();

            // Initialize repository
            _customerRepo = new CustomerREPO(_context, _mockSalesRepo.Object);
        }

        [Fact]
        public async Task Create_Customer_OkResponse()//correct customer
        {
            //Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "Marco", Country = "Italy" };

            //Act
            var result=_customerRepo.CreateCustomer(customer);

            //Assert
            Assert.NotNull(result);
            var actionResult = Assert.IsType<CustomerDTOGet>(result);
            Assert.True(_context.Customers.Any(c => c.CustomerId == customer.CustomerId));
            Assert.Equal(customer.CustomerName, actionResult.CustomerName);
        }
        [Fact]
        public async Task Create_Customer_BadResponse_Customer_null()//customer null
        {
            //Act
            var exception = Assert.Throws<Exception>(() => _customerRepo.CreateCustomer(null));

            //Assert

            var actionResult = Assert.IsType<Exception>(exception);
            Assert.Equal("Couldn't create customer", actionResult.Message);
        }
        [Theory]
        [InlineData(1,"Marco",null)]
        [InlineData(1, null, null)]
        [InlineData(1, null, "Italy")]
        public async Task Create_Customer_BadResponse_Customer_attributes_null(int id,string name,string country)//customer null
        {
            var customer = new Customer { CustomerId = id, CustomerName = name, Country = country };
            //Act
            var exception = Assert.Throws<ArgumentException>(() => _customerRepo.CreateCustomer(customer));

            //Assert
            Assert.False(_context.Customers.Any(c => c.CustomerId == customer.CustomerId));
            var actionResult = Assert.IsType<ArgumentException>(exception);
            if(string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(country))
                Assert.Equal("CustomerName is null", actionResult.Message);
            if (string.IsNullOrEmpty(country) && !string.IsNullOrEmpty(name))
                Assert.Equal("Country is null", actionResult.Message);
            if (string.IsNullOrEmpty(country) && string.IsNullOrEmpty(name))
                Assert.Equal("CustomerName, Country are null", actionResult.Message);

        }
        [Fact]
        public async Task Delete_Customer_OkResponde_Customer_with_sale()
        {
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var sales = new Sale { BoLnumber = "1", BookingNumber = "2", CustomerId = 1, SaleDate = DateTime.Now, SaleId = 1, Status = "paid", TotalRevenue = 1000 };
            _context.Sales.Add(sales);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.DeleteCustomer(1);

            //Assert
            _mockSalesRepo.Verify(s => s.DeleteSale(sales.SaleId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerId, result.CustomerId);
            Assert.False(_context.Customers.Any(c => c.CustomerId == customer.CustomerId));
        }
        [Fact]
        public async Task Delete_Customer_OkResponde_Customer()
        {
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //Act
            var result = _customerRepo.DeleteCustomer(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerId, result.CustomerId);
            Assert.False(_context.Customers.Any(c => c.CustomerId == customer.CustomerId));
        }
    }
}
