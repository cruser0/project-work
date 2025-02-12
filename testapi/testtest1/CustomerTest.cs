using Xunit;
using testapi.Controllers;
using testapi.Repo;
using testapi.Models;
using testapi.Models.Mapper;
using testapi.Models.DTO;

using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace testtest1
{
    public class CustomerTest
    {
        private readonly CustomerController _customerController;
        private readonly Mock<ICustomerREPO> _mockCustomerService;

        public CustomerTest()
        {
            _mockCustomerService = new Mock<ICustomerREPO>();
            _customerController = new CustomerController(_mockCustomerService.Object);
        }
        [Fact]
        public async Task Get_ReturnOkResult_Customer()
        {
            // Arrange
            var customers = new List<CustomerDTOGet>
        {
            new CustomerDTOGet { CustomerId = 1, CustomerName = "Pier Paolo Pittavino", Country = "Italy" }
        };
            _mockCustomerService.Setup(service => service.GetAllCustomers()).Returns(customers);

            // Act
            var result = _customerController.Get();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CustomerDTOGet>>(actionResult.Value);
            Assert.Equal(customers.Count, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnBadResult_Customer()
        {
            // Arrange
            var customers = new List<CustomerDTOGet>
        {
        };
            _mockCustomerService.Setup(service => service.GetAllCustomers()).Returns(customers);

            // Act
            var result = _customerController.Get();

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer not found", returnValue);
        }

        [Fact]
        public async Task GetByID_ReturnOK_Customer()
        {
            // Arrange
            var customers =new Customer { CustomerId = 1, CustomerName = "Pier Paolo Pittavino", Country = "Italy" };
            _mockCustomerService.Setup(service => service.GetCustomerById(1)).Returns(CustomerMapper.MapGet(customers));

            // Act
            var result = _customerController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.CustomerId, customers.CustomerId);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_Customer()
        {
            // Arrange
            _mockCustomerService.Setup(service => service.GetCustomerById(1)).Returns((CustomerDTOGet)null);

            // Act
            var result = _customerController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer not found!", returnValue);
        }


        [Theory]
        [InlineData(1, "", "Italy")]
        [InlineData(1, "Marco", "")]
        [InlineData(1, "", "")]
        public async Task PostCustomer_ReturnBadRequest_Customer_null_data(int id,string name,string country)
        {
            // Arrange
            var customerDto = new CustomerDTO { CustomerName = name, Country = country };
            _mockCustomerService
            .Setup(service => service.CreateCustomer(It.IsAny<Customer>()))
            .Throws(new Exception("Data can't be null"));
                


            // Act
            var result =_customerController.Post(customerDto);


            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Data can't be null", returnValue);

        }

        [Fact]
        public async Task PostCustomer_ReturnOK_Customer()
        {
            // Arrange
            var customerDto = new CustomerDTO { CustomerName = "Pier Paolo Pittavino", Country = "Italy" };
            var expectedCustomer = new Customer { CustomerId = 1, CustomerName = "Pier Paolo Pittavino", Country = "Italy" };

            _mockCustomerService
            .Setup(service => service.CreateCustomer(It.IsAny<Customer>()))
            .Returns(CustomerMapper.MapGet( expectedCustomer));

            // Act
            var result = _customerController.Post(customerDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);

            Assert.Equal(expectedCustomer.CustomerId, returnValue.CustomerId);
        }

        [Fact]
        public async Task PostCustomer_ReturnBadRequest_Customer()
        {
            

            // Arrange
            _mockCustomerService
            .Setup(service => service.CreateCustomer(null))
            .Throws(new Exception("Couldn't create customer"));

            // Act
            var result = _customerController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create customer", returnValue);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnOK_Customer()
        {
            //Arrange
            Customer customer = new() { CustomerId = 1, CustomerName = "Pier Paolo", Country = "Italy" };
            _mockCustomerService
                .Setup(service => service.DeleteCustomer(1))
                .Returns(CustomerMapper.MapGet( customer));


            // Act
            var result = _customerController.Delete(1);


            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue= Assert.IsType<CustomerDTOGet>(actionResult.Value);
            Assert.NotNull(returnValue);
            Assert.Equal(customer.CustomerId, returnValue.CustomerId);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnBadRequest_Customer()
        {
            //Arrange
            Customer customer = new() { CustomerId = 1, CustomerName = "Pier Paolo", Country = "Italy" };
            _mockCustomerService
                .Setup(service => service.DeleteCustomer(2))
                .Throws(new Exception("Customer not found!"));


            //Act
            var result = _customerController.Delete(2);


            //Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer not found!", returnValue);
        }


        [Theory]
        [InlineData(1, "Marco", "Italy")]
        [InlineData(1, "", "Italy")]
        [InlineData(1, "Marco", "")]
        [InlineData(1, "", "")]
        public async Task Put_ReturnOk_Customer(int id, string name, string country)
        {
            //Arrange
            var originalCustomer = new Customer { CustomerId = id, CustomerName = "Luca", Country = "Japan" };
            var updatedCustomer = new Customer { CustomerId = id, CustomerName = name, Country = country };

            if (string.IsNullOrEmpty(name))
                updatedCustomer.CustomerName = originalCustomer.CustomerName;

            if (string.IsNullOrEmpty(country))
                updatedCustomer.Country = originalCustomer.Country;

            _mockCustomerService.Setup(service => service.UpdateCustomer(id, It.IsAny<Customer>()))
                        .Returns(CustomerMapper.MapGet(  updatedCustomer));

            // Act
            var result = _customerController.Put(id, CustomerMapper.Map(updatedCustomer));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);
            if (string.IsNullOrEmpty(name))
                Assert.Equal(originalCustomer.CustomerName, returnValue.CustomerName);
            else
                Assert.Equal(updatedCustomer.CustomerName, returnValue.CustomerName);
            Assert.Equal(id, returnValue.CustomerId);
            if (string.IsNullOrEmpty(country))
                Assert.Equal(originalCustomer.Country, returnValue.Country);
            else
                Assert.Equal(updatedCustomer.Country, returnValue.Country);
        }
        [Fact]
        public async Task Put_ReutrnBadRequest_Customer()
        {
            //Arrange
            var supplier = new Customer { CustomerId = 1, CustomerName = "Xiaomi", Country = "Japan" };



            _mockCustomerService.Setup(service => service.UpdateCustomer(2, It.IsAny<Customer>()))
                        .Throws(new Exception("Customer not found!"));

            // Act
            var result = _customerController.Put(2, CustomerMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Customer not found!", returnValue);

        }








    }
}