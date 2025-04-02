using API.Models.Exceptions;
using API.Models.Mapper;
using API.Models.Services;
using Entity_Validator;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
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
        private readonly IStatusService _statusService;
        public SupplierInvoiceController(ISupplierInvoiceService supplierInvoiceService, IStatusService statusService, ISalesService saleServ)
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
            supplierInvoice.IsPost = true;
            var result = ValidatorEntity.Validate(supplierInvoice);
            if (result.Any())
            {
                throw new ValidateException(result[0].ToString());
            }
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
            supplierInvoice.IsPost = false;
            var result = ValidatorEntity.Validate(supplierInvoice);
            if (result.Any())
            {
                throw new ValidateException(result[0].ToString());
            }
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

        [HttpGet("supplier-invoice-summary/{SupplierID}")]
        public async Task<ActionResult<SupplierInvoiceSummary>> GetSupplierInvoiceSummary(int SupplierID)
        {
            var data = await _supplierInvoiceService.GetSupplierInvoiceSummary(SupplierID);
            return Ok(data);
        }
    }
}
