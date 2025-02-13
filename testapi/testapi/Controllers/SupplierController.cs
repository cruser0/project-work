using API.Models.DTO;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _supplierService.GetAllSuppliers();
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
                var data = _supplierService.GetSupplierById(id);
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
                var data = _supplierService.CreateSupplier(SupplierMapper.Map(supplier));
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
                var data = _supplierService.UpdateSupplier(id, SupplierMapper.Map(supplier));
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
                var data = _supplierService.DeleteSupplier(id);
                if (data == null)
                    throw new Exception("Supplier not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }
    }
}
