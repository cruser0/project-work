using API.Models.DTO;
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
            try
            {
                var data = await _supplierInvoiceCostService.GetAllSupplierInvoiceCosts(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Supplier Invoice Cost not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
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

            try
            {
                var data = await _supplierInvoiceCostService.GetSupplierInvoiceCostById(id);
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // POST api/<SupplierInvoiceCostController>
        [Authorize(Roles = "Admin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInvoiceCostDTO supplierInvoiceCost)
        {

            try
            {
                var data = await _supplierInvoiceCostService.CreateSupplierInvoiceCost(SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<SupplierInvoiceCostController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceCostWrite,SupplierInvoiceCostAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierInvoiceCostDTO supplierInvoiceCost)
        {
            try
            {
                var data = await _supplierInvoiceCostService.UpdateSupplierInvoiceCost(id, SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<SupplierInvoiceCostController>/5
        [Authorize(Roles = "Admin,SupplierInvoiceCostAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _supplierInvoiceCostService.DeleteSupplierInvoiceCost(id);
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
