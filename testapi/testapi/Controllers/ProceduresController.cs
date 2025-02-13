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
        public IActionResult ClassifySalesByProfit()
        {
            var profit = _context.ProfitClassifications.FromSqlRaw("EXEC pf_classifySalesByProfit").ToList();
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
        public IActionResult FindCustomerInvoicesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var invoices = _context.CustomerInvoiceStatuses.FromSqlRaw($"EXEC pf_findCustomerInvoicesByStatus @status={status}").ToList();
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
        public IActionResult FindProfitPerSaleID([FromQuery] int saleID)
        {
            var profit = _context.ProfitSaleIDs.FromSqlRaw($"EXEC pf_findProfitPerSaleID @saleID={saleID}").ToList();
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
        public IActionResult FindSalesByBoLNumber([FromQuery] string bol)

        {
            var sales = _context.SalesByBOLs.FromSqlRaw($"EXEC pf_findSalesByBoLNumber @BoLNumber=\"{bol}\"").ToList();
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
        public IActionResult FindSalesByBookingNumber([FromQuery] string bookingNumber)

        {
            var sales = _context.SalesBybookings.FromSqlRaw($"EXEC pf_findSalesByBookingNumber @BookingNumber=\"{bookingNumber}\"").ToList();
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
        public IActionResult FindSalesByCustomerID([FromQuery] int customerID)

        {
            var sales = _context.SalesByCustomerIDs.FromSqlRaw($"EXEC pf_findSalesByCustomerID @customerId=\"{customerID}\"").ToList();
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
        public IActionResult FindSalesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var sales = _context.SalesByStatuses.FromSqlRaw($"EXEC pf_findSalesByStatus @status={status}").ToList();
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
        public IActionResult FindSupplierInvoicesByStatus([FromQuery] string status)
        {
            status = status.ToLower();
            status = char.ToUpper(status[0]) + status[1..];
            var sales = _context.SupplierInvoiceByStatuses.FromSqlRaw($"EXEC pf_findSupplierInvoicesByStatus @status={status}").ToList();
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
        public IActionResult FindTotalRevenuePerSale([FromQuery] int saleID)

        {
            var revenue = _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenuePerSale @saleID=\"{saleID}\"").ToList();
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
        public IActionResult FindTotalRevenueSales()

        {
            var revenue = _context.RevenuePerSaleIDs.FromSqlRaw($"EXEC pf_findTotalRevenueSales").ToList();
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
        public IActionResult TotalAmountSpentPerSaleID([FromQuery] int saleID)

        {
            var total = _context.AmountSpentSaleIDs.FromSqlRaw($"EXEC pf_totalAmountSpentPerSaleID @saleID=\"{saleID}\"").ToList();
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
        public IActionResult TotalAmountSpentPerSuppliers()

        {
            var total = _context.TotalSpentPerSuppliers.FromSqlRaw($"EXEC pf_totalAmountSpentPerSuppliers").ToList();
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
