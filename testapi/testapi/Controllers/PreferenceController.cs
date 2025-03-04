using API.Models.Entities;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/preference/")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        UserService _userService;
        public PreferenceController(UserService us)
        {
            _userService = us;
        }
        // GET: api/<ValuesController1>
        [HttpGet("customerDGV/{id}")]
        public IActionResult GetCustomerDGV(int id)
        {
            try
            {
                var result = _userService.GetCustomerDGV(id);
                return Ok(result);
                
            }catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("customerDGV")]
        public IActionResult Post([FromBody] CustomerDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateCustomerDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpGet("customerInvoiceDGV/{id}")]
        public IActionResult GetCustomerInvoiceDGV(int id)
        {
            try
            {
                var result = _userService.GetCustomerInvoiceDGV(id);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("customerInvoiceDGV")]
        public IActionResult Post([FromBody] CustomerInvoiceDGV value)
        {
            try
            {
                var result = _userService.CreateUpdateCustomerInvoiceDGV(value);
                return Ok(result);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
