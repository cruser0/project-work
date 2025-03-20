
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class SupplierInvoiceCostService : BaseCallService
    {
        private string BuildQueryParams(SupplierInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SupplierInvoiceCostSupplierInvoiceId", filter.SupplierInvoiceCostSupplierInvoiceId },
                { "SupplierInvoiceCostCostFrom", filter.SupplierInvoiceCostCostFrom },
                { "SupplierInvoiceCostCostTo", filter.SupplierInvoiceCostCostTo },
                { "SupplierInvoiceCostQuantity", filter.SupplierInvoiceCostQuantity },
                { "SupplierInvoiceCostName", filter.SupplierInvoiceCostName },
                { "SupplierInvoiceCostPage", filter.SupplierInvoiceCostPage },
                { "SupplierInvoiceCostRegistryCode", filter.SupplierInvoiceCostRegistryCode }
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public async Task<ICollection<SupplierInvoiceCost>> GetAll(SupplierInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnItems = GetList<SupplierInvoiceCost>(client, "supplier-invoice-cost", queryString);
            return await returnItems;
        }

        public async Task<SupplierInvoiceCost> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnItem = GetItem<SupplierInvoiceCost>(client, $"supplier-invoice-cost/{id}", "Supplier Invoice Cost");
            return await returnItem;
        }

        public async Task<int> Count(SupplierInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetCount(client, "supplier-invoice-cost/count", queryString);
            return returnResult;
        }

        public async Task<SupplierInvoiceCost> Create(SupplierInvoiceCost entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = PostItem(client, $"supplier-invoice-cost", entity, "Supplier Invoice Cost");
            return await returnResult;
        }

        public async Task<SupplierInvoiceCost> Update(int id, SupplierInvoiceCost entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = PutItem(client, $"supplier-invoice-cost/{id}", entity, "Supplier Invoice Cost");
            return await returnResult;
        }

        public async Task<SupplierInvoiceCost> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<SupplierInvoiceCost>(client, $"supplier-invoice-cost/{id}", "Supplier Invoice Cost");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"supplier-invoice-cost/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<SupplierInvoiceCost> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"supplier-invoice-cost/mass-update", newEntity);
            return returnResult;
        }
    }
}
