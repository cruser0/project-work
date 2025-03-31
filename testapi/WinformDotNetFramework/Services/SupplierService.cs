
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;

namespace WinformDotNetFramework.Services
{
    internal class SupplierService : BaseCallService
    {
        private string BuildQueryParams(SupplierFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SupplierName", filter.SupplierName },
                { "SupplierCountry", filter.SupplierCountry },
                { "SupplierDeprecated", filter.SupplierDeprecated },
                { "SupplierPage", filter.SupplierPage },
                { "SupplierCreatedDateFrom", filter.SupplierCreatedDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierCreatedDateTo", filter.SupplierCreatedDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty},
                { "SupplierOriginalID", filter.SupplierOriginalID }

            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<ICollection<SupplierDTOGet>> GetAll(SupplierFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<SupplierDTOGet>(client, "supplier", queryString);
            return returnResult;
        }
        public async Task<ICollection<string>> GetAllCountryName(string filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);

            var returnResult = await GetList<string>(client, "supplier/get-all-supplier-name-country", $"?filter={filter}");
            return returnResult;
        }

        public async Task<SupplierDTOGet> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SupplierDTOGet>(client, $"supplier/{id}", "Supplier");
            return returnResult;
        }

        public async Task<int> Count(SupplierFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "supplier/count", queryString);
            return reutnResult;
        }

        public async Task<SupplierDTOGet> Create(SupplierDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"supplier", entity, "Supplier");
            return returnRestult;
        }

        public async Task<SupplierDTOGet> Update(int id, SupplierDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"supplier/{id}", entity, "Supplier");
            return returnResult;
        }

        public async Task<SupplierDTOGet> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<SupplierDTOGet>(client, $"supplier/{id}", "Supplier");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"supplier/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<SupplierDTOGet> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"supplier/mass-update", newEntity);
            return returnResult;
        }
    }
}
