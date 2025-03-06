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
        public async Task<IActionResult> ClassifySalesByProfit()
        {
            var profit = await _context.ProfitClassifications.FromSqlRaw("EXEC pf_classifySalesByProfit").ToListAsync();
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
        [HttpGet("customer-invoices-by-status")]
        public async Task<IActionResult> FindCustomerInvoicesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var invoices = await _context.CustomerInvoiceStatuses.FromSqlRaw($"EXEC pf_findCustomerInvoicesByStatus @status={status}").ToListAsync();
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


        //get profit of a sale by their id
        [HttpGet("profit-by-saleid")]
        public async Task<IActionResult> FindProfitPerSaleID([FromQuery] int saleID)
        {
            var profit = await _context.ProfitSaleIDs.FromSqlRaw($"EXEC pf_findProfitPerSaleID @saleID={saleID}").ToListAsync();
            try
            {
                if (profit.Any())
                {
                    return Ok(profit);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        //get all sales with the same BoL 
        [HttpGet("sales-by-bol")]
        public async Task<IActionResult> FindSalesByBoLNumber([FromQuery] string bol)

        {
            var sales = await _context.SalesByBOLs.FromSqlRaw($"EXEC pf_findSalesByBoLNumber @BoLNumber=\"{bol}\"").ToListAsync();
            try
            {
                if (sales.Any())
                {
                    return Ok(sales);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        //get all sales with the same booking
        [HttpGet("sales-by-booking")]
        public async Task<IActionResult> FindSalesByBookingNumber([FromQuery] string bookingNumber)

        {
            var sales = await _context.SalesBybookings.FromSqlRaw($"EXEC pf_findSalesByBookingNumber @BookingNumber=\"{bookingNumber}\"").ToListAsync();
            try
            {
                if (sales.Any())
                {
                    return Ok(sales);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //get all sales with the same customer id
        [HttpGet("sales-by-customer-id")]
        public async Task<IActionResult> FindSalesByCustomerID([FromQuery] int customerID)

        {
            var sales = await _context.SalesByCustomerIDs.FromSqlRaw($"EXEC pf_findSalesByCustomerID @customerId=\"{customerID}\"").ToListAsync();
            try
            {
                if (sales.Any())
                {
                    return Ok(sales);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //Get sales by status
        [HttpGet("sales-by-status")]
        public async Task<IActionResult> FindSalesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var sales = await _context.SalesByStatuses.FromSqlRaw($"EXEC pf_findSalesByStatus @status={status}").ToListAsync();
            try
            {
                if (sales.Any())
                {
                    return Ok(sales);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //Get supplier invoice by status
        [HttpGet("supplier-invoices-by-status")]
        public async Task<IActionResult> FindSupplierInvoicesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var sales = await _context.SupplierInvoiceByStatuses.FromSqlRaw($"EXEC pf_findSupplierInvoicesByStatus @status={status}").ToListAsync();
            try
            {
                if (sales.Any())
                {
                    return Ok(sales);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //calculates the revenue for a sale
        [HttpGet("revenue-per-sale-id")]
        public async Task<IActionResult> FindTotalRevenuePerSale([FromQuery] int saleID)

        {
            var revenue = await _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{saleID}\"").ToListAsync();
            try
            {
                if (revenue.Any())
                {
                    return Ok(revenue);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //calculates the revenue for every sale
        [HttpGet("revenue-all-sales")]
        public async Task<IActionResult> FindTotalRevenueSales()

        {
            var revenue = await _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenueSales").ToListAsync();
            try
            {
                if (revenue.Any())
                {
                    return Ok(revenue);
                }
                else
                    throw new Exception("Procedure error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //calculates the amount spent for a sale
        [HttpGet("amount-spent-per-sale-id")]
        public async Task<IActionResult> TotalAmountSpentPerSaleID([FromQuery] int saleID)

        {
            var total = await _context.AmountSpentSaleIDs.FromSqlRaw($"EXEC pf_totalAmountSpentPerSaleID @saleID=\"{saleID}\"").ToListAsync();
            try
            {
                if (total.Any())
                {
                    return Ok(total);
                }
                else
                    throw new Exception("Input error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //calculates the total spent on each supplier
        [HttpGet("total-spent-per-supplier")]
        public async Task<IActionResult> TotalAmountSpentPerSuppliers()

        {
            var total = await _context.TotalSpentPerSuppliers.FromSqlRaw($"EXEC pf_totalAmountSpentPerSuppliers").ToListAsync();
            try
            {
                if (total.Any())
                {
                    return Ok(total);
                }
                else
                    throw new Exception("Procedure error");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
