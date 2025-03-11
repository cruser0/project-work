using API.Models;
using API.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/procedure")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly Progetto_FormativoContext _context;
        public ProcedureController(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }


        // classify by profit the records
        [HttpGet("classify-by-profit")]
        public async Task<IActionResult> GetClassifySalesByProfit([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var profit = await _context.ClassifySalesByProfit.FromSqlRaw($"EXEC pf_ClassifySalesByProfit " +
                $"@SaleID={filter.SaleID}," +
                $"@TotalSpentFrom={filter.TotalSpentFrom}," +
                $"@TotalSpentTo={filter.TotalSpentTo}," +
                $"@ProfitFrom={filter.ProfitFrom}," +
                $"@ProfitTo={filter.ProfitTo}," +
                $"@BKNumber={filter.BKNumber.ToUpper()}," +
                $"@BoLNumber={filter.BoLNumber.ToUpper()}," +
                $"@CustomerID={filter.CustomerID}," +
                $"@CustomerCountry={filter.CustomerCountry}," +
                $"@CustomerName={filter.CustomerName}," +
                $"@Status={filter.Status}," +
                $"@TotalSpentFrom={filter.TotalSpentFrom}," +
                $"@TotalSpentTo={filter.TotalSpentTo}," +
                $"@FilterMargin={filter.FilterMargin.ToLower()}").ToListAsync();
                if (profit.Any())
                {
                    return Ok(profit);
                }
                else
                    throw new Exception("Procedure error");

        }


        //Get customers by status
        [HttpGet("total-amount-gained-per-customer-invoice")]
        public async Task<IActionResult> GetTotalAmountGainedPerCustomerInvoice([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var invoices = await _context.TotalAmountGainedPerCustomerInvoice.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice " +
                $"@TotalGainedFrom={filter.TotalGainedFrom}," +
                $"@TotalGainedTo={filter.TotalGainedTo}," +
                $"@DateFrom={filter.DateFrom}," +
                $"@DateTo={filter.DateTo}," +
                $"@CustomerName={filter.CustomerName}," +
                $"@CustomerCountry={filter.CustomerCountry}," +
                $"@Status={filter.Status}," +
                $"@customerInvoiceID={filter.customerInvoiceID}").ToListAsync();
                if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
        }


        //Get customers by status
        [HttpGet("total-amount-spent-per-supplier-invoice")]
        public async Task<IActionResult> GetTotalAmountSpentPerSupplierInvoice([FromQuery] TotalAmountSpentPerSupplierInvoice filter)
        {
            var invoices = await _context.TotalAmountSpentPerSupplierInvoice.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSupplierInvoice " +
                $"@TotalSpentFrom={filter.TotalSpentFrom}," +
                $"@TotalSpentTo={filter.TotalSpentTo}," +
                $"@DateFrom={filter.DateFrom}," +
                $"@DateTo={filter.DateTo}," +
                $"@SupplierName={filter.SupplierName}," +
                $"@SupplierCountry={filter.SupplierCountry}," +
                $"@Status={filter.Status}," +
                $"@SupplierInvoiceID={filter.SupplierInvoiceID}").ToListAsync();
            if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
        }

        //Get customers by status
        [HttpGet("total-amount-spent-per-suppliers")]
        public async Task<IActionResult> GetTotalAmountSpentPerSuppliers()
        {
            var invoices = await _context.TotalAmountSpentPerSuppliers.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSuppliers").ToListAsync();
                if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
        }



    }
}
