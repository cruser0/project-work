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
    [Route("api/customer-invoice-cost")]
    [ApiController]
    public class CustomerInvoiceCostController : ControllerBase
    {
        private readonly ICustomerInvoiceCostService _customerInvoiceCostService;
        private readonly ICustomerInvoicesService _customerInvoiceService;
        private readonly CostRegistryService _costRegistryService;
        public CustomerInvoiceCostController(ICustomerInvoiceCostService customerInvoiceCostService, CostRegistryService crs, ICustomerInvoicesService cis)
        {
            _customerInvoiceCostService = customerInvoiceCostService;
            _costRegistryService = crs;
            _customerInvoiceService = cis;
        }





        // GET: api/<CustomerInvoiceCostController>
        [Authorize(Roles = "Admin,CustomerInvoiceCostRead,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerInvoiceCostFilter filter)
        {
            var data = await _customerInvoiceCostService.GetAllCustomerInvoiceCosts(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else return Ok(new List<CustomerInvoiceCostDTOGet>());
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
            var data = await _customerInvoiceCostService.GetCustomerInvoiceCostById(id);
            if (data == null)
                throw new NotFoundException("Customer Invoice Cost not found");
            return Ok(data);
        }

        // POST api/<CustomerInvoiceCostController>
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerInvoiceCostDTO customerInvoiceCost)
        {
            var data = await _customerInvoiceCostService.CreateCustomerInvoiceCost(CustomerInvoiceCostMapper.Map(customerInvoiceCost,
                                                                                                                    await _costRegistryService.GetCostRegistryByCode(customerInvoiceCost.CostRegistryCode),
                                                                                                                    await _customerInvoiceService.GetOnlyCustomerInvoiceById((int)customerInvoiceCost.CustomerInvoiceId!)));
            if (data == null)
                throw new NotFoundException("Customer Invoice Cost not found");
            return Ok(data);
        }

        // PUT api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostWrite,CustomerInvoiceCostAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerInvoiceCostDTO customerInvoiceCost)
        {
            var data = await _customerInvoiceCostService.UpdateCustomerInvoiceCost(id, CustomerInvoiceCostMapper.Map(customerInvoiceCost,
                                                                                                                    await _costRegistryService.GetCostRegistryByCode(customerInvoiceCost.CostRegistryCode),
                                                                                                                    await _customerInvoiceService.GetOnlyCustomerInvoiceById((int)customerInvoiceCost.CustomerInvoiceId!)));
            if (data == null)
                throw new NotFoundException("Customer Invoice Cost not found");
            return Ok(data);
        }

        // DELETE api/<CustomerInvoiceCostController>/5
        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerInvoiceCostService.DeleteCustomerInvoiceCost(id);
            if (data == null)
                throw new NotFoundException("Customer Invoice Cost not found");
            return Ok(data);
        }

        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _customerInvoiceCostService.MassDeleteCustomerInvoiceCost(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<CustomerInvoiceCostDTOGet> newCustomerInvoiceCosts)
        {
            var data = await _customerInvoiceCostService.MassUpdateCustomerInvoiceCost(newCustomerInvoiceCosts);
            return Ok(data);
        }
        [Authorize(Roles = "Admin,CustomerInvoiceCostAdmin")]
        [HttpPut("mass-save")]
        public async Task<IActionResult> MassSave([FromBody] List<CustomerInvoiceCostDTO> newCustomerInvoiceCosts)
        {
            var data = await _customerInvoiceCostService.MassSaveCustomerInvoiceCost(newCustomerInvoiceCosts);
            return Ok(data);
        }
    }
}

