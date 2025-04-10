using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Services
{
    internal class CustomerUserService : BaseCallService
    {

        private string BuildQueryParams(CustomerUserFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "CustomerUserName", filter.CustomerUserName },
                { "CustomerUserLastName", filter.CustomerUserLastName },
                { "CustomerName", filter.CustomerName },
                { "CustomerCountry", filter.CustomerCountry },
                { "CustomerUserEmail", filter.CustomerUserEmail },
                { "CustomerUserRole", filter.CustomerUserRole },
                { "CustomerUserPage", filter.CustomerUserPage },

            };
            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<ICollection<CustomerUserRoleDTO>> GetAll(CustomerUserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<CustomerUserRoleDTO>(client, "customer-user/get-all-customer-users", queryString);
            return returnResult;
        }

        public async Task<CustomerUserRoleDTO> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerUserRoleDTO>(client, $"customer-user/{id}", "CostRegistry");
            return returnResult;
        }

        public async Task<string> Register(CustomerUserDTOCreate user)
        {
            ClientAPI client = new ClientAPI();
            var reuturnResult = await PostRegister(client, $"register-web", user, "Customer User");
            return reuturnResult;
        }

    }
}
