using API.Models.Services;
using Entity_Validator.Entity.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customer-invoice-amount")]
    [ApiController]
    public class CustomerInvoiceAmountPaidController : ControllerBase
    {
        private readonly ICustomerInvoiceAmountPaidServices _customerInvoiceAmountPaidServices;
        public CustomerInvoiceAmountPaidController(ICustomerInvoiceAmountPaidServices customerInvoiceAmountPaidServices)
        {
            _customerInvoiceAmountPaidServices = customerInvoiceAmountPaidServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerInvoiceAmountPaidFilter filter)
        {
            var data = await _customerInvoiceAmountPaidServices.GetBySale(filter);

            return Ok(data);
        }
    }
}
