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
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ICountryService _countryService;
        public SupplierController(ISupplierService supplierService, ICountryService countryService)
        {
            _supplierService = supplierService;
            _countryService = countryService;
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
            else return Ok(new List<SupplierDTOGet>());

        }
        // GET: api/<SupplierController>
        [Authorize(Roles = "Admin,SupplierRead,SupplierWrite,SupplierAdmin")]
        [HttpGet("get-all-supplier-name-country")]
        public async Task<IActionResult> GetNameCountry([FromQuery] string? filter)
        {

            List<string> data = await _supplierService.GetAllSuppliersNameCountry(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<string>());

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
            supplier.IsPost = true;
            var result = ValidatorEntity.Validate(supplier);
            if (result.Any())
            {
                throw new ValidateException(result.First().ToString());
            }
            var data = await _supplierService.CreateSupplier(SupplierMapper.Map(supplier, await _countryService.GetCountryByName(supplier.Country!)));
            if (data == null)
                throw new NotFoundException("Data can't be null!");
            return Ok(data);
        }

        // PUT api/<SupplierController>/5
        [Authorize(Roles = "Admin,SupplierWrite,SupplierAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SupplierDTO supplier)
        {
            supplier.IsPost = false;
            var result = ValidatorEntity.Validate(supplier);
            if (result.Any())
            {
                throw new ValidateException(result.First().ToString());
            }
            var data = await _supplierService.UpdateSupplier(id, SupplierMapper.Map(supplier, await _countryService.GetCountryByName(supplier.Country!)));
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
