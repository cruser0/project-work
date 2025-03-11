using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class CustomerService : BaseCallService
    {
        private string BuildQueryParams(CustomerFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "CustomerName", filter.CustomerName },
                { "CustomerCountry", filter.CustomerCountry },
                { "CustomerDeprecated", filter.CustomerDeprecated },
                { "CustomerPage", filter.CustomerPage },
                { "CustomerCreatedDateFrom", filter.CustomerCreatedDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty  },
                { "CustomerCreatedDateTo", filter.CustomerCreatedDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "CustomerOriginalID", filter.CustomerOriginalID }

            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }


        public async Task<ICollection<Customer>> GetAll(CustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<Customer>(client, "customer", queryString);
            return returnResult;
        }

        public async Task<Customer> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<Customer>(client, $"customer/{id}", "Customer");
            return returnResult;
        }

        public async Task<int> Count(CustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "customer/count", queryString);
            return reutnResult;
        }

        public async Task<Customer> Create(Customer entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"customer", entity, "Customer");
            return returnRestult;
        }

        public async Task<Customer> Update(int id, Customer entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"customer/{id}", entity, "Customer");
            return returnResult;
        }

        public async Task<Customer> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<Customer>(client, $"customer/{id}", "Customer");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"customer/mass-delete", id);
            return returnResult;
        }
    }
}
