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
        public async Task<List<ClassifySalesByProfit>> GetClassifySalesByProfit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetList<ClassifySalesByProfit>(client, "procedure/classify-by-profit", queryString);
            return returnResult;
        }

        public async Task<Dictionary<DateTime, decimal>> SaleTemporalTotalRevenue(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<DateTime, decimal>>(client, "procedure/chart/sale-date-decimal", queryString+ "&type=TotalRevenue");
            return returnResult;
        }
        public async Task<Dictionary<DateTime, decimal>> SaleTemporalTotalSpent(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<DateTime, decimal>>(client, "procedure/chart/sale-date-decimal", queryString + "&type=TotalSpent");
            return returnResult;
        }
        public async Task<Dictionary<DateTime, decimal>> SaleTemporalProfit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<DateTime, decimal>>(client, "procedure/chart/sale-date-decimal", queryString + "&type=Profit");
            return returnResult;
        }

        public async Task<Dictionary<string, decimal>> SaleCountryrofit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, decimal>>(client, "procedure/chart/sale-string-decimal", queryString + "&type=Profit");
            return returnResult;
        }
        public async Task<Dictionary<string, decimal>> SaleCountryTotalSpent(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, decimal>>(client, "procedure/chart/sale-string-decimal", queryString + "&type=TotalSpent");
            return returnResult;
        }
        public async Task<Dictionary<string, decimal>> SaleCountryProfit(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, decimal>>(client, "procedure/chart/sale-string-decimal", queryString + "&type=Profit");
            return returnResult;
        }

        public async Task<Dictionary<string, int>> SaleMarginCount(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, int>>(client, "procedure/chart/sale-string-int", queryString + "&type=SaleMargins");
            return returnResult;
        }
        public async Task<Dictionary<string, int>> SaleMStatusCount(ClassifySalesByProfitFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsClassifySalesByProfit(filter);
            var returnResult = await GetItem<Dictionary<string, int>>(client, "procedure/chart/sale-string-int", queryString + "&type=Status");
            return returnResult;
        }


    }
}
