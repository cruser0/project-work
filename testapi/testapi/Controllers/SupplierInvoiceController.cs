using API.Models.DTO;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/supplier-invoice")]
    [ApiController]
    public class SupplierInvoiceController : ControllerBase
    {
        private readonly ISupplierInvoiceService _supplierInvoiceService;
        private readonly ISalesService _saleService;
        private readonly StatusService _statusService;
        public SupplierInvoiceController(ISupplierInvoiceService supplierInvoiceService, StatusService statusService, SaleServices saleServ)
        {
            _supplierInvoiceService = supplierInvoiceService;
            _statusService = statusService;
            _saleService = saleServ;
        }
        // GET: api/<SupplierInvoiceController>
        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierInvoiceSupplierFilter filter)
        {
            var data = await _supplierInvoiceService.GetAllSupplierInvoices(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<SupplierInvoiceSupplierDTO>());

        }

        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SupplierInvoiceSupplierFilter filter)
        {

            var data = await _supplierInvoiceService.CountSupplierinvoices(filter);
            return Ok(data);

        }

        // GET api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceRead,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _supplierInvoiceService.GetSupplierInvoiceById(id);
            if (data == null)
                throw new NotFoundException("Supplier Invoice not found!");
            return Ok(data);

        }

        // POST api/<SupplierInvoiceController>
        [Authorize(Roles = "Admin,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInvoiceDTO supplierInvoice)
        {
            var data = await _supplierInvoiceService.CreateSupplierInvoice(SupplierInvoiceMapper.Map(supplierInvoice,
                                                                                                    await _statusService.GetStatusByName(supplierInvoice.Status!),
                                                                                                    await _saleService.GetOnlySaleById((int)supplierInvoice.SaleId!)));
            if (data == null)
                throw new NotFoundException("Couldn't create supplier invoice");
            return Ok(data);


        }

        // PUT api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceWrite,SupplierInvoiceAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierInvoiceDTO supplierInvoice)
        {
            var data = await _supplierInvoiceService.UpdateSupplierInvoice(id, SupplierInvoiceMapper.Map(supplierInvoice,
                                                                                                    await _statusService.GetStatusByName(supplierInvoice.Status!),
                                                                                                    await _saleService.GetOnlySaleById((int)supplierInvoice.SaleId!)));
            if (data == null)
                throw new NotFoundException("Couldn't update supplier invoice");
            return Ok(data);


        }

        // DELETE api/<SupplierInvoiceController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var data = await _supplierInvoiceService.DeleteSupplierInvoice(id);
            if (data == null)
                throw new NotFoundException("Couldn't delete supplier invoice");
            return Ok(data);

        }
        [Authorize(Roles = "Admin,SupplierInvoiceAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {

            var data = await _supplierInvoiceService.MassDeleteSupplierInvoice(id);
            return Ok(data);

        }

        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<SupplierInvoiceDTOGet> newSupplierInvoices)
        {

            var data = await _supplierInvoiceService.MassUpdateSupplierInvoice(newSupplierInvoices);
            return Ok(data);


        }
    }
}
