using API.Controllers;
using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace API_Test.ControllerTest
{
    public class CustomerInvoiceTest
    {
        private readonly CustomerInvoiceController _customerController;
        private readonly Mock<ICustomerInvoicesService> _mockCustomerInvoiceService;

        public CustomerInvoiceTest()
        {
            _mockCustomerInvoiceService = new Mock<ICustomerInvoicesService>();
            _customerController = new CustomerInvoiceController(_mockCustomerInvoiceService.Object);
        }
        [Fact]
        public async Task Get_ReturnOkResult_CustomerInvoice()
        {
            // Arrange
            var customers = new List<CustomerInvoiceDTOGet>{
            new CustomerInvoiceDTOGet { CustomerInvoiceId=1,InvoiceAmount=100,InvoiceDate=DateTime.Now,Status="Paid",SaleId=1 }
            };
            var filter = new CustomerInvoiceFilter();
            _mockCustomerInvoiceService.Setup(service => service.GetAllCustomerInvoices(filter)).Returns(customers);

            // Act
            var result = _customerController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<CustomerInvoiceDTOGet>>(actionResult.Value);
            Assert.Equal(customers.Count, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnBadResult_CustomerInvoice()
        {
            // Arrange
            var customers = new List<CustomerInvoiceDTOGet>
            {
            };
            var filter = new CustomerInvoiceFilter();
            _mockCustomerInvoiceService.Setup(service => service.GetAllCustomerInvoices(filter)).Returns(customers);

            // Act
            var result = _customerController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer Invoices not found", returnValue);
        }

        [Fact]
        public async Task GetByID_ReturnOK_CustomerInvoice()
        {
            // Arrange
            var customerInvoice = new CustomerInvoiceDTOGet { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };
            _mockCustomerInvoiceService.Setup(service => service.GetCustomerInvoiceById(1)).Returns(customerInvoice);

            // Act
            var result = _customerController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.CustomerInvoiceId, customerInvoice.CustomerInvoiceId);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_CustomerInvoice()
        {
            // Arrange
            _mockCustomerInvoiceService.Setup(service => service.GetCustomerInvoiceById(1)).Returns((CustomerInvoiceDTOGet)null);

            // Act
            var result = _customerController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer Invoices not found", returnValue);
        }


        [Fact]
        public async Task PostCustomerInvoice_ReturnOK_CustomerInvoice()
        {
            // Arrange
            var customerInvoiceDto = new CustomerInvoiceDTO { InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };
            var expectedCustomerInvoice = new CustomerInvoice { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };

            _mockCustomerInvoiceService
            .Setup(service => service.CreateCustomerInvoice(It.IsAny<CustomerInvoice>()))
            .Returns(CustomerInvoiceMapper.MapGet(expectedCustomerInvoice));

            // Act
            var result = _customerController.Post(customerInvoiceDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerInvoiceDTOGet>(actionResult.Value);

            Assert.Equal(expectedCustomerInvoice.CustomerInvoiceId, returnValue.CustomerInvoiceId);
        }

        [Fact]
        public async Task PostCustomerInvoice_ReturnBadRequest_CustomerInvoice_null()
        {

            // Arrange
            _mockCustomerInvoiceService
            .Setup(service => service.CreateCustomerInvoice(null))
            .Throws(new Exception("Couldn't create customer"));

            // Act
            var result = _customerController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create customer", returnValue);
        }

        [Fact]
        public async Task PostCustomerInvoice_ReturnBadRequest_CustomerInvoice_saleId_null()
        {


            // Arrange
            var customerInvoice = new CustomerInvoice { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };
            _mockCustomerInvoiceService
            .Setup(service => service.CreateCustomerInvoice(It.IsAny<CustomerInvoice>()))
            .Throws(new Exception("Sale ID doesn't exist!"));

            // Act
            var result = _customerController.Post(CustomerInvoiceMapper.Map(customerInvoice));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Sale ID doesn't exist!", returnValue);
        }


        [Fact]
        public async Task DeleteCustomerInvoice_ReturnOK_CustomerInvoice()
        {
            //Arrange
            CustomerInvoiceDTOGet customer = new() { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };
            _mockCustomerInvoiceService
                .Setup(service => service.DeleteCustomerInvoice(1))
                .Returns(customer);


            // Act
            var result = _customerController.Delete(1);


            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerInvoiceDTOGet>(actionResult.Value);
            Assert.NotNull(returnValue);
            Assert.Equal(customer.CustomerInvoiceId, returnValue.CustomerInvoiceId);
        }

        [Fact]
        public async Task DeleteCustomerInvoice_ReturnBadRequest_CustomerInvoice()
        {
            //Arrange
            _mockCustomerInvoiceService
                .Setup(service => service.DeleteCustomerInvoice(2))
                .Throws(new Exception("Customer Invoice not found!"));


            //Act
            var result = _customerController.Delete(2);


            //Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer Invoice not found!", returnValue);
        }




        [Theory]
        [InlineData(1, 100, 2022, 11, 09, "Paid", 1)]
        [InlineData(1, 100, 2022, 11, 09, "Paid", null)]
        [InlineData(1, 100, 2022, 11, 09, null, 1)]
        [InlineData(1, 100, null, null, null, "Paid", 1)]
        [InlineData(1, null, 2022, 11, 09, "Paid", 1)]
        [InlineData(1, null, null, null, null, null, null)]
        public async Task Put_ReturnOk_CustomerInvoice(int customerInvoiceId, int invoiceAmount, int? y, int? m, int? d, string? status, int? saleID)
        {
            // Arrange
            DateTime? date = null;
            if (y.HasValue && m.HasValue && d.HasValue)
            {
                date = new DateTime(y.Value, m.Value, d.Value);
            }
            decimal? invoiceAmountDecimal = invoiceAmount;
            var originalCustomerInvoice = new CustomerInvoice { CustomerInvoiceId = customerInvoiceId, InvoiceAmount = 100.0m, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };
            var updatedCustomerInvoice = new CustomerInvoice
            {
                CustomerInvoiceId = customerInvoiceId,
                InvoiceAmount = invoiceAmountDecimal ?? originalCustomerInvoice.InvoiceAmount,
                InvoiceDate = date ?? originalCustomerInvoice.InvoiceDate,
                Status = status ?? originalCustomerInvoice.Status,
                SaleId = saleID ?? originalCustomerInvoice.SaleId
            };

            _mockCustomerInvoiceService.Setup(service => service.UpdateCustomerInvoice(customerInvoiceId, It.IsAny<CustomerInvoice>()))
                .Returns(CustomerInvoiceMapper.MapGet(updatedCustomerInvoice));

            // Act
            var result = _customerController.Put(customerInvoiceId, CustomerInvoiceMapper.Map(updatedCustomerInvoice));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CustomerInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(customerInvoiceId, returnValue.CustomerInvoiceId);
            Assert.Equal(updatedCustomerInvoice.InvoiceAmount, returnValue.InvoiceAmount);
            Assert.Equal(updatedCustomerInvoice.Status, returnValue.Status);
            Assert.Equal(updatedCustomerInvoice.SaleId, returnValue.SaleId);

            if (date.HasValue)
            {
                Assert.Equal(updatedCustomerInvoice.InvoiceDate, returnValue.InvoiceDate);
            }
            else
            {
                Assert.Equal(originalCustomerInvoice.InvoiceDate, returnValue.InvoiceDate);
            }
        }

        [Fact]
        public async Task Put_ReutrnBadRequest_CustomerInvoice()
        {
            //Arrange
            var supplier = new CustomerInvoice { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 1 };



            _mockCustomerInvoiceService.Setup(service => service.UpdateCustomerInvoice(2, It.IsAny<CustomerInvoice>()))
                        .Throws(new Exception("Customer Invoice not found!"));

            // Act
            var result = _customerController.Put(2, CustomerInvoiceMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Customer Invoice not found!", returnValue);

        }

        [Fact]
        public async Task Put_ReutrnBadRequest_CustomerInvoice_Wrong_Sale_Id()
        {
            //Arrange
            var supplier = new CustomerInvoice { CustomerInvoiceId = 1, InvoiceAmount = 100, InvoiceDate = DateTime.Now, Status = "Paid", SaleId = 121 };



            _mockCustomerInvoiceService.Setup(service => service.UpdateCustomerInvoice(1, It.IsAny<CustomerInvoice>()))
                        .Throws(new Exception("SaleID was not found!"));

            // Act
            var result = _customerController.Put(1, CustomerInvoiceMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("SaleID was not found!", returnValue);

        }

    }
}
