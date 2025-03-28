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


        public async Task<ICollection<CostRegistry>> GetAll(CostRegistryFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<CostRegistry>(client, "cost-registry", queryString);
            return returnResult;
        }

        public async Task<CostRegistry> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CostRegistry>(client, $"cost-registry/{id}", "CostRegistry");
            return returnResult;
        }

        public async Task<int> Count(CostRegistryFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "cost-registry/count", queryString);
            return reutnResult;
        }

        public async Task<CostRegistry> Create(CostRegistry entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"cost-registry", entity, "CostRegistry");
            return returnRestult;
        }

        public async Task<CostRegistryDTOPut> Update(int id, CostRegistryDTOPut entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"cost-registry/{id}", entity, "CostRegistry");
            return returnResult;
        }

        public async Task<CostRegistry> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<CostRegistry>(client, $"cost-registry/{id}", "CostRegistry");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"cost-registry/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<CostRegistryDTOPut> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"cost-registry/mass-update", newEntity);
            return returnResult;
        }
    }
}
