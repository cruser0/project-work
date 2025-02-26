using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
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
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>

        [Authorize(Roles = "Admin,CustomerRead")]
        [HttpGet]
        public IActionResult Get([FromQuery] CustomerFilter filter)
        {
            try
            {
                var data = _customerService.GetAllCustomers(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Customer not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,CustomerRead")]
        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] CustomerFilter filter)
        {
            var data = _customerService.CountCustomers(filter);
            return Ok(data);
        }

        // GET api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerRead")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                var data = _customerService.GetCustomerById(id);
                if (data == null)
                    throw new Exception("Customer not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }


        // POST api/<CustomerController>
        [Authorize(Roles = "Admin,CustomerWrite")]
        [HttpPost]
        public IActionResult Post(CustomerDTO customer)
        {
            try
            {
                var data = _customerService.CreateCustomer(CustomerMapper.Map(customer));
                if (data == null)
                    throw new Exception("Data can't be null!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerWrite")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDTO customer)
        {
            try
            {
                var data = _customerService.UpdateCustomer(id, CustomerMapper.Map(customer));
                if (data == null)
                    throw new Exception("Customer not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // DELETE api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerDelete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _customerService.DeleteCustomer(id);
                if (data == null)
                    throw new Exception("Customer not found!");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}
