using Microsoft.AspNetCore.Mvc;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
    [Route("api/supplier-invoice-cost")]
    [ApiController]
    public class SupplierInvoiceCostController : ControllerBase
    {
        private readonly ISupplierInvoiceCostREPO _supplierInvoiceCostREPO;
        public SupplierInvoiceCostController(ISupplierInvoiceCostREPO supplierInvoiceCostREPO)
        {
            _supplierInvoiceCostREPO = supplierInvoiceCostREPO;
        }
        // GET: api/<SupplierInvoiceCostController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _supplierInvoiceCostREPO.GetAllSupplierInvoiceCosts();
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
                var data = _supplierInvoiceCostREPO.GetSupplierInvoiceCostById(id);
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
                var data = _supplierInvoiceCostREPO.CreateSupplierInvoiceCost(SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
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
                var data = _supplierInvoiceCostREPO.UpdateSupplierInvoiceCost(id, SupplierInvoiceCostMapper.Map(supplierInvoiceCost));
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
                var data = _supplierInvoiceCostREPO.DeleteSupplierInvoiceCost(id);
                if (data == null)
                    throw new Exception("Supplier Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
