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
        public ProcedureController(Progetto_FormativoContext ctx, ProcedureService ps)
        {
            _procedureService = ps;
            _context = ctx;
        }



        [HttpGet("sale-status-chart")]
        public async Task<IActionResult> SalePieChart([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var sales = await FilterSalesByProfit(filter);

            Dictionary<string, int> returnValue = _procedureService.PieChart(sales, "status");
            return Ok(returnValue);
        }

        [HttpGet("customer-invoice-status-chart")]
        public async Task<IActionResult> CustomerInvoicePieChart([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var customerInvoices = await FilterCustomerInvoicesByAmountGained(filter);

            Dictionary<string, int> returnValue = _procedureService.PieChart(customerInvoices, "status");
            return Ok(returnValue);
        }

        [HttpGet("supplier-invoice-status-chart")]
        public async Task<IActionResult> SupplierInvoicePieChart([FromQuery] TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var supplierInvoices = await FilterSupplierInvoicesByAmountSpent(filter);

            Dictionary<string, int> returnValue = _procedureService.PieChart(supplierInvoices, "status");
            return Ok(returnValue);
        }


        [HttpGet("sale-temporal")]
        public async Task<IActionResult> SaleTemporal([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var sales = await FilterSalesByProfit(filter);

            Dictionary<DateTime, decimal> returnValue = _procedureService.TemporalSeries(sales, "SaleDate", "TotalRevenue");
            return Ok(returnValue);
        }

        [HttpGet("customer-invoice-temporal")]
        public async Task<IActionResult> CustomerInvoiceTemporal([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var customerInvoices = await FilterCustomerInvoicesByAmountGained(filter);

            Dictionary<DateTime, decimal> returnValue = _procedureService.TemporalSeries(customerInvoices, "InvoiceDate", "InvoiceAmount");
            return Ok(returnValue);
        }

        [HttpGet("supplier-invoice-temporal")]
        public async Task<IActionResult> SupplierInvoiceTemporal([FromQuery] TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var supplierInvoices = await FilterSupplierInvoicesByAmountSpent(filter);

            Dictionary<DateTime, decimal> returnValue = _procedureService.TemporalSeries(supplierInvoices, "InvoiceDate", "InvoiceAmount");
            return Ok(returnValue);
        }


        // classify by profit the records
        [HttpGet("classify-by-profit")]
        public async Task<IActionResult> GetClassifySalesByProfit([FromQuery] ClassifySalesByProfitFilter filter)
        {
            var profit = await FilterSalesByProfit(filter);

            SaleListChartDTO returnCharts = _procedureService.GetCharths(profit);
            return Ok(returnCharts);

        }



        //Get customers by status
        [HttpGet("total-amount-gained-per-customer-invoice")]
        public async Task<IActionResult> GetTotalAmountGainedPerCustomerInvoice([FromQuery] TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var invoices = await FilterCustomerInvoicesByAmountGained(filter);

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
            var invoices = await FilterSupplierInvoicesByAmountSpent(filter);


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

        private async Task<List<ClassifySalesByProfit>> FilterSalesByProfit(ClassifySalesByProfitFilter filter)
        {
            return await _context.ClassifySalesByProfit.FromSqlRaw(
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
        }

        private async Task<List<TotalAmountGainedPerCustomerInvoice>> FilterCustomerInvoicesByAmountGained(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            return await _context.TotalAmountGainedPerCustomerInvoice.FromSqlRaw(
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
                new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo : (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", filter.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.CustomerCountry ?? (object)DBNull.Value)).ToListAsync();
        }

        private async Task<List<TotalAmountSpentPerSupplierInvoice>> FilterSupplierInvoicesByAmountSpent(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            return await _context.TotalAmountSpentPerSupplierInvoice.FromSqlRaw($"EXEC pf_TotalAmountSpentPerSupplierInvoice " +
                $"@SupplierInvoiceID," +
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
        }


    }
}
