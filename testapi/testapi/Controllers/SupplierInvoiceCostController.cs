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
    [Route("api/supplier-invoice-cost")]
    [ApiController]
    public class SupplierInvoiceCostController : ControllerBase
    {
        private readonly ISupplierInvoiceCostService _supplierInvoiceCostService;
        public SupplierInvoiceCostController(ISupplierInvoiceCostService supplierInvoiceCostService)
        {
            _supplierInvoiceCostService = supplierInvoiceCostService;
        }
        // GET: api/<SupplierInvoiceCostController>
        [Authorize(Roles = "Admin,SupplierInvoiceCostRead,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierInvoiceCostFilter filter)
        {
            var data = await _supplierInvoiceCostService.GetAllSupplierInvoiceCosts(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else throw new NotFoundException("Supplier Invoice Cost not found");
        }

        [Authorize(Roles = "Admin,SupplierInvoiceCostRead,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SupplierInvoiceCostFilter filter)
        {

            var data = await _supplierInvoiceCostService.CountSupplierInvoiceCosts(filter);
            return Ok(data);

        }

        // GET api/<SupplierInvoiceCostController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceCostRead,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var data = await _supplierInvoiceCostService.GetSupplierInvoiceCostById(id);
            if (data == null)
                throw new NotFoundException("Supplier Invoice Cost not found");
            return Ok(data);

        }

        // POST api/<SupplierInvoiceCostController>
        [Authorize(Roles = "Admin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInvoiceCostDTO supplierInvoiceCost)
        {



            var data = await _supplierInvoiceCostService.CreateSupplierInvoiceCost(SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
            if (data == null)
                throw new NotFoundException("Supplier Invoice Cost not found");
            return Ok(data);


        }

        // PUT api/<SupplierInvoiceCostController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierInvoiceCostDTO supplierInvoiceCost)
        {

            var data = await _supplierInvoiceCostService.UpdateSupplierInvoiceCost(id, SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
            if (data == null)
                throw new NotFoundException("Supplier Invoice Cost not found");
            return Ok(data);

        }

        // DELETE api/<SupplierInvoiceCostController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceCostAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _supplierInvoiceCostService.DeleteSupplierInvoiceCost(id);
            if (data == null)
                throw new NotFoundException("Supplier Invoice Cost not found");
            return Ok(data);
        }

        [Authorize(Roles = "Admin,SupplierInvoiceCostAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {

            var data = await _supplierInvoiceCostService.MassDeleteSupplierInvoiceCost(id);
            return Ok(data);

        }

        [Authorize(Roles = "Admin,SupplierInvoiceCostAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<SupplierInvoiceCostDTOGet> newSupplierInvoiceCosts)
        {
            var data = await _supplierInvoiceCostService.MassUpdateSupplierInvoiceCost(newSupplierInvoiceCosts);
            return Ok(data);
        }
    }
}
