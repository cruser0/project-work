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
    [Route("api/customer-invoice")]
    [ApiController]
    public class CustomerInvoiceController : ControllerBase
    {
        private readonly ICustomerInvoicesService _customerInvoiceService;
        public CustomerInvoiceController(ICustomerInvoicesService customerInvoiceService)
        {
            _customerInvoiceService = customerInvoiceService;
        }
        // GET: api/<CustomerInvoiceController>
        [Authorize(Roles = "Admin,CustomerInvoiceRead,CustomerInvoiceWrite,CustomerInvoiceAdmin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerInvoiceFilter filter)
        {
            try
            {
                var result = await _customerInvoiceService.GetAllCustomerInvoices(filter);
                if (result.Any())
                {
                    return Ok(result);
                }
                else throw new NotFoundException("Customer Invoices not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,CustomerInvoiceRead,CustomerInvoiceWrite,CustomerInvoiceAdmin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CustomerInvoiceFilter filter)
        {
            var data = await _customerInvoiceService.CountCustomerInvoices(filter);
            return Ok(data);
        }

        // GET api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceRead")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var data = await _customerInvoiceService.GetCustomerInvoiceById(id);
                if (data == null)
                    throw new NotFoundException("Customer Invoices not found");

                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // POST api/<CustomerInvoiceController>
        [Authorize(Roles = "Admin,CustomerInvoiceWrite,CustomerInvoiceAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerInvoiceDTO customerInvoice)
        {
            try
            {
                var data = await _customerInvoiceService.CreateCustomerInvoice(CustomerInvoiceMapper.Map(customerInvoice));
                if (data == null)
                    throw new NotFoundException("Customer Invoices not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // PUT api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceWrite,CustomerInvoiceAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceDTO customerInvoice)
        {
            try
            {
                var data = await _customerInvoiceService.UpdateCustomerInvoice(id, CustomerInvoiceMapper.Map(customerInvoice));
                if (data == null)
                    throw new NotFoundException("Customer Invoices not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

        // DELETE api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var data = await _customerInvoiceService.DeleteCustomerInvoice(id);
                if (data == null)
                    throw new NotFoundException("Customer Invoices not found!");
                return Ok(data);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }
    }
}
