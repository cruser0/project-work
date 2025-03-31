using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                { "CustomerOriginalID", filter.CustomerOriginalID },


            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<ICollection<string>> GetAllCountryName(string filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);

            var returnResult = await GetList<string>(client, "customer/get-all-customer-name-country", $"?filter={filter}");
            return returnResult;
        }
        public async Task<ICollection<CustomerDTOGet>> GetAll(CustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<CustomerDTOGet>(client, "customer", queryString);
            return returnResult;
        }

        public async Task<CustomerDTOGet> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerDTOGet>(client, $"customer/{id}", "Customer");
            return returnResult;
        }

        public async Task<int> Count(CustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "customer/count", queryString);
            return reutnResult;
        }

        public async Task<CustomerDTOGet> Create(CustomerDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, $"customer", entity, "Customer");
            return returnRestult;
        }

        public async Task<CustomerDTOGet> Update(int id, CustomerDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"customer/{id}", entity, "Customer");
            return returnResult;
        }

        public async Task<CustomerDTOGet> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<CustomerDTOGet>(client, $"customer/{id}", "Customer");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"customer/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<CustomerDTOGet> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"customer/mass-update", newEntity);
            return returnResult;
        }
    }
}
