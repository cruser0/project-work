
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
    [Route("api/customer-invoice")]
    [ApiController]
    public class CustomerInvoiceController : ControllerBase
    {
        private readonly ICustomerInvoicesService _customerInvoiceService;
        private readonly ISalesService _saleService;
        private readonly IStatusService _statusService;
        public CustomerInvoiceController(ICustomerInvoicesService customerInvoiceService, IStatusService ss, ISalesService saleServ)
        {
            _customerInvoiceService = customerInvoiceService;
            _statusService = ss;
            _saleService = saleServ;
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
            else return Ok(new List<CustomerInvoiceDTOGet>());
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
            customerInvoice.IsPost = true;
            var results = ValidatorEntity.Validate(customerInvoice);
            if (results.Count > 0)
                throw new ValidateException(results.First().ErrorMessage);

            var data = await _customerInvoiceService.CreateCustomerInvoice(CustomerInvoiceMapper.Map(customerInvoice,
                                                                                                    await _statusService.GetStatusByName(customerInvoice.Status),
                                                                                                    await _saleService.GetOnlySaleById((int)customerInvoice.SaleID!)));
            if (data == null)
                throw new NotFoundException("Customer Invoices not found!");
            return Ok(data);
        }



        // PUT api/<CustomerInvoiceController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceWrite,CustomerInvoiceAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceDTO customerInvoice)
        {
            customerInvoice.IsPost = false;
            var results = ValidatorEntity.Validate(customerInvoice);
            if (results.Count > 0)
                throw new ValidateException(results.First().ErrorMessage);

            var data = await _customerInvoiceService.UpdateCustomerInvoice(id, CustomerInvoiceMapper.Map(customerInvoice,
                                                                                                   await _statusService.GetStatusByName(customerInvoice.Status),
                                                                                                    await _saleService.GetOnlySaleById((int)customerInvoice.SaleID!)));
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

        [HttpGet("customer-invoice-summary/{CustomerID}")]
        public async Task<ActionResult<CustomerInvoiceSummary>> GetCustomerInvoiceSummary(int CustomerID)
        {
            var data = await _customerInvoiceService.GetCustomerInvoiceSummary(CustomerID);
            return Ok(data);
        }

        [HttpPost("make-invoice")]
        public async Task<IActionResult> MakeInvoiceFromSupplier([FromBody] MakeCustomerInvoiceDTO MakeCustomerInvoiceDTO)
        {
            var data = await _customerInvoiceService.MakeInvoiceFromSupplier(MakeCustomerInvoiceDTO);
            if (data == null)
                throw new Exception("Something went wrong");

            return Ok(data);
        }
    }
}
