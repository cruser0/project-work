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
        [Authorize(Roles = "Admin,SupplierRead,SupplierWrite,SupplierAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierFilter filter)
        {
            try
            {
                var data = await _supplierService.GetAllSuppliers(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new NotFoundException("Supplier not found");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        [Authorize(Roles = "Admin,SupplierRead,SupplierWrite,SupplierAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] SupplierFilter filter)
        {
            var data = await _supplierService.CountSuppliers(filter);
            return Ok(data);
        }

        // GET api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierRead,SupplierWrite,SupplierAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _supplierService.GetSupplierById(id);
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // POST api/<SupplierController>
        [Authorize(Roles = "Admin,SupplierWrite,SupplierAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierDTO supplier)
        {
            try
            {
                var data = await _supplierService.CreateSupplier(SupplierMapper.Map(supplier));
                if (data == null)
                    throw new NotFoundException("Data can't be null!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // PUT api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierWrite,SupplierAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierDTO supplier)
        {
            try
            {
                var data = await _supplierService.UpdateSupplier(id, SupplierMapper.Map(supplier));
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // DELETE api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _supplierService.DeleteSupplier(id);
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
    }
}
