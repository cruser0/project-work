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
    [Route("api/customer-invoice")]
    [ApiController]
    public class CustomerInvoiceController : ControllerBase
    {
        private readonly ICustomerInvoicesService _customerInvoiceService;
        private readonly StatusService _statusService;
        public CustomerInvoiceController(ICustomerInvoicesService customerInvoiceService,StatusService ss)
        {
            _customerInvoiceService = customerInvoiceService;
            _statusService = ss;
        }



        // GET: api/<CustomerInvoiceController>
        [Authorize(Roles = "Admin,CustomerInvoiceRead,CustomerInvoiceWrite,CustomerInvoiceAdmin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerInvoiceFilter filter)
        {
            var result = await _customerInvoiceService.GetAllCustomerInvoices(filter);
            if (result.Any())
            {
                return Ok(result);
            }
            else throw new NotFoundException("Customer Invoices not found");
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
            var data = await _customerInvoiceService.GetCustomerInvoiceById(id);
            if (data == null)
                throw new NotFoundException("Customer Invoices not found");
            return Ok(data);
        }






        // POST api/<CustomerInvoiceController>
        [Authorize(Roles = "Admin,CustomerInvoiceWrite,CustomerInvoiceAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerInvoiceDTO customerInvoice)
        {
            var data = await _customerInvoiceService.CreateCustomerInvoice(CustomerInvoiceMapper.Map(customerInvoice,_statusService.GetStatusByName(customerInvoice.Status)));
            if (data == null)
                throw new NotFoundException("Customer Invoices not found!");
            return Ok(data);
        }



        // PUT api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceWrite,CustomerInvoiceAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceDTO customerInvoice)
        {
            var data = await _customerInvoiceService.UpdateCustomerInvoice(id, CustomerInvoiceMapper.Map(customerInvoice, _statusService.GetStatusByName(customerInvoice.Status)));
            if (data == null)
                if (data == null)
                throw new NotFoundException("Customer Invoices not found!");
            return Ok(data);
        }




        // DELETE api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerInvoiceService.DeleteCustomerInvoice(id);
            if (data == null)
                throw new NotFoundException("Customer Invoices not found!");
            return Ok(data);
        }



        [Authorize(Roles = "Admin,CustomerInvoiceAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
                var data = await _customerInvoiceService.MassDeleteCustomerInvoice(id);
                return Ok(data);
        }




        [Authorize(Roles = "Admin,CustomerInvoiceAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<CustomerInvoiceDTOGet> newCustomerInvoices)
        {
            var data = await _customerInvoiceService.MassUpdateCustomerInvoice(newCustomerInvoices);
            return Ok(data);
        }
    }
}
