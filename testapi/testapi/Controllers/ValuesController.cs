using API.Models.Filters;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValueServices _valueServices;

        public ValuesController(ValueServices valueServices)
        {
            _valueServices = valueServices;
        }

        [HttpGet()]
        public IActionResult GetCustomerInvoiceCosts([FromQuery] CustomerInvoiceCostFilter? costFilter,
                                                     [FromQuery] CustomerInvoiceFilter? invoiceFilter,
                                                     [FromQuery] SaleFilter? saleFilter,
                                                     [FromQuery] CustomerFilter? customerFilter)
        {
            costFilter = CheckFilter(costFilter);
            invoiceFilter = CheckFilter(invoiceFilter);
            saleFilter = CheckFilter(saleFilter);
            customerFilter = CheckFilter(customerFilter);
            var results = _valueServices.GetCustomerInvoiceCosts(costFilter, invoiceFilter, saleFilter, customerFilter);
            return Ok(results);
        }
        /*
        [HttpGet("customer-invoices")]
        public IActionResult GetCustomerInvoices([FromQuery] CustomerInvoiceFilter? invoiceFilter,
                                                 [FromQuery] SaleFilter? saleFilter,
                                                 [FromQuery] CustomerFilter? customerFilter)
        {
            invoiceFilter = CheckFilter(invoiceFilter);
            saleFilter = CheckFilter(saleFilter);
            customerFilter = CheckFilter(customerFilter);
            var results = _valueServices.GetCustomerInvoices(invoiceFilter, saleFilter, customerFilter);
            return Ok(results);
        }

        [HttpGet("sales")]
        public IActionResult GetSales([FromQuery] SaleFilter? saleFilter,
                                      [FromQuery] CustomerFilter? customerFilter)
        {
            saleFilter = CheckFilter(saleFilter);
            customerFilter = CheckFilter(customerFilter);
            var results = _valueServices.GetSales(saleFilter, customerFilter);
            return Ok(results);
        }

        [HttpGet("customers")]
        public IActionResult GetCustomers([FromQuery] CustomerFilter? customerFilter)
        {
            customerFilter = CheckFilter(customerFilter);
            var results = _valueServices.GetCustomers(customerFilter);
            return Ok(results);
        }*/

        private T? CheckFilter<T>(T? filter) where T : class
        {
            if (filter == null)
            {
                return null;
            }

            // Get all properties of the filter
            var properties = filter.GetType().GetProperties();

            // Check if at least one property is not null
            bool hasNonNullProperty = properties.Any(property => property.GetValue(filter) != null);

            if (!hasNonNullProperty)
            {
                return null;  // If all properties are null, return null
            }

            return filter;  // If at least one property is not null, return the filter itself
        }

    }
}
