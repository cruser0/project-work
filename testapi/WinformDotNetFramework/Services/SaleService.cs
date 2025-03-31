

using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WinformDotNetFramework.Services
{
    internal class SaleService : BaseCallService
    {
        private string BuildQueryParams(SaleCustomerFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SaleBookingNumber", filter.SaleBookingNumber },
                { "SaleBoLnumber", filter.SaleBoLnumber },
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleRevenueFrom", filter.SaleRevenueFrom },
                { "SaleRevenueTo", filter.SaleRevenueTo },
                { "SaleStatus", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "SalePage", filter.SalePage },
                { "SaleCustomerName", filter.SaleCustomerName },
                { "SaleCustomerCountry", filter.SaleCustomerCountry },
            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
            return queryString;
        }

        public async Task<ICollection<SaleCustomerDTO>> GetAll(SaleCustomerFilter filter)
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

        public async Task<int> Count(SaleCustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "sale/count", queryString);
            return reutnResult;
        }

        public async Task<SaleDTOGet> Create(SaleDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"sale", entity, "Sale");
            return returnRestult;
        }

        public async Task<SaleDTOGet> Update(int id, SaleDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"sale/{id}", entity, "Sale");
            return returnResult;
        }

        public async Task<SaleDTOGet> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<SaleDTOGet>(client, $"sale/{id}", "Sale");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"sale/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<SaleDTOGet> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"sale/mass-update", newEntity);
            return returnResult;
        }
    }
}
