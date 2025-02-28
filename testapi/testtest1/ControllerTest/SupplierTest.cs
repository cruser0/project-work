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
    public class SupplierTest
    {
        private readonly SupplierController _supplierController;
        private readonly Mock<ISupplierService> _mockService;
        public SupplierTest()
        {
            _mockService = new Mock<ISupplierService>();
            _supplierController = new SupplierController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnOk_Supplier()
        {
            //Arrange
            var suppliers = new List<SupplierDTOGet> { new SupplierDTOGet { SupplierId = 1, SupplierName = "Apple", Country = "Italy" } };
            var filter = new SupplierFilter { SupplierName = "", SupplierCountry = "" };

            _mockService.Setup(service => service.GetAllSuppliers(filter)).Returns(suppliers);

            //Act
            var result = _supplierController.Get(filter);

            //Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<SupplierDTOGet>>(actionResult.Value);
            Assert.Equal(suppliers.Count, returnValue.Count);
        }

        [Fact]
        public async Task Get_ReturnBadRequest_Suppllier()
        {
            //Arrange 
            var suppliers = new List<Supplier>();
            var filter = new SupplierFilter { SupplierName = "", SupplierCountry = "" };
            _mockService.Setup(service => service.GetAllSuppliers(filter)).Throws(new Exception("Suppliers not found!"));

            //Act
            var result = _supplierController.Get(filter);

            //Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Suppliers not found!", actionResult.Value);
        }

        [Fact]
        public async Task Post_ReturnOk_Supplier()
        {
            //Arrange
            var supplier = new Supplier { SupplierId = 1, SupplierName = "Apple", Country = "Italy" };
            _mockService.Setup(service => service.CreateSupplier(It.IsAny<Supplier>())).Returns(SupplierMapper.MapGet(supplier));

            //Act
            var result = _supplierController.Post(SupplierMapper.Map(supplier));

            //Assert

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierDTOGet>(actionResult.Value);
            Assert.Equal(supplier.SupplierId, returnValue.SupplierId);

        }

        [Fact]
        public async Task Post_ReturnBadRequest_Supplier()
        {
            _mockService.CallBase = true;

            // Arrange
            _mockService
            .Setup(service => service.CreateSupplier(null))
            .Throws(new Exception("Couldn't create supplier"));

            // Act
            var result = _supplierController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create supplier", returnValue);
        }
        [Theory]
        [InlineData(1, "", "Italy")]
        [InlineData(1, "Apple", "")]
        [InlineData(1, "", "")]
        public async Task Post_ReturnBadRequest_Supplier_null_data(int id, string name, string country)
        {

            var supplier = new Supplier { SupplierId = id, SupplierName = name, Country = country };
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(country))
            {
                _mockService
                .Setup(service => service.CreateSupplier(supplier))
                .Throws(new Exception("Data can't be null!"));
            }
            // Arrange

            // Act
            var result = _supplierController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Data can't be null!", returnValue);
        }
        [Fact]
        public async Task GetByID_ReturnOK_Supplier()
        {
            // Arrange
            var suppliers = new Supplier { SupplierId = 1, SupplierName = "Pier Paolo Pittavino", Country = "Italy" };
            _mockService.Setup(service => service.GetSupplierById(1)).Returns(SupplierMapper.MapGet(suppliers));

            // Act
            var result = _supplierController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.SupplierId, suppliers.SupplierId);
        }

        [Fact]
        public async Task GetByID_ReturnBadResult_Supplier()
        {
            // Arrange
            _mockService.Setup(service => service.GetSupplierById(1)).Returns((SupplierDTOGet)null);

            // Act
            var result = _supplierController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Supplier not found!", returnValue);
        }

        [Fact]
        public async Task Delete_ReturnOK_Supplier()
        {
            //Arrange
            Supplier supplier = new() { SupplierId = 1, SupplierName = "Apple", Country = "Italy" };
            _mockService
                .Setup(service => service.DeleteSupplier(1))
                .Returns(SupplierMapper.MapGet(supplier));


            // Act
            var result = _supplierController.Delete(1);


            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierDTOGet>(actionResult.Value);
            Assert.NotNull(returnValue);
            Assert.Equal(supplier.SupplierId, returnValue.SupplierId);
            Assert.IsType<SupplierDTOGet>(returnValue);
        }

        [Fact]
        public async Task Delete_ReturnBadRequest_Supplier()
        {
            //Arrange
            Supplier supplier = new() { SupplierId = 1, SupplierName = "Apple", Country = "Italy" };
            _mockService
                .Setup(service => service.DeleteSupplier(2))
                .Throws(new Exception("Supplier not found!"));


            //Act
            var result = _supplierController.Delete(2);


            //Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Supplier not found!", returnValue);
        }
        [Theory]
        [InlineData(1, "Apple", "Italy")]
        [InlineData(1, "", "Italy")]
        [InlineData(1, "Apple", "")]
        [InlineData(1, "", "")]
        public async Task Put_ReturnOk_Supplier(int id, string name, string country)
        {
            //Arrange
            var originalSupplier = new Supplier { SupplierId = id, SupplierName = "Xiaomi", Country = "Japan" };
            var updatedSupplier = new Supplier { SupplierId = id, SupplierName = name, Country = country };

            if (string.IsNullOrEmpty(name))
                updatedSupplier.SupplierName = originalSupplier.SupplierName;

            if (string.IsNullOrEmpty(country))
                updatedSupplier.Country = originalSupplier.Country;

            _mockService.Setup(service => service.UpdateSupplier(id, It.IsAny<Supplier>()))
                        .Returns(SupplierMapper.MapGet(updatedSupplier));

            // Act
            var result = _supplierController.Put(id, SupplierMapper.Map(updatedSupplier));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierDTOGet>(actionResult.Value);
            if (string.IsNullOrEmpty(name))
                Assert.Equal(originalSupplier.SupplierName, returnValue.SupplierName);
            else
                Assert.Equal(updatedSupplier.SupplierName, returnValue.SupplierName);
            Assert.Equal(id, returnValue.SupplierId);
            if (string.IsNullOrEmpty(country))
                Assert.Equal(originalSupplier.Country, returnValue.Country);
            else
                Assert.Equal(updatedSupplier.Country, returnValue.Country);
        }
        [Fact]
        public async Task Put_ReutrnBadRequest_Supplier()
        {
            //Arrange
            var supplier = new Supplier { SupplierId = 1, SupplierName = "Xiaomi", Country = "Japan" };



            _mockService.Setup(service => service.UpdateSupplier(2, It.IsAny<Supplier>()))
                        .Throws(new Exception("Supplier not found!"));

            // Act
            var result = _supplierController.Put(2, SupplierMapper.Map(supplier));

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Supplier not found!", returnValue);

        }


    }
}
