using API.Models;
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
        public async Task<IActionResult> GetClassifySalesByProfit()
        {
            var profit = await _context.ClassifySalesByProfit.FromSqlRaw("EXEC pf_ClassifySalesByProfit").ToListAsync();
            try
            {
                if (profit.Any())
                {
                    return Ok(profit);
                }
                else
                    throw new Exception("Procedure error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }


        //Get customers by status
        [HttpGet("total-amount-gained-per-customer-invoice")]
        public async Task<IActionResult> GetTotalAmountGainedPerCustomerInvoice([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var invoices = await _context.TotalAmountGainedPerCustomerInvoice.FromSqlRaw($"EXEC pf_TotalAmountGainedPerCustomerInvoice @status={status}").ToListAsync();
            try
            {
                if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        //Get customers by status
        [HttpGet("total-amount-spent-per-supplier-invoice")]
        public async Task<IActionResult> GetTotalAmountSpentPerSupplierInvoice([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var invoices = await _context.TotalAmountSpentPerSupplierInvoice.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSupplierInvoice @status={status}").ToListAsync();
            try
            {
                if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //Get customers by status
        [HttpGet("total-amount-spent-per-suppliers")]
        public async Task<IActionResult> GetTotalAmountSpentPerSuppliers([FromQuery] string status)
        {
            status = status.ToLower();
             status = char.ToUpper(status[0]) + status[1..];
            var invoices = await _context.TotalAmountSpentPerSuppliers.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSuppliers").ToListAsync();
            try
            {
                if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }



    }
}
