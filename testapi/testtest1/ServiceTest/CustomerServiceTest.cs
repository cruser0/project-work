﻿using API.Models;
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
    public class CustomerServiceTest
    {
        private readonly CustomerServices _customerService;
        private readonly Mock<ISalesService> _mockSalesService;
        private readonly Progetto_FormativoContext _context;

        public CustomerServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<Progetto_FormativoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new Progetto_FormativoContext(options);
            _mockSalesService = new Mock<ISalesService>();

            // Initialize repository
            _customerService = new CustomerServices(_context, _mockSalesService.Object);
        }

        [Fact]
        public async Task GetAll_Customer()
        {
            //Arrange
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customer1 = new Customer { CustomerName = "Luca", Country = "Italy" };
            _context.Customers.Add(customer);
            _context.Customers.Add(customer1);
            await _context.SaveChangesAsync();

            //Act
            var result = _customerService.GetAllCustomers(new CustomerFilter());

            //Assert
            var actionResult = Assert.IsType<List<CustomerDTOGet>>(result);
            Assert.Equal(2, actionResult.Count);

        }
        [Fact]
        public async Task GetAll_Customer_Empty()
        {
            //Act
            var result = _customerService.GetAllCustomers(new CustomerFilter());
            //Assert
            var actionResult = Assert.IsType<List<CustomerDTOGet>>(result);
            Assert.Empty(actionResult);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Get_Customer_BY_Id(int id)
        {
            //Arrange
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customer1 = new Customer { CustomerName = "Luca", Country = "Italy" };
            _context.Customers.Add(customer);
            _context.Customers.Add(customer1);
            await _context.SaveChangesAsync();

            //Act
            var result = _customerService.GetCustomerById(id);
            //Assert
            var actionResult = Assert.IsType<CustomerDTOGet>(result);
            Assert.Equal(id, actionResult.CustomerId);

        }

        [Theory]
        [InlineData(3)]
        [InlineData(null)]
        [InlineData(-1)]
        public async Task Get_Customer_BY_Non_Existing_Id(int id)
        {
            //Arrange
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customer1 = new Customer { CustomerName = "Luca", Country = "Italy" };
            _context.Customers.Add(customer);
            _context.Customers.Add(customer1);
            _context.SaveChanges();

            //Act Assert
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _customerService.GetCustomerById(id));

            var action = Assert.IsType<NotFoundException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);

            Assert.Equal("Customer not found!", actionResult);
        }

        [Fact]
        public async Task Create_Customer()//correct customer
        {
            //Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "Marco", Country = "Italy",CreatedAt=DateTime.Now };

            //Act
            var result =await _customerService.CreateCustomer(customer);

            //Assert
            Assert.NotNull(result);
            var actionResult = Assert.IsType<CustomerDTOGet>(result);
            Assert.True(await _context.Customers.AnyAsync(c => c.CustomerId == customer.CustomerId));
            Assert.Equal(customer.CustomerName, actionResult.CustomerName);
        }

        [Fact]
        public async Task Create_Customer_null()//customer null
        {
            //Act Arrange
            var exception = Assert.ThrowsAsync<NullPropertyException>(async () => await _customerService.CreateCustomer(null));

            //Assert

            var actionResult = Assert.IsType<NullPropertyException>(exception);
            Assert.Equal("Couldn't create customer", actionResult.Message);
        }

        [Theory]
        [InlineData(1, "Marco", null, false)]
        [InlineData(1, null, "Italy",false)]
        [InlineData(1, "Marco", "Italy",true)]
        public async Task Create_Customer_null_parameters(int id, string name, string country,bool deprecated)//customer null
        {
            //Arrange
            var customer = new Customer { CustomerId = id, CustomerName = name, Country = country };
            //Act
            var exception = Assert.ThrowsAsync<NullPropertyException>(async () => await _customerService.CreateCustomer(customer));

            //Assert
            Assert.False(await _context.Customers.AnyAsync(c => c.CustomerId == customer.CustomerId));
            
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(country))
            {
                var actionResult= Assert.IsType<NullPropertyException>(exception);
                Assert.Equal("CustomerName is null", actionResult.Message);
            }
            if (string.IsNullOrEmpty(country) && !string.IsNullOrEmpty(name))
            {
                var actionResult = Assert.IsType<NullPropertyException>(exception);
                Assert.Equal("Country is null", actionResult.Message);
            }
            if (string.IsNullOrEmpty(country) && string.IsNullOrEmpty(name))
            {
                var actionResult = Assert.IsType<NullPropertyException>(exception);
                Assert.Equal("CustomerName, Country are null", actionResult.Message);
            }
            if (deprecated)
            {
                var actionResult = Assert.IsType<ErrorInputPropertyException>(exception);
                Assert.Equal("Can't create an already deprecated customer", actionResult.Message);
            }
        }

        [Fact]
        public async Task Create_Customer_Name_Too_Long()//correct customer
        {
            //Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "Marco".PadRight(101, 'X'), Country = "Italy" };

            //Act
            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () => await _customerService.CreateCustomer(customer));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Customer name is too long", actionResult);
        }

        [Fact]
        public async Task Create_Customer_Country_Too_Long()
        {
            //Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "Marco", Country = "Italy".PadRight(51, 'X') };

            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () => await _customerService.CreateCustomer(customer));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Country is too long", actionResult);
        }

        [Fact]
        public async Task Create_Customer_Country_Special_Characters()
        {
            //Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "Marco", Country = "1" };

            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () => await _customerService.CreateCustomer(customer));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Country can't have special characters", actionResult);
        }

        [Fact]
        public void customerService_ThrowError_CreateSupplier_DuplicateCustomer()
        {
            var customer = new Customer() { CustomerId = 1, CustomerName = "Name", Country = "Country" };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var exception = Assert.ThrowsAsync<DbUpdateException>(
                () => _customerService.CreateCustomer(customer));
            var result=Assert.IsType<DbUpdateException>(exception);
            Assert.Contains("The statement has been terminated", result.InnerException.Message);
        }

        [Fact]
        public async Task Update_Customer()
        {
            //Arrange

            var customer = new Customer { CustomerName = "Marco", Country = "Italy",CreatedAt=DateTime.Now,Deprecated=false };
            var customerUpdate = new Customer { CustomerName = "Luca", Country = "France" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var result = _customerService.UpdateCustomer(1, customerUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerDTOGet>(result);
            Customer oldc = await _context.Customers.Where(x => x.CustomerId == 1).FirstOrDefaultAsync();
            Customer newc = await _context.Customers.Where(x => x.CustomerId == 2).FirstOrDefaultAsync();

            Assert.Equal(customerUpdate.CustomerName, actionResult.CustomerName);
            Assert.Equal(true,oldc.Deprecated);
            Assert.Equal(false,newc.Deprecated);
            Assert.Equal(customerUpdate.CustomerName, actionResult.CustomerName);
            Assert.Equal(customerUpdate.Country, actionResult.Country);
        }

        [Theory]
        [InlineData("Marco", null)]
        [InlineData("Marco", "")]
        [InlineData("", "Italy")]
        [InlineData(null, "Italy")]
        public async Task Update_Customer_Not_Present_Params(string name, string country)
        {
            //Arrange
            var customerUpdate = new Customer { CustomerName = name, Country = country, Deprecated = false };
            var customer = new Customer { CustomerId = 1, CustomerName = "Luca", Country = "France", Deprecated = false };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var result = _customerService.UpdateCustomer(1, customerUpdate);
            //Assert
            var actionResult = Assert.IsType<CustomerDTOGet>(result);

            Assert.Equal(country == null ? customer.Country : customerUpdate.Country, actionResult.Country);
            Assert.Equal(name == null ? customer.CustomerName : customerUpdate.CustomerName, actionResult.CustomerName);
            Assert.True(customer.Deprecated);

        }

        [Theory]
        [InlineData(null)]
        [InlineData(4)]
        [InlineData(-1)]
        public async Task Update_Customer_Wrong_Id(int id)
        {
            //Arrange
            var customerUpdate = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customer = new Customer { CustomerName = "Luca", Country = "France" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await _customerService.UpdateCustomer(id, customerUpdate));
            //Assert
            var action = Assert.IsType<NotFoundException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Customer not found", actionResult);

        }

        [Fact]
        public async Task Update_Customer_Name_too_Long()
        {
            //Arrange

            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customerUpdate = new Customer { CustomerName = "Luca".PadRight(101, 'X'), Country = "France" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () =>await  _customerService.UpdateCustomer(1, customerUpdate));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Customer name is too long", actionResult);
        }

        [Fact]
        public async Task Update_Customer_Country_too_Long()
        {
            //Arrange

            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customerUpdate = new Customer { CustomerName = "Luca", Country = "France".PadRight(51, 'X') };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () =>await  _customerService.UpdateCustomer(1, customerUpdate));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Country is too long", actionResult);
        }

        [Fact]
        public async Task Update_Customer_Country_Special_Characters()
        {
            //Arrange

            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            var customerUpdate = new Customer { CustomerName = "Luca", Country = "@" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //Act
            var exception = Assert.ThrowsAsync<ErrorInputPropertyException>(async () =>await _customerService.UpdateCustomer(1, customerUpdate));
            //Assert
            var action = Assert.IsType<ErrorInputPropertyException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Country can't have special characters", actionResult);
        }


        [Fact]
        public async Task Delete_Customer_with_sale()
        {
            //Arrange
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            var sales = new Sale { BoLnumber = "1", BookingNumber = "2", CustomerId = 1, SaleDate = DateTime.Now, SaleId = 1, Status = "paid", TotalRevenue = 1000 };
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();

            //Act
            var result = await _customerService.DeleteCustomer(1);

            //Assert
            _mockSalesService.Verify(s => s.DeleteSale(sales.SaleId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerId, result.CustomerId);
            Assert.False(await _context.Customers.AnyAsync(c => c.CustomerId == customer.CustomerId));
        }

        [Fact]
        public async Task Delete_Customer()
        {
            //Arrange
            var customer = new Customer { CustomerName = "Marco", Country = "Italy" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            //Act
            var result =await _customerService.DeleteCustomer(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customer.CustomerId, result.CustomerId);
            Assert.False(_context.Customers.Any(c => c.CustomerId == customer.CustomerId));
        }

        [Fact]
        public async Task Delete_No_Customer()
        {
            var exception = Assert.ThrowsAsync<NotFoundException>(async () =>await  _customerService.DeleteCustomer(1));
            //Assert
            var action = Assert.IsType<NotFoundException>(exception);
            var actionResult = Assert.IsType<string>(action.Message);
            Assert.Equal("Customer not found!", actionResult);
        }

    }
}
