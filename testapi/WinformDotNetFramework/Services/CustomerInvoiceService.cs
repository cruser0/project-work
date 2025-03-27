using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class CustomerInvoiceService : BaseCallService
    {
        private string BuildQueryParams(CustomerInvoiceFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "CustomerInvoiceSaleID", filter.CustomerInvoiceSaleID },
                { "CustomerInvoiceSaleBoL", filter.CustomerInvoiceSaleBoL },
                { "CustomerInvoiceSaleBk", filter.CustomerInvoiceSaleBk },
                { "CustomerInvoiceCode", filter.CustomerInvoiceCode },
                { "CustomerInvoiceInvoiceAmountFrom", filter.CustomerInvoiceInvoiceAmountFrom },
                { "CustomerInvoiceInvoiceAmountTo", filter.CustomerInvoiceInvoiceAmountTo },
                { "CustomerInvoiceInvoiceDateFrom", filter.CustomerInvoiceInvoiceDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty  },
                { "CustomerInvoiceInvoiceDateTo", filter.CustomerInvoiceInvoiceDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "CustomerInvoiceStatus", filter.CustomerInvoiceStatus?.ToLower() != "all" ? filter.CustomerInvoiceStatus : null },
                { "CustomerInvoicePage", filter.CustomerInvoicePage }
        };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }


        public async Task<ICollection<CustomerInvoice>> GetAll(CustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<CustomerInvoice>(client, "customer-invoice", queryString);
            return returnResult;
        }

        public async Task<CustomerInvoiceSummary> GetSummary(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerInvoiceSummary>(client, $"customer-invoice/customer-invoice-summary/{id}", "Customer Invoice Summary");
            return returnResult;
        }

        public async Task<CustomerInvoice> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerInvoice>(client, $"customer-invoice/{id}", "Customer Invoice");
            return returnResult;
        }

        public async Task<int> Count(CustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "customer-invoice/count", queryString);
            return reutnResult;
        }

        public async Task<CustomerInvoice> Create(CustomerInvoice entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, "customer-invoice", entity, "Customer Invoice");
            return returnRestult;
        }

        public async Task<CustomerInvoice> Update(int id, CustomerInvoice entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"customer-invoice/{id}", entity, "Customer Invoice");
            return returnResult;
        }

        public async Task<CustomerInvoice> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<CustomerInvoice>(client, $"customer-invoice/{id}", "Customer Invoice");
            return returnResult;
        }

        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"customer-invoice/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<CustomerInvoice> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"customer-invoice/mass-update", newEntity);
            return returnResult;
        }
    }
}
