using API.Models;
using API.Models.Entities.Charts;
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
        private readonly Progetto_FormativoContext _context;
        private readonly ProcedureService _procedureService;
        public ProcedureController(Progetto_FormativoContext ctx,ProcedureService ps)
        {
            _procedureService = ps;
            _context = ctx;
        }


        // classify by profit the records
        [HttpGet("classify-by-profit")]
        public async Task<IActionResult> GetClassifySalesByProfit([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var profit = await _context.ClassifySalesByProfit.FromSqlRaw(
                "EXEC pf_ClassifySalesByProfit " +
                "@TotalSpentFrom," +
                "@TotalSpentTo," +
                "@TotalRevenueFrom," +
                "@TotalRevenueTo" +
                ",@FilterMargin," +
                "@ProfitFrom," +
                "@ProfitTo," +
                "@BoLNumber," +
                "@BKNumber," +
                "@CustomerID," +
                "@Status," +
                "@CustomerName," +
                "@CustomerCountry," +
                "@SaleID",
                new SqlParameter("@TotalSpentFrom", filter.TotalSpentFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentTo", filter.TotalSpentTo ?? (object)DBNull.Value),
                new SqlParameter("@TotalRevenueFrom", filter.TotalRevenueFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalRevenueTo", filter.TotalRevenueTo ?? (object)DBNull.Value),
                new SqlParameter("@FilterMargin", filter.FilterMargin ?? (object)DBNull.Value),
                new SqlParameter("@ProfitFrom", filter.ProfitFrom ?? (object)DBNull.Value),
                new SqlParameter("@ProfitTo", filter.ProfitTo ?? (object)DBNull.Value),
                new SqlParameter("@BoLNumber", filter.BoLNumber ?? (object)DBNull.Value),
                new SqlParameter("@BKNumber", filter.BKNumber ?? (object)DBNull.Value),
                new SqlParameter("@CustomerID", filter.CustomerID ?? (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", filter.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.CustomerCountry ?? (object)DBNull.Value),
                new SqlParameter("@SaleID", filter.SaleID ?? (object)DBNull.Value)).ToListAsync();

            SaleListChartDTO returnCharts = _procedureService.GetCharths(profit);
            return Ok(returnCharts);

        }



        //Get customers by status
        [HttpGet("total-amount-gained-per-customer-invoice")]
        public async Task<IActionResult> GetTotalAmountGainedPerCustomerInvoice([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var invoices = await _context.TotalAmountGainedPerCustomerInvoice.FromSqlRaw(
                $"EXEC pf_TotalAmountGainedPerCustomerInvoice " +
                $"@customerInvoiceID," +
                $"@TotalGainedFrom," +
                $"@TotalGainedTo," +
                $"@DateFrom," +
                $"@DateTo," +
                $"@Status," +
                $"@CustomerName," +
                $"@CustomerCountry",
                new SqlParameter("@customerInvoiceID", filter.customerInvoiceID ?? (object)DBNull.Value),
                new SqlParameter("@TotalGainedFrom", filter.TotalGainedFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalGainedTo", filter.TotalGainedTo ?? (object)DBNull.Value),
                new SqlParameter("@DateFrom", filter.DateFrom.HasValue ? filter.DateFrom : (object)DBNull.Value),
                new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo:(object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", filter.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.CustomerCountry ?? (object)DBNull.Value)).ToListAsync();
            if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                     return Ok(new List<TotalAmountGainedPerCustomerInvoice>());
        }


        //Get customers by status
        [HttpGet("total-amount-spent-per-supplier-invoice")]
        public async Task<IActionResult> GetTotalAmountSpentPerSupplierInvoice([FromQuery] TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var invoices = await _context.TotalAmountSpentPerSupplierInvoice.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSupplierInvoice " +
                $"@SupplierInvoiceID,"+
                $"@TotalSpentFrom," +
                $"@TotalSpentTo," +
                $"@DateFrom," +
                $"@DateTo," +
                $"@Status," +
                $"@SupplierName," +
                $"@SupplierCountry",
                new SqlParameter("@SupplierInvoiceID", filter.SupplierInvoiceID ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentFrom", filter.TotalSpentFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentTo", filter.TotalSpentTo ?? (object)DBNull.Value),
                new SqlParameter("@DateFrom", filter.DateFrom.HasValue ? filter.DateFrom : (object)DBNull.Value),
                new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo : (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@SupplierName", filter.SupplierName ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.SupplierCountry ?? (object)DBNull.Value)).ToListAsync();
            if (invoices.Any())
                {
                    return Ok(invoices);
                }
                else
                return Ok(new List<TotalAmountSpentPerSupplierInvoice>());
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
                return Ok(new List<TotalAmountSpentPerSuppliers>());
        }



    }
}
