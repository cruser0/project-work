
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class CustomerInvoiceCostService : BaseCallService
    {

        private string BuildQueryParams(CustomerInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "CustomerInvoiceCostCustomerInvoiceId", filter.CustomerInvoiceCostCustomerInvoiceId },
                { "CustomerInvoiceCostCostFrom", filter.CustomerInvoiceCostCostFrom },
                { "CustomerInvoiceCostCostTo", filter.CustomerInvoiceCostCostTo },
                { "CustomerInvoiceCostQuantity", filter.CustomerInvoiceCostQuantity },
                { "CustomerInvoiceCostPage", filter.CustomerInvoiceCostPage },
                { "CustomerInvoiceCostName", filter.CustomerInvoiceCostName },
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<ICollection<CustomerInvoiceCost>> GetAll(CustomerInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnItems = GetList<CustomerInvoiceCost>(client, "customer-invoice-cost", queryString);
            return await returnItems;
        }

        public async Task<CustomerInvoiceCost> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnItem = GetItem<CustomerInvoiceCost>(client, $"customer-invoice-cost/{id}", "Customer Invoice Cost");
            return await returnItem;
        }

        public async Task<int> Count(CustomerInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetCount(client, "customer-invoice-cost/count", queryString);
            return returnResult;
        }

        public async Task<CustomerInvoiceCost> Create(CustomerInvoiceCost entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = PostItem(client, $"customer-invoice-cost", entity, "Customer Invoice Cost");
            return await returnResult;
        }

        public async Task<CustomerInvoiceCost> Update(int id, CustomerInvoiceCost entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = PutItem(client, $"customer-invoice-cost/{id}", entity, "Customer Invoice Cost");
            return await returnResult;
        }

        public async Task<CustomerInvoiceCost> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<CustomerInvoiceCost>(client, $"customer-invoice-cost/{id}", "Customer Invoice Cost");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"customer-invoice-cost/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<CustomerInvoiceCost> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"customer-invoice-cost/mass-update", newEntity);
            return returnResult;
        }
    }
}
