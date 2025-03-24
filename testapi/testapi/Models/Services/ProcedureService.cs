using API.Models.Filters;
using API.Models.Procedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public class ProcedureService
    {
        private readonly Progetto_FormativoContext _context;
        public ProcedureService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<List<ClassifySalesByProfit>> FilterSalesByProfit(ClassifySalesByProfitFilter filter)
        {
            var sql = _context.ClassifySalesByProfit.FromSqlRaw(
                    "EXEC pf_ClassifySalesByProfit " +
                    "@TotalSpentFrom, " +
                    "@TotalSpentTo, " +
                    "@TotalRevenueFrom, " +
                    "@TotalRevenueTo, " +
                    "@FilterMargin, " +
                    "@ProfitFrom, " +
                    "@ProfitTo, " +
                    "@BoLNumber, " +
                    "@BKNumber, " +
                    "@CustomerID, " +
                    "@Status, " +
                    "@CustomerName, " +
                    "@CustomerCountry, " +
                    "@CountryRegion, " +
                    "@SaleID, " +
                    "@DateFrom, " +
                    "@DateTo",
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
                    new SqlParameter("@CountryRegion", filter.CountryRegion ?? (object)DBNull.Value),
                    new SqlParameter("@SaleID", filter.SaleID ?? (object)DBNull.Value),
                    new SqlParameter("@DateFrom", filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : (object)DBNull.Value),
                    new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo.Value.Date : (object)DBNull.Value));

            return await sql.ToListAsync();
        }

        public async Task<List<TotalAmountGainedPerCustomerInvoice>> FilterCustomerInvoicesByAmountGained(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var sql = _context.TotalAmountGainedPerCustomerInvoice.FromSqlRaw(
                $"EXEC pf_TotalAmountGainedPerCustomerInvoice " +
                $"@customerInvoiceID," +
                $"@TotalGainedFrom," +
                $"@TotalGainedTo," +
                $"@DateFrom," +
                $"@DateTo," +
                $"@Status," +
                $"@CustomerName," +
                $"@CustomerCountry," +
                "@CountryRegion",
                new SqlParameter("@customerInvoiceID", filter.customerInvoiceID ?? (object)DBNull.Value),
                new SqlParameter("@TotalGainedFrom", filter.TotalGainedFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalGainedTo", filter.TotalGainedTo ?? (object)DBNull.Value),
                new SqlParameter("@DateFrom", filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : (object)DBNull.Value),
                new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo : (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@CustomerName", filter.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@CustomerCountry", filter.CustomerCountry ?? (object)DBNull.Value),
                new SqlParameter("@CountryRegion", filter.CountryRegion ?? (object)DBNull.Value));
            return await sql.ToListAsync();
        }

        public async Task<List<TotalAmountSpentPerSupplierInvoice>> FilterSupplierInvoicesByAmountSpent(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var sql = _context.TotalAmountSpentPerSupplierInvoice.FromSqlRaw(
                $"EXEC pf_TotalAmountSpentPerSupplierInvoice " +
                $"@SupplierInvoiceID," +
                $"@TotalSpentFrom," +
                $"@TotalSpentTo," +
                $"@DateFrom," +
                $"@DateTo," +
                $"@Status," +
                $"@SupplierName," +
                $"@SupplierCountry," +
                "@CountryRegion",
                new SqlParameter("@SupplierInvoiceID", filter.SupplierInvoiceID ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentFrom", filter.TotalSpentFrom ?? (object)DBNull.Value),
                new SqlParameter("@TotalSpentTo", filter.TotalSpentTo ?? (object)DBNull.Value),
                new SqlParameter("@DateFrom", filter.DateFrom.HasValue ? filter.DateFrom.Value.Date : (object)DBNull.Value),
                new SqlParameter("@DateTo", filter.DateTo.HasValue ? filter.DateTo.Value.Date : (object)DBNull.Value),
                new SqlParameter("@Status", filter.Status ?? (object)DBNull.Value),
                new SqlParameter("@SupplierName", filter.SupplierName ?? (object)DBNull.Value),
                new SqlParameter("@SupplierCountry", filter.SupplierCountry ?? (object)DBNull.Value),
                new SqlParameter("@CountryRegion", filter.CountryRegion ?? (object)DBNull.Value));
            return await sql.ToListAsync();
        }
    }
}
