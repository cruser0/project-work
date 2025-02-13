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
    public class SupplierInvoiceTest
    {
        private readonly SupplierInvoiceController _supplierInvoiceController;
        private readonly Mock<ISupplierInvoiceService> _mockSupplierInvoiceService;

        public SupplierInvoiceTest()
        {
            _mockSupplierInvoiceService = new Mock<ISupplierInvoiceService>();
            _supplierInvoiceController = new SupplierInvoiceController(_mockSupplierInvoiceService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_SupplierInvoice()
        {
            // Arrange
            var supplierInvoices = new List<SupplierInvoiceDTOGet>
            {
                new SupplierInvoiceDTOGet
                {
                    InvoiceId = 1,
                    SaleId = 1,
                    SupplierId = 1,
                    InvoiceAmount = 100,
                    InvoiceDate = new DateTime(2025,1,1,0,0,0),
                    Status = "Open"
                }
            };

            _mockSupplierInvoiceService.Setup(service => service.GetAllSupplierInvoices()).Returns(supplierInvoices);
            // Act
            // Assert
        }

        [Fact]
        public void Get_ReturnBadRequest_WhenNoSupplierInvoices()
        {
            // Arrange
            var invoices = new List<SupplierInvoiceDTOGet>(); // Lista vuota
            _mockSupplierInvoiceService.Setup(service => service.GetAllSupplierInvoices()).Returns(invoices);

            // Act
            var result = _supplierInvoiceController.Get();

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Supplier Invoice not found", returnValue);
        }

        [Fact]
        public async Task GetByID_ReturnsOkResult_SupplierInvoice()
        {
            // Arrange
            var invoice = new SupplierInvoiceDTOGet
            {
                InvoiceId = 1,
                SaleId = 1,
                SupplierId = 1,
                InvoiceAmount = 100,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Open"
            };
            _mockSupplierInvoiceService.Setup(service => service.GetSupplierInvoiceById(1)).Returns(invoice);

            // Act
            var result = _supplierInvoiceController.Get(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(returnValue.SaleId, invoice.SaleId);
        }

        [Fact]
        public async Task GetByID_ReturnsBadResult_SupplierInvoice()
        {
            // Arrange
            _mockSupplierInvoiceService.Setup(service => service.GetSupplierInvoiceById(1)).Throws(new ArgumentException("Supplier Invoice not found!"));

            // Act
            var result = _supplierInvoiceController.Get(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Supplier Invoice not found!", returnValue);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_SupplierInvoice()
        {
            // Arrange
            var expectedSupplierInvoice = new SupplierInvoice
            {
                InvoiceId = 1,
                SaleId = 1,
                SupplierId = 1,
                InvoiceAmount = 100,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "Open"
            };
            _mockSupplierInvoiceService
                .Setup(service => service.CreateSupplierInvoice(It.IsAny<SupplierInvoice>()))
                .Returns(SupplierInvoiceMapper.MapGet(expectedSupplierInvoice));

            // Act
            var result = _supplierInvoiceController.Post(SupplierInvoiceMapper.Map(expectedSupplierInvoice));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(expectedSupplierInvoice.InvoiceId, returnValue.InvoiceId);
        }

        [Fact]
        public async Task Post_ReturnsBadResult_SupplierInvoice_PostNull()
        {
            // Arrange
            _mockSupplierInvoiceService
                .Setup(s => s.CreateSupplierInvoice(null))
                .Returns((SupplierInvoiceDTOGet)null);

            // Act
            var result = _supplierInvoiceController.Post(null);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create supplier invoice", returnValue);
        }

        [Fact]
        public async Task Post_ReturnsBadResult_SupplierInvoice_ForeignKey()
        {
            // Arrange
            _mockSupplierInvoiceService
                .Setup(s => s.CreateSupplierInvoice(It.IsAny<SupplierInvoice>()))
                .Returns((SupplierInvoiceDTOGet)null);

            // Act
            var result = _supplierInvoiceController.Post(new SupplierInvoiceDTO());

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't create supplier invoice", returnValue);
        }

        [Fact]
        public async Task Put_ReturnsOkResult_SupplierInvoice()
        {
            // Arrange
            SupplierInvoice supplierInvoice = new SupplierInvoice
            {
                InvoiceId = 1,
                SaleId = 1,
                SupplierId = 1,
                InvoiceAmount = 100.50m,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "open"
            };

            _mockSupplierInvoiceService
                .Setup(s => s.UpdateSupplierInvoice(1, It.IsAny<SupplierInvoice>()))
                .Returns(SupplierInvoiceMapper.MapGet(supplierInvoice));

            // Act
            var result = _supplierInvoiceController.Put(1, SupplierInvoiceMapper.Map(supplierInvoice));

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(1, returnValue.InvoiceId);

        }

        [Fact]
        public async Task Put_ReturnsBadResult_SupplierInvoice()
        {
            // Arrange
            _mockSupplierInvoiceService
                .Setup(s => s.UpdateSupplierInvoice(1, It.IsAny<SupplierInvoice>()))
                .Returns((SupplierInvoiceDTOGet)null);

            // Act
            var result = _supplierInvoiceController.Put(1, new SupplierInvoiceDTO());

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);
            Assert.Equal("Couldn't update supplier invoice", returnValue);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_SupplierInvoice()
        {
            // Arrange
            SupplierInvoice supplierInvoice = new SupplierInvoice
            {
                InvoiceId = 1,
                SaleId = 1,
                SupplierId = 1,
                InvoiceAmount = 100.50m,
                InvoiceDate = new DateTime(2025, 1, 1, 0, 0, 0),
                Status = "open"
            };
            _mockSupplierInvoiceService
                .Setup(s => s.DeleteSupplierInvoice(1))
                .Returns(SupplierInvoiceMapper.MapGet(supplierInvoice));

            // Act
            var result = _supplierInvoiceController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SupplierInvoiceDTOGet>(actionResult.Value);
            Assert.Equal(supplierInvoice.InvoiceId, returnValue.InvoiceId);

        }

        [Fact]
        public async Task Delete_ReturnsBadResult_SupplierInvoice_WrongID()
        {
            // Arrange
            _mockSupplierInvoiceService
                .Setup(s => s.DeleteSupplierInvoice(It.IsAny<int>()))
                .Returns((SupplierInvoiceDTOGet)null);

            // Act
            var result = _supplierInvoiceController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Couldn't delete supplier invoice", returnValue);
        }

        [Fact]
        public async Task Delete_ReturnsBadResult_SupplierInvoice_Cascade()
        {
            // Arrange
            _mockSupplierInvoiceService
                .Setup(s => s.DeleteSupplierInvoice(It.IsAny<int>()))
                .Throws(new ArgumentException("Can't delete"));

            // Act
            var result = _supplierInvoiceController.Delete(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(actionResult.Value);

            Assert.Equal("Can't delete", returnValue);
        }
    }
}
