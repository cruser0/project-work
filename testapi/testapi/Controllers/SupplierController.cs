using Microsoft.AspNetCore.Mvc;
using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;
using testapi.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testapi.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierREPO _supplierREPO;
        public SupplierController(ISupplierREPO supplierREPO)
        {
            _supplierREPO = supplierREPO;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _supplierREPO.GetAllSuppliers();
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Supplier not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _supplierREPO.GetSupplierById(id);
                if (data == null)
                    throw new Exception("Supplier not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post(SupplierDTO supplier)
        {
            try
            {
                var data = _supplierREPO.CreateSupplier(SupplierMapper.Map(supplier));
                if (data == null)
                    throw new Exception("Data can't be null!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SupplierDTO supplier)
        {
            try
            {
                var data = _supplierREPO.UpdateSupplier(id, SupplierMapper.Map(supplier));
                if (data == null)
                    throw new Exception("Supplier not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _supplierREPO.DeleteSupplier(id);
                if (data == null)
                    throw new Exception("Supplier not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }
    }
}
