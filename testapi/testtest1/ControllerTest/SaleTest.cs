using API.Controllers;
using API.Models.DTO;
using API.Models.Entities;
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
    public class SalesTest
    {
        private readonly SaleController _saleController;
        private readonly Mock<ISalesService> _mockSaleService;

        public SalesTest()
        {
            _mockSaleService = new Mock<ISalesService>();
            _saleController = new SaleController(_mockSaleService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_Sale()
        {
            // Arrange
            var sales = new List<SaleDTOGet>
        {
            new SaleDTOGet
            {
                SaleId = 1,
                BookingNumber = "BN1",
                BoLnumber = "BOL1",
                SaleDate  = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Open"

            }
        };
            _mockSaleService.Setup(service => service.GetAllSales()).Returns(sales);

            // Act
            var result = _saleController.Get();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<SaleDTOGet>>(actionResult.Value);
            Assert.Equal(sales.Count, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnBadResult_Sale()
        {
            var sales = new List<SaleDTOGet>();
            _mockSaleService.Setup(service => service.GetAllSales()).Returns(sales);

            // Act
            var result = _saleController.Get();

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Sale not found", returnValue);
        }

        [Fact]
        public async Task GetByID_ReturnsOkResult_Sale()
        {
            // Arrange
            var sale = new SaleDTOGet
            {
                SaleId = 1,
                BookingNumber = "BN1",
                BoLnumber = "BOL1",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Open"
            };
            _mockSaleService.Setup(service => service.GetSaleById(1)).Returns(sale);

            // Act
            var result = _saleController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SaleDTOGet>(actionResult.Value);
            Assert.Equal(sale.SaleId, returnValue.SaleId);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_Sale()
        {
            _mockSaleService.Setup(service => service.GetSaleById(1)).Throws(new ArgumentException("Sale not found!"));

            // Act
            var result = _saleController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Sale not found!", returnValue);
        }

        [Fact]
        public async Task PostSale_ReturnOK_Sale()
        {
            // Arrange
            var expectedSale = new Sale
            {
                SaleId = 1,
                BookingNumber = "BN1",
                BoLnumber = "BOL1",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Open"
            };
            _mockSaleService
            .Setup(service => service.CreateSale(It.IsAny<Sale>()))
            .Returns(SaleMapper.MapGet(expectedSale));

            // Act
            var result = _saleController.Post(SaleMapper.Map(expectedSale));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SaleDTOGet>(actionResult.Value);
            Assert.Equal(expectedSale.CustomerId, returnValue.CustomerId);
        }

        [Theory]
        [InlineData(1, null, "BOL456", "2025-02-11T11:24:15", 101, 1500.75, "Completed", "BN is null")]
        [InlineData(1, "BN123", null, "2025-02-11T11:24:15", 101, 1500.75, "Completed", "BOL is null")]
        [InlineData(1, "BN123", "BOL456", null, 101, 1500.75, "Completed", "Date is null")]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", null, 1500.75, "Completed", "CustomerID is null")]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", 101, null, "Completed", "Total is null")]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", 101, 1500.75, null, "Status is null")]
        [InlineData(1, null, null, null, null, null, null, "BN, BOL, Date, CustomerID, Total, Status are null")]
        public async Task PostSale_ReturnBadRequest_NullArgument_Sale(int id, string bn, string bol, string dateString, int? cID, double? total, string status, string expectedErrorMessage)
        {
            // Arrange
            var sale = new Sale
            {
                SaleId = id,
                BookingNumber = bn,
                BoLnumber = bol,
                SaleDate = dateString != null ? DateTime.Parse(dateString) : null,
                CustomerId = cID,
                TotalRevenue = (decimal?)total,
                Status = status
            };

            _mockSaleService
            .Setup(service => service.CreateSale(It.IsAny<Sale>()))
            .Throws(new ArgumentException(expectedErrorMessage));


            // Act
            var result = _saleController.Post(SaleMapper.Map(sale));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal(expectedErrorMessage, returnValue);
        }

        [Fact]
        public async Task PostSale_ReturnBadRequest_NullSale_Sale()
        {
            // Arrange
            var id = 1;
            _mockSaleService
                .Setup(service => service.CreateSale(It.IsAny<Sale>()))
                .Throws(new ArgumentException($"There is no customer with ID {id}"));

            // Act
            var result = _saleController.Post(new SaleDTO());

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal($"There is no customer with ID {id}", returnValue);
        }

        [Fact]
        public async Task PostSale_ReturnBadRequest_NoCustomerID_Sale()
        {
            // Arrange

            _mockSaleService
                .Setup(service => service.CreateSale(It.IsAny<Sale>()))
                .Throws(new ArgumentException("Couldn't create sale"));

            // Act
            var result = _saleController.Post(new SaleDTO());

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create sale", returnValue);
        }

        private static void AssertPropertyEqual<T>(T expected, T actual, T defaultValue)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, defaultValue))
                Assert.Equal(expected, actual);
            else
                Assert.Equal(defaultValue, actual);
        }

        [Theory]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", 101, 1500.75, "Completed")]
        [InlineData(1, null, "BOL456", "2025-02-11T11:24:15", 101, 1500.75, "Completed")]
        [InlineData(1, "BN123", null, "2025-02-11T11:24:15", 101, 1500.75, "Completed")]
        [InlineData(1, "BN123", "BOL456", null, 101, 1500.75, "Completed")]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", null, 1500.75, "Completed")]
        [InlineData(1, "BN123", "BOL456", "2025-02-11T11:24:15", 101, 1500.75, null)]
        [InlineData(1, null, null, null, null, null, null)]
        public async Task UpdateSale_ReturnOK_Sale(int id, string bn, string bol, string dateString, int? cID, double? total, string status)
        {
            // Arrange
            DateTime? date = dateString != null ? DateTime.Parse(dateString) : null;

            var oldSale = new Sale
            {
                SaleId = 1,
                BookingNumber = "OldBN",
                BoLnumber = "OldBOL",
                SaleDate = DateTime.Now.AddDays(-1),
                CustomerId = 99,
                TotalRevenue = 1000m,
                Status = "Pending"
            };

            var newSale = new Sale
            {
                SaleId = id,
                BookingNumber = bn ?? oldSale.BookingNumber,
                BoLnumber = bol ?? oldSale.BoLnumber,
                SaleDate = date ?? oldSale.SaleDate,
                CustomerId = cID ?? oldSale.CustomerId,
                TotalRevenue = (decimal?)total ?? oldSale.TotalRevenue,
                Status = status ?? oldSale.Status
            };

            _mockSaleService
                .Setup(r => r.UpdateSale(1, It.IsAny<Sale>()))
                .Returns(SaleMapper.MapGet(newSale));

            // Act
            var result = _saleController.Put(1, SaleMapper.Map(newSale));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SaleDTOGet>(actionResult.Value);

            Assert.Equal(newSale.SaleId, returnValue.SaleId);
            AssertPropertyEqual(newSale.BookingNumber, returnValue.BookingNumber, oldSale.BookingNumber);
            AssertPropertyEqual(newSale.BoLnumber, returnValue.BoLnumber, oldSale.BoLnumber);
            AssertPropertyEqual(newSale.SaleDate, returnValue.SaleDate, oldSale.SaleDate);
            AssertPropertyEqual(newSale.CustomerId, returnValue.CustomerId, oldSale.CustomerId);
            AssertPropertyEqual(newSale.Status, returnValue.Status, oldSale.Status);

        }
        [Fact]
        public async Task UpdateSale_ReturnBadRequest_NoSale_Sale()
        {
            // Arrange
            int id = 1;

            _mockSaleService
               .Setup(r => r.UpdateSale(id, It.IsAny<Sale>()))
               .Throws(new ArgumentException($"There is no sale with id {id}"));

            // Act
            var result = _saleController.Put(id, new SaleDTO());

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal($"There is no sale with id {id}", returnValue);
        }

        [Fact]
        public async Task UpdateSale_ReturnBadRequest_NoCustomerID_Sale()
        {
            // Arrange
            var newSale = new Sale
            {
                SaleId = 1,
                BookingNumber = "BN1",
                BoLnumber = "BOL1",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 100,
                TotalRevenue = 100,
                Status = "Open"
            };

            _mockSaleService
               .Setup(r => r.UpdateSale(1, It.IsAny<Sale>()))
               .Throws(new Exception($"There is no customer with id {newSale.SaleId}"));

            // Act
            var result = _saleController.Put(1, SaleMapper.Map(newSale));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal($"There is no customer with id {newSale.SaleId}", returnValue);
        }

        [Fact]
        public async Task DeleteSale_ReturnOK_Sale()
        {
            // Arrange
            var sale = new Sale
            {
                SaleId = 1,
                BookingNumber = "BN1",
                BoLnumber = "BOL1",
                SaleDate = new DateTime(2025, 1, 1, 0, 0, 0),
                CustomerId = 1,
                TotalRevenue = 100,
                Status = "Open"
            };

            _mockSaleService.Setup(service => service.DeleteSale(1))
                .Returns(SaleMapper.MapGet(sale));

            // Act
            var result = _saleController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SaleDTOGet>(actionResult.Value);
            Assert.Equal(sale.SaleId, returnValue.SaleId);

        }

        [Fact]
        public async Task DeleteSale_ReturnBadRequest_WrongID_Sale()
        {
            // Arrange
            _mockSaleService
                .Setup(service => service.DeleteSale(1))
                .Throws(new Exception("Sale not found!"));

            // Act
            var result = _saleController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Sale not found!", returnValue);
        }

        [Fact]
        public async Task DeleteSale_ReturnBadRequest_IdInInvoices_Sale()
        {
            // Arrange
            _mockSaleService
                .Setup(service => service.DeleteSale(1))
                .Throws(new Exception("Can't delete yet!"));

            // Act
            var result = _saleController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Can't delete yet!", returnValue);
        }
    }
}