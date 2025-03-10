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
        public async Task<IActionResult> Get([FromQuery] CustomerInvoiceCostFilter filter)
        {
            try
            {
                var data = await _customerInvoiceCostService.GetAllCustomerInvoiceCosts(filter);
                if (data.Any())
                {
                    return Ok(data);
                }
                else throw new NotFoundException("Customer Invoice Cost not found");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CustomerInvoiceCostFilter filter)
        {

            var data = await _customerInvoiceCostService.CountCustomerInvoiceCosts(filter);
            return Ok(data);

        }

        // GET api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var data = await _customerInvoiceCostService.GetCustomerInvoiceCostById(id);
                if (data == null)
                    throw new NotFoundException("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }

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
                    throw new NotFoundException("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        // PUT api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceCostDTO customerInvoiceCost)
        {
            try
            {
                var data = await _customerInvoiceCostService.UpdateCustomerInvoiceCost(id, CustomerInvoiceCostMapper.Map(customerInvoiceCost));
                if (data == null)
                    throw new NotFoundException("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (DbUpdateException ex) { return BadRequest(ex.InnerException.Message); }
        }

        // DELETE api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _customerInvoiceCostService.DeleteCustomerInvoiceCost(id);
                if (data == null)
                    throw new NotFoundException("Customer Invoice Cost not found");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {

            try
            {
                var data = await _customerInvoiceCostService.MassDeleteCustomerInvoiceCost(id);
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
    }
}

