using API.Models;
using API.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            var profit = await _context.ClassifySalesByProfit.FromSqlRaw(
                "EXEC pf_ClassifySalesByProfit @SaleID, @TotalSpentFrom, @TotalSpentTo, @ProfitFrom, @ProfitTo, " +
                "@BKNumber, @BoLNumber, @CustomerID, @CustomerCountry, @CustomerName, @Status, " +
                "@TotalRevenueFrom, @TotalRevenueTo, @FilterMargin",
                new SqlParameter("@SaleID", filter.SaleID ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentFrom", filter.TotalSpentFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentTo", filter.TotalSpentTo ?? (object)DBNull.Value),
                new SqlParameter("@ProfitFrom", filter.ProfitFrom ?? (object)DBNull.Value),
                new SqlParameter("@ProfitTo", filter.ProfitTo ?? (object)DBNull.Value),
                new SqlParameter("@BKNumber", filter.BKNumber ?? (object)DBNull.Value),
                new SqlParameter("@BoLNumber", filter.BoLNumber ?? (object)DBNull.Value),
                new SqlParameter("@CustomerID", filter.CustomerID ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.CustomerCountry ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", filter.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@TotalRevenueFrom", filter.TotalRevenueFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalRevenueTo", filter.TotalRevenueTo ?? (object)DBNull.Value),
                new SqlParameter("@FilterMargin", filter.FilterMargin ?? (object)DBNull.Value)).ToListAsync();

            if (profit.Any())
            {
                return Ok(profit);
            }
            else
            {
                throw new Exception("Procedure error");
            }
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
