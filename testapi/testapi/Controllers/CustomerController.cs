using API.Models.DTO;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;

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
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _customerService.GetAllCustomers();
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Customer not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<CustomerController>/5
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
