using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class CostRegistryService:BaseCallService
    {
        private string BuildQueryParams(CostRegistryFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "CostRegistryName", filter.CostRegistryName },
                { "CostRegistryCode", filter.CostRegistryCode },
                { "CostRegistryPage", filter.CostRegistryPage },
               


            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }


        public async Task<ICollection<CostRegistryDTOGet>> GetAll(CostRegistryFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<CostRegistryDTOGet>(client, "cost-registry", queryString);
            return returnResult;
        }

        public async Task<CostRegistryDTO> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CostRegistryDTO>(client, $"cost-registry/{id}", "CostRegistry");
            return returnResult;
        }

        public async Task<int> Count(CostRegistryFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "cost-registry/count", queryString);
            return reutnResult;
        }

        public async Task<CostRegistryDTO> Create(CostRegistryDTO entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"cost-registry", entity, "CostRegistry");
            return returnRestult;
        }

        public async Task<CostRegistryDTOGet> Update(int id, CostRegistryDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"cost-registry/{id}", entity, "CostRegistry");
            return returnResult;
        }

        public async Task<CostRegistryDTO> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<CostRegistryDTO>(client, $"cost-registry/{id}", "CostRegistry");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"cost-registry/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<CostRegistryDTOGet> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"cost-registry/mass-update", newEntity);
            return returnResult;
        }
    }
}
