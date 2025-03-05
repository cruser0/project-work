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
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet]
        public async  Task<IActionResult> Get([FromQuery] CustomerInvoiceCostFilter filter)
        {
            try
            {
                var data =await  _customerInvoiceCostService.GetAllCustomerInvoiceCosts(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new Exception("Customer Invoice Cost not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CustomerInvoiceCostFilter filter)
        {

            var data =await _customerInvoiceCostService.CountCustomerInvoiceCosts(filter);
            return Ok(data);

        }

        // GET api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var data =await _customerInvoiceCostService.GetCustomerInvoiceCostById(id);
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }

        }

        // POST api/<CustomerInvoiceCostController>
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerInvoiceCostDTO customerInvoiceCost)
        {

            try
            {
                var data = await _customerInvoiceCostService.CreateCustomerInvoiceCost(CustomerInvoiceCostMapper.Map(customerInvoiceCost));
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // PUT api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceCostDTO customerInvoiceCost)
        {
            try
            {
                var data =await _customerInvoiceCostService.UpdateCustomerInvoiceCost(id, CustomerInvoiceCostMapper.Map(customerInvoiceCost));
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }

        // DELETE api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data =await _customerInvoiceCostService.DeleteCustomerInvoiceCost(id);
                if (data == null)
                    throw new Exception("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
        }
    }
}

