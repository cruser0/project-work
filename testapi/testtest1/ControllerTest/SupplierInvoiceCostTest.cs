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
    public class SupplierInvoiceCostCostTest
    {
        private readonly SupplierInvoiceCostController _supplierInvoceCostController;
        private readonly Mock<ISupplierInvoiceCostService> _mockSupplierInvoiceCostService;

        public SupplierInvoiceCostCostTest()
        {
            _mockSupplierInvoiceCostService = new Mock<ISupplierInvoiceCostService>();
            _supplierInvoceCostController = new SupplierInvoiceCostController(_mockSupplierInvoiceCostService.Object);
        }
        [Fact]
        public async Task Get_ReturnOkResult_SupplierInvoiceCost()
        {
            // Arrange
            var supplierInvoiceCost = new List<SupplierInvoiceCostDTOGet>{
            new SupplierInvoiceCostDTOGet { SupplierInvoiceCostsId=1,SupplierInvoiceId=1,Quantity=2,Cost=100.0m }
            };
            var filter = new SupplierInvoiceCostFilter();
            _mockSupplierInvoiceCostService.Setup(service => service.GetAllSupplierInvoiceCosts(filter)).Returns(supplierInvoiceCost);

            // Act
            var result = _supplierInvoceCostController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<SupplierInvoiceCostDTOGet>>(actionResult.Value);
            Assert.Equal(supplierInvoiceCost.Count, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnBadResult_SupplierInvoiceCost()
        {
            // Arrange
            var supplierInvoiceCost = new List<SupplierInvoiceCostDTOGet>
            {
            };
            var filter = new SupplierInvoiceCostFilter();
            _mockSupplierInvoiceCostService.Setup(service => service.GetAllSupplierInvoiceCosts(filter)).Returns(supplierInvoiceCost);

            // Act
            var result = _supplierInvoceCostController.Get(filter);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Supplier Invoice Cost not found", returnValue);
        }

        [Fact]
        public async Task GetByID_ReturnOK_SupplierInvoiceCost()
        {
            // Arrange
            var customerInvoice = new SupplierInvoiceCostDTOGet { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 1, Quantity = 2, Cost = 100.0m };
            _mockSupplierInvoiceCostService.Setup(service => service.GetSupplierInvoiceCostById(1)).Returns(customerInvoice);

            // Act
            var result = _supplierInvoceCostController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceCostDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.SupplierInvoiceCostsId, customerInvoice.SupplierInvoiceCostsId);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_SupplierInvoiceCost()
        {
            // Arrange
            _mockSupplierInvoiceCostService.Setup(service => service.GetSupplierInvoiceCostById(1)).Throws(new Exception("Supplier Invoices cost not found"));

            // Act
            var result = _supplierInvoceCostController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Supplier Invoices cost not found", returnValue);
        }


        [Fact]
        public async Task PostSupplierInvoiceCost_ReturnOK_SupplierInvoiceCost()
        {
            // Arrange
            var customerInvoiceDto = new SupplierInvoiceCostDTO { SupplierInvoiceId = 1, Quantity = 2, Cost = 100.0m };
            var expectedSupplierInvoiceCost = new SupplierInvoiceCost { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 1, Quantity = 2, Cost = 100.0m };

            _mockSupplierInvoiceCostService
            .Setup(service => service.CreateSupplierInvoiceCost(It.IsAny<SupplierInvoiceCost>()))
            .Returns(SupplierInvoiceCostMapper.MapGet(expectedSupplierInvoiceCost));

            // Act
            var result = _supplierInvoceCostController.Post(customerInvoiceDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceCostDTOGet>(actionResult.Value);

            Assert.Equal(expectedSupplierInvoiceCost.SupplierInvoiceCostsId, returnValue.SupplierInvoiceCostsId);
        }

        [Fact]
        public async Task PostSupplierInvoiceCost_ReturnBadRequest_SupplierInvoiceCost_null()
        {

            // Arrange
            _mockSupplierInvoiceCostService
            .Setup(service => service.CreateSupplierInvoiceCost(null))
            .Throws(new Exception("Couldn't create Supplier Invoice Cost"));

            // Act
            var result = _supplierInvoceCostController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create Supplier Invoice Cost", returnValue);
        }

        [Fact]
        public async Task PostSupplierInvoiceCost_ReturnBadRequest_SupplierInvoiceCost_SupplierInvoiceId_null()
        {


            // Arrange
            var customerInvoice = new SupplierInvoiceCost { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 210, Quantity = 2, Cost = 100.0m };
            _mockSupplierInvoiceCostService
            .Setup(service => service.CreateSupplierInvoiceCost(It.IsAny<SupplierInvoiceCost>()))
            .Throws(new Exception("Supplier Invoice ID doesn't exist!"));

            // Act
            var result = _supplierInvoceCostController.Post(SupplierInvoiceCostMapper.Map(customerInvoice));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Supplier Invoice ID doesn't exist!", returnValue);
        }


        [Fact]
        public async Task DeleteSupplierInvoiceCost_ReturnOK_SupplierInvoiceCost()
        {
            //Arrange
            SupplierInvoiceCost customer = new() { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 1, Quantity = 2, Cost = 100.0m };
            _mockSupplierInvoiceCostService
                .Setup(service => service.DeleteSupplierInvoiceCost(1))
                .Returns(SupplierInvoiceCostMapper.MapGet(customer));


            // Act
            var result = _supplierInvoceCostController.Delete(1);


            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceCostDTOGet>(actionResult.Value);
            Assert.NotNull(returnValue);
            Assert.Equal(customer.SupplierInvoiceCostsId, returnValue.SupplierInvoiceCostsId);
        }

        [Fact]
        public async Task DeleteSupplierInvoiceCost_ReturnBadRequest_SupplierInvoiceCost()
        {
            //Arrange
            SupplierInvoiceCost customer = new() { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 210, Quantity = 2, Cost = 100.0m };
            _mockSupplierInvoiceCostService
                .Setup(service => service.DeleteSupplierInvoiceCost(2))
                .Throws(new Exception("Customer Invoice Cost not found!"));


            //Act
            var result = _supplierInvoceCostController.Delete(2);


            //Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Customer Invoice Cost not found!", returnValue);
        }



        [Theory]
        [InlineData(1, 1, 2, 100.0)]
        [InlineData(1, null, 2, 100.0)]
        [InlineData(1, 1, null, 100.0)]
        [InlineData(1, 1, 2, null)]
        [InlineData(1, null, null, null)]
        public async Task Put_ReturnOk_SupplierInvoiceCost(int supplierInvoiceCostsId, int? supplierInvoiceId, int? quantity, double? cost)
        {
            // Arrange

            decimal? invoiceAmountDecimal = (decimal?)cost;
            var originalSupplierInvoiceCost = new SupplierInvoiceCost { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 210, Quantity = 232, Cost = 1020.0m };
            var updatedSupplierInvoiceCost = new SupplierInvoiceCost
            {
                SupplierInvoiceCostsId = supplierInvoiceCostsId,
                SupplierInvoiceId = supplierInvoiceId ?? originalSupplierInvoiceCost.SupplierInvoiceCostsId,
                Quantity = quantity ?? originalSupplierInvoiceCost.Quantity,
                Cost = invoiceAmountDecimal ?? originalSupplierInvoiceCost.Cost,
            };

            _mockSupplierInvoiceCostService.Setup(service => service.UpdateSupplierInvoiceCost(supplierInvoiceCostsId, It.IsAny<SupplierInvoiceCost>()))
                .Returns(SupplierInvoiceCostMapper.MapGet(updatedSupplierInvoiceCost));

            // Act
            var result = _supplierInvoceCostController.Put(supplierInvoiceCostsId, SupplierInvoiceCostMapper.Map(updatedSupplierInvoiceCost));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceCostDTOGet>(actionResult.Value);
            Assert.Equal(supplierInvoiceCostsId, returnValue.SupplierInvoiceCostsId);
            Assert.Equal(updatedSupplierInvoiceCost.Cost, returnValue.Cost);
            Assert.Equal(updatedSupplierInvoiceCost.Quantity, returnValue.Quantity);
            Assert.Equal(updatedSupplierInvoiceCost.SupplierInvoiceCostsId, returnValue.SupplierInvoiceCostsId);
        }

        [Fact]
        public async Task Put_ReutrnBadRequest_SupplierInvoiceCost()
        {
            //Arrange
            var supplier = new SupplierInvoiceCost { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 210, Quantity = 2, Cost = 100.0m };



            _mockSupplierInvoiceCostService.Setup(service => service.UpdateSupplierInvoiceCost(2, It.IsAny<SupplierInvoiceCost>()))
                        .Throws(new Exception("Supplier Invoice cost not found!"));

            // Act
            var result = _supplierInvoceCostController.Put(2, SupplierInvoiceCostMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Supplier Invoice cost not found!", returnValue);

        }

        [Fact]
        public async Task Put_ReutrnBadRequest_SupplierInvoiceCost_Wrong_SupplierInvoiceId()
        {
            //Arrange
            var supplier = new SupplierInvoiceCost { SupplierInvoiceCostsId = 1, SupplierInvoiceId = 210, Quantity = 2, Cost = 100.0m };



            _mockSupplierInvoiceCostService.Setup(service => service.UpdateSupplierInvoiceCost(1, It.IsAny<SupplierInvoiceCost>()))
                        .Throws(new Exception("SupplierInvoiceId was not found!"));

            // Act
            var result = _supplierInvoceCostController.Put(1, SupplierInvoiceCostMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("SupplierInvoiceId was not found!", returnValue);

        }
    }
}
