using API.Controllers;
using API.Models.Exceptions;
using API.Models.Mapper;
using API.Models.Services;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace API_Test.ControllerTest
{
    public class CustomerTest
    {
        private readonly CustomerController _customerController;
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<ICountryService> _mockCountryService;

        public CustomerTest()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _mockCountryService = new Mock<ICountryService>();
            _customerController = new CustomerController(_mockCustomerService.Object, _mockCountryService.Object);
        }
        [Fact]
        public async Task Get_ReturnOkResult_Customer()
        {
            // Arrange
            var customers = new List<CustomerDTOGet>
            {
            new CustomerDTOGet { CustomerId = 1, CustomerName = "customer1", Country = "Italy" }
            };

            var filter = new CustomerFilter { CustomerName = "", CustomerCountry = "" };
            _mockCustomerService.Setup(service => service.GetAllCustomers(filter)).ReturnsAsync(customers);

            // Act
            var result = await _customerController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CustomerDTOGet>>(actionResult.Value);
            Assert.Equal(customers.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetEmpty_ReturnOkResult_Customer()
        {
            // Arrange
            var customers = new List<CustomerDTOGet>
            {
            };
            var filter = new CustomerFilter { CustomerName = "", CustomerCountry = "" };
            _mockCustomerService.Setup(service => service.GetAllCustomers(filter)).ReturnsAsync(customers);

            // Act
            var result = await _customerController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CustomerDTOGet>>(actionResult.Value);
            Assert.Equal(customers.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetByID_ReturnOK_Customer()
        {
            var country = new Country { CountryID = 1, CountryName = "Italy" };

            // Arrange
            var customers = new Customer { CustomerID = 1, CustomerName = "Pier Paolo Pittavino", CountryID = 1, Country = country };
            _mockCustomerService.Setup(service => service.GetCustomerById(1)).ReturnsAsync(CustomerMapper.MapGet(customers));

            // Act
            var result = await _customerController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.CustomerId, customers.CustomerID);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_Customer()
        {
            // Arrange
            var exception = await Assert.ThrowsAsync<NotFoundException>(
               () => _customerController.Get(1));
            Assert.Equal("Customer not found!", exception.Message);
        }


        [Theory]
        [InlineData(1, "", "Italy")]
        [InlineData(1, "Marco", "")]
        [InlineData(1, "", "")]
        public async Task PostCustomer_ReturnBadRequest_Customer_null_data(int id, string name, string country)
        {
            // Arrange
            var customerDto = new CustomerDTO { CustomerName = name, Country = country };

            var exception = await Assert.ThrowsAsync<ValidateException>(
               () => _customerController.Post(customerDto));

            Assert.Equal("Required.", exception.Message);

        }

        [Fact]
        public async Task PostCustomer_ReturnOK_Customer()
        {
            // Arrange
            var customerDto = new CustomerDTO { CustomerName = "Pier Paolo Pittavino", Country = "Italy" };
            var expectedCustomer = new Customer { CustomerID = 1, CustomerName = "Pier Paolo Pittavino", CountryID = 1, Country = new Country() { CountryID = 1, CountryName = "Italy" } };

            _mockCustomerService
            .Setup(service => service.CreateCustomer(It.IsAny<Customer>()))
            .ReturnsAsync(CustomerMapper.MapGet(expectedCustomer));

            // Act
            var result = await _customerController.Post(customerDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);

            Assert.Equal(expectedCustomer.CustomerID, returnValue.CustomerId);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnOK_Customer()
        {
            //Arrange
            Customer customer = new() { CustomerID = 1, CustomerName = "Pier Paolo", CountryID = 1, Country = new Country { CountryID = 1, CountryName = "Italy" } };
            _mockCustomerService
                .Setup(service => service.DeleteCustomer(1))
                .ReturnsAsync(CustomerMapper.MapGet(customer));


            // Act
            var result = await _customerController.Delete(1);


            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);
            Assert.NotNull(returnValue);
            Assert.Equal(customer.CustomerID, returnValue.CustomerId);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnBadRequest_Customer()
        {
            var exception = await Assert.ThrowsAsync<NotFoundException>(
               () => _customerController.Delete(1));

            Assert.Equal("Customer not found!", exception.Message);
        }


        [Theory]
        [InlineData(1, "Marco", "Italy", 1)]
        [InlineData(1, "", "Italy", 1)]
        [InlineData(1, "Marco", "", null)]
        [InlineData(1, "", "", null)]
        public async Task Put_ReturnOk_Customer(int id, string name, string country, int? countryId)
        {
            //Arrange
            var originalCustomer = new Customer { CustomerID = id, CustomerName = "Luca", CountryID = 2, Country = new Country { CountryName = "Japan", CountryID = 2 } };
            var updatedCustomer = new Customer { CustomerID = id, CustomerName = name, CountryID = countryId, Country = new Country { CountryName = country, CountryID = (int)countryId } };

            if (string.IsNullOrEmpty(name))
                updatedCustomer.CustomerName = originalCustomer.CustomerName;

            if (string.IsNullOrEmpty(country))
                updatedCustomer.Country = originalCustomer.Country;

            _mockCustomerService.Setup(service => service.UpdateCustomer(id, It.IsAny<Customer>()))
                        .ReturnsAsync(CustomerMapper.MapGet(updatedCustomer));

            // Act
            var result = await _customerController.Put(id, CustomerMapper.Map(updatedCustomer));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerDTOGet>(actionResult.Value);

            if (string.IsNullOrEmpty(name))
                Assert.Equal(originalCustomer.CustomerName, returnValue.CustomerName);
            else
                Assert.Equal(updatedCustomer.CustomerName, returnValue.CustomerName);

            Assert.Equal(id, returnValue.CustomerId);

            if (string.IsNullOrEmpty(country))
                Assert.Equal(originalCustomer.Country.CountryName, returnValue.Country);
            else
                Assert.Equal(updatedCustomer.Country.CountryName, returnValue.Country);
        }

        //[Fact]
        //public async Task Put_ReutrnBadRequest_Customer()
        //{
        //    //Arrange
        //    var supplier = new Customer { CustomerId = 1, CustomerName = "Xiaomi", Country = "Japan" };



        //    _mockCustomerService.Setup(service => service.UpdateCustomer(2, It.IsAny<Customer>()))
        //                .Throws(new Exception("Customer not found!"));

        //    // Act
        //    var result = _customerController.Put(2, CustomerMapper.Map(supplier));

        //    // Assert
        //    var actionResult = Assert.IsType<BadRequestObjectResult>(result);
        //    var returnValue = Assert.IsType<string>(actionResult.Value);

        //    Assert.Equal("Customer not found!", returnValue);

        //}








    }
}