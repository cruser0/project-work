using API.Models.DTO;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                var data = await _supplierService.GetAllSuppliers(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new NotFoundException("Supplier not found");

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

                var data = await _supplierService.GetSupplierById(id);
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);

        }

        // POST api/<SupplierController>
        [Authorize(Roles = "Admin,SupplierWrite,SupplierAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierDTO supplier)
        {

                var data = await _supplierService.CreateSupplier(SupplierMapper.Map(supplier));
                if (data == null)
                    throw new NotFoundException("Data can't be null!");
                return Ok(data);
        }

        // PUT api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierWrite,SupplierAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierDTO supplier)
        {

                var data = await _supplierService.UpdateSupplier(id, SupplierMapper.Map(supplier));
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);

        }

        // DELETE api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


                var data = await _supplierService.DeleteSupplier(id);
                if (data == null)
                    throw new NotFoundException("Supplier not found!");
                return Ok(data);

        }

        [Authorize(Roles = "Admin,SupplierAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {


                var data = await _supplierService.MassDeleteSupplier(id);
                return Ok(data);

        }

        [Authorize(Roles = "Admin,SupplierAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<SupplierDTOGet> newSuppliers)
        {


                var data = await _supplierService.MassUpdateSupplier(newSuppliers);
                return Ok(data);

        }
    }
}
