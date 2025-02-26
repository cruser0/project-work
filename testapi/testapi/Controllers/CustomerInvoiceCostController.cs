using API.Models.DTO;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/customer-invoice-cost")]
    [ApiController]
    public class CustomerInvoiceCostController : ControllerBase
    {
        private readonly ICustomerInvoiceCostService _customerInvoiceCostService;
        public CustomerInvoiceCostController(ICustomerInvoiceCostService customerInvoiceCostService)
        {
            _customerInvoiceCostService = customerInvoiceCostService;
        }
        // GET: api/<CustomerInvoiceCostController>
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead")]
        [HttpGet]
        public IActionResult Get([FromQuery] CustomerInvoiceCostFilter filter)
        {
            try
            {
                var data = _customerInvoiceCostService.GetAllCustomerInvoiceCosts(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Customer Invoice Cost not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,CustomerInvoiceCostRead")]
        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] CustomerInvoiceCostFilter filter)
        {

            var data = _customerInvoiceCostService.CountCustomerInvoiceCosts(filter);
            return Ok(data);

        }

        // GET api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {
                var data = _customerInvoiceCostService.GetCustomerInvoiceCostById(id);
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // POST api/<CustomerInvoiceCostController>
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite")]
        [HttpPost]
        public IActionResult Post(CustomerInvoiceCostDTO customerInvoiceCost)
        {

            try
            {
                var data = _customerInvoiceCostService.CreateCustomerInvoiceCost(CustomerInvoiceCostMapper.Map(customerInvoiceCost));
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerInvoiceCostDTO customerInvoiceCost)
        {
            try
            {
                var data = _customerInvoiceCostService.UpdateCustomerInvoiceCost(id, CustomerInvoiceCostMapper.Map(customerInvoiceCost));
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostDelete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var data = _customerInvoiceCostService.DeleteCustomerInvoiceCost(id);
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}

