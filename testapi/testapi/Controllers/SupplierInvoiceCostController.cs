using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
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
        [HttpGet]
        public IActionResult Get([FromQuery] SupplierInvoiceCostFilter filter)
        {
            try
            {
                var data = _supplierInvoiceCostService.GetAllSupplierInvoiceCosts(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Supplier Invoice Cost not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<SupplierInvoiceCostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                var data = _supplierInvoiceCostService.GetSupplierInvoiceCostById(id);
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // POST api/<SupplierInvoiceCostController>
        [HttpPost]
        public IActionResult Post(SupplierInvoiceCostDTO supplierInvoiceCost)
        {

            try
            {
                var data = _supplierInvoiceCostService.CreateSupplierInvoiceCost(SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<SupplierInvoiceCostController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierInvoiceCostDTO supplierInvoiceCost)
        {
            try
            {
                var data = _supplierInvoiceCostService.UpdateSupplierInvoiceCost(id, SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<SupplierInvoiceCostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _supplierInvoiceCostService.DeleteSupplierInvoiceCost(id);
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
