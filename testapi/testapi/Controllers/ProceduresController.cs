using API.Models;
using API.Models.Filters;
using API.Models.Procedures;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/procedure/")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly ProcedureService _procedureService;
        public ProcedureController(ProcedureService ps)
        {
            _procedureService = ps;
        }

        // classify by profit the records
        [HttpGet("classify-by-profit")]
        public async Task<IActionResult> GetClassifySalesByProfit([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var profit = await _procedureService.FilterSalesByProfit(filter);
            if(profit!=null)
                return Ok(profit);
            return Ok(new List<ClassifySalesByProfit>());

        }

        [HttpGet("total-amount-gained-per-customer-invoice")]
        public async Task<IActionResult> GetTotalAmountGainedPerCustomerrInvoice([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var invoices = await _procedureService.FilterCustomerInvoicesByAmountGained(filter);
            if (invoices.Any())
                return Ok(invoices);
            return Ok(new List<TotalAmountGainedPerCustomerInvoice>());
        }



        [HttpGet("total-amount-spent-per-supplier-invoice")]
        public async Task<IActionResult> GetTotalAmountSpentPerSupplierInvoice([FromQuery] TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var invoices = await _procedureService.FilterSupplierInvoicesByAmountSpent(filter);
            if (invoices.Any())
                return Ok(invoices);
            return Ok(new List<TotalAmountSpentPerSupplierInvoice>());
        }

    }
}
