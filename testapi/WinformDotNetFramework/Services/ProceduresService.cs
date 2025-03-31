using Entity_Validator.Entity.Filters;
using Entity_Validator.Entity.Procedures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Services
{
    internal class ProceduresService : BaseCallService
    {

        private string BuildQueryParams(ClassifySalesByProfitFilter filter)
        {
            var queryParameters = new List<string>();

            string dateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";
            string dateTo = filter.DateTo.HasValue ? filter.DateTo.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";

            var filters = new Dictionary<string, object>
            {
                { "TotalSpentFrom", filter.TotalSpentFrom ?? null },
                { "TotalSpentTo", filter.TotalSpentTo ?? null },
                { "TotalRevenueFrom", filter.TotalRevenueFrom ?? null },
                { "TotalRevenueTo", filter.TotalRevenueTo ?? null },
                { "FilterMargin", filter.FilterMargin ?? null},
                { "ProfitFrom", filter.ProfitFrom ?? null},
                { "ProfitTo", filter.ProfitTo ?? null},
                { "BoLNumber", filter.BoLNumber ?? null},
                { "BKNumber", filter.BKNumber ?? null},
                { "CustomerID", filter.CustomerID ?? null},
                { "Status", filter.Status ?? null},
                { "CustomerName", filter.CustomerName ?? null},
                { "CustomerCountry", filter.CustomerCountry ?? null},
                { "CountryRegion", filter.CountryRegion ?? null},
                { "SaleID", filter.SaleID ?? null},
                { "DateFrom", dateFrom ?? null},
                { "DateTo", dateTo ?? null},

            };
            foreach (var kvp in filters)
            {
                queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        private string BuildQueryParams(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            var queryParameters = new List<string>();

            string dateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";
            string dateTo = filter.DateTo.HasValue ? filter.DateTo.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";

            var filters = new Dictionary<string, object>
            {
                { "customerInvoiceID", filter.customerInvoiceID ?? null },
                { "TotalGainedFrom", filter.TotalGainedFrom ?? null },
                { "TotalGainedTo", filter.TotalGainedTo ?? null },
                { "DateFrom", dateFrom?? null },
                { "DateTo", dateTo?? null },
                { "Status", filter.Status ?? null},
                { "CustomerName", filter.CustomerName ?? null},
                { "CustomerCountry", filter.CustomerCountry ?? null},
                { "CountryRegion", filter.CountryRegion ?? null},

            };
            foreach (var kvp in filters)
            {
                queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        private string BuildQueryParams(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            var queryParameters = new List<string>();

            string dateFrom = filter.DateFrom.HasValue ? filter.DateFrom.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";
            string dateTo = filter.DateTo.HasValue ? filter.DateTo.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "";

            var filters = new Dictionary<string, object>
            {
                { "SupplierInvoiceID", filter.SupplierInvoiceID?? null },
                { "TotalSpentFrom", filter.TotalSpentFrom ?? null },
                { "TotalSpentTo", filter.TotalSpentTo ?? null },
                { "DateFrom", dateFrom ?? null },
                { "DateTo", dateTo ?? null},
                { "Status", filter.Status ?? null},
                { "SupplierName", filter.SupplierName ?? null},
                { "SupplierCountry", filter.SupplierCountry ?? null},
                { "CountryRegion", filter.CountryRegion ?? null},
            };
            foreach (var kvp in filters)
            {
                queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<List<ClassifySalesByProfit>> GetClassifySalesByProfit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<ClassifySalesByProfit>(client, "procedure/classify-by-profit", queryString);
            return returnResult;
        }
        public async Task<List<TotalAmountGainedPerCustomerInvoice>> GetTotalAmountGainedPerCustomerInvoice(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<TotalAmountGainedPerCustomerInvoice>(client, "procedure/total-amount-gained-per-customer-invoice", queryString);
            return returnResult;
        }
        public async Task<List<TotalAmountSpentPerSupplierInvoice>> GetTotalAmountSpentPerSupplierInvoice(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<TotalAmountSpentPerSupplierInvoice>(client, "procedure/total-amount-spent-per-supplier-invoice", queryString);
            return returnResult;
        }

    }
}
