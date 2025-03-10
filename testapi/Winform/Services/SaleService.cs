using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.DTO;

namespace Winform.Services
{
    internal class SaleService : BaseCallService
    {
        private string BuildQueryParams(SaleFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SaleBookingNumber", filter.SaleBookingNumber },
                { "SaleBoLnumber", filter.SaleBoLnumber },
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleRevenueFrom", filter.SaleRevenueFrom },
                { "SaleRevenueTo", filter.SaleRevenueTo },
                { "SaleCustomerId", filter.SaleCustomerId },
                { "SaleStatus", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "SalePage", filter.SalePage }
            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
            return queryString;
        }

        public async Task<ICollection<SaleCustomerDTO>> GetAll(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<SaleCustomerDTO>(client, "sale", queryString);
            return returnResult;
        }

        public async Task<SaleCustomerDTO> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SaleCustomerDTO>(client, $"sale/{id}", "Sale");
            return returnResult;
        }

        public async Task<int> Count(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "sale/count", queryString);
            return reutnResult;
        }

        public async Task<Sale> Create(Sale entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"sale", entity, "Sale");
            return returnRestult;
        }

        public async Task<Sale> Update(int id, Sale entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"sale/{id}", entity, "Sale");
            return returnResult;
        }

        public async Task<Sale> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<Sale>(client, $"sale/{id}", "Sale");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"sale/mass-delete", id);
            return returnResult;
        }
    }
}
