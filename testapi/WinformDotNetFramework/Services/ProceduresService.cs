using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities.Charts;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Procedures;

namespace WinformDotNetFramework.Services
{
    internal class ProceduresService:BaseCallService
    {

        private string BuildQueryParamsClassifySalesByProfit(ClassifySalesByProfitFilter filter)
        {
            var queryParameters = new List<string>();

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
                { "SaleID", filter.SaleID ?? null},

            };
            foreach (var kvp in filters)
            {
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public async Task<SaleListChartDTO> GetClassifySalesByProfit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<SaleListChartDTO>(client, "procedure/classify-by-profit", queryString);
            return returnResult;
        }
        public async Task<Dictionary<string, int>> SalePieChartStatus(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, int>>(client, "procedure/sale-status-chart", queryString);
            return returnResult;
        }
    }
}
