using API.Models.Exceptions;
using API.Models.Services;
using Entity_Validator.Entity.Filters;
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

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomerInvoiceCosts([FromQuery] CustomerInvoiceCostFilter? costFilter,
                                                     [FromQuery] CustomerInvoiceFilter? invoiceFilter,
                                                     [FromQuery] SaleCustomerFilter? saleFilter,
                                                     [FromQuery] CustomerFilter? customerFilter)
        {
            try
            {
                costFilter = CheckFilter(costFilter);
                invoiceFilter = CheckFilter(invoiceFilter);
                saleFilter = CheckFilter(saleFilter);
                customerFilter = CheckFilter(customerFilter);
                var results = await _valueServices.GetCustomerInvoiceCosts(costFilter, invoiceFilter, saleFilter, customerFilter);
                return Ok(results);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }

        }
        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSupplierInvoiceCosts([FromQuery] SupplierInvoiceCostFilter? costFilter,
                                                    [FromQuery] SupplierInvoiceFilter? invoiceFilter,
                                                    [FromQuery] SupplierFilter? supplierFilter)
        {
            try
            {

                costFilter = CheckFilter(costFilter);
                invoiceFilter = CheckFilter(invoiceFilter);
                supplierFilter = CheckFilter(supplierFilter);
                var results = await _valueServices.GetSupplierInvoiceCosts(costFilter, invoiceFilter, supplierFilter);
                return Ok(results);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
        }

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
