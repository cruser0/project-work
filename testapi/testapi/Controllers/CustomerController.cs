
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

    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly ICountryService _countryService;
        public CustomerController(ICustomerService customerService, ICountryService countryService)
        {
            _customerService = customerService;
            _countryService = countryService;
        }



        // GET: api/<CustomerController>

        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin,SaleWrite,SaleAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerFilter filter)
        {
            var data = await _customerService.GetAllCustomers(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CustomerDTOGet>());
        }
        // GET: api/<CustomerController>

        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin,SaleWrite,SaleAdmin")]
        [HttpGet("get-all-customer-name-country")]
        public async Task<IActionResult> GetCustomerNameCountry([FromQuery] string? filter)
        {
            List<string> data = await _customerService.GetAllCustomersNameCountry(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<string>());
        }



        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin,SaleWrite,SaleAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CustomerFilter filter)
        {
            var data = await _customerService.CountCustomers(filter);
            return Ok(data);
        }



        // GET api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _customerService.GetCustomerById(id);
            if (data == null)
                throw new NotFoundException("Customer not found!");
            return Ok(data);
        }




        // POST api/<CustomerController>
        [Authorize(Roles = "Admin,CustomerWrite,CustomerAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO customer)
        {

            customer.IsPost = true;
            var results = ValidatorEntity.Validate(customer);
            if (results.Count > 0)
                throw new ValidateException(results.First().ErrorMessage);

            var data = await _customerService.CreateCustomer(CustomerMapper.Map(customer, await _countryService.GetCountryByName(customer.Country!)));
            if (data == null)
                throw new NotFoundException("Data can't be null!");
            return Ok(data);
        }




        // PUT api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerWrite,CustomerAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO customer)
        {
            customer.IsPost = false;
            var results = ValidatorEntity.Validate(customer);
            if (results.Count > 0)
                throw new ValidateException(results.First().ErrorMessage);

            var data = await _customerService.UpdateCustomer(id, CustomerMapper.Map(customer, await _countryService.GetCountryByName(customer.Country)));
            if (data == null)
                throw new NotFoundException("Customer not found!");
            return Ok(data);
        }




        // DELETE api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerService.DeleteCustomer(id);
            if (data == null)
                throw new NotFoundException("Customer not found!");
            return Ok(data);
        }




        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _customerService.MassDeleteCustomer(id);
            return Ok(data);
        }




        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<CustomerDTOGet> newCustomers)
        {
            var data = await _customerService.MassUpdateCustomer(newCustomers);
            return Ok(data);
        }
    }
}
