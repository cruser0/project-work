
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Services
{
    internal class SupplierInvoiceService : BaseCallService
    {
        private string BuildQueryParams(SupplierInvoiceFilter filter)
        {
            List<string> queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SupplierInvoiceCode", filter.SupplierInvoiceCode },
                { "SupplierInvoiceSaleBoL", filter.SupplierInvoiceSaleBoL },
                { "SupplierInvoiceSaleBk", filter.SupplierInvoiceSaleBk },
                { "SupplierInvoiceInvoiceDateFrom", filter.SupplierInvoiceInvoiceDateFrom ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierInvoiceInvoiceDateTo", filter.SupplierInvoiceInvoiceDateTo ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierInvoiceInvoiceAmountFrom", filter.SupplierInvoiceInvoiceAmountFrom },
                { "SupplierInvoiceInvoiceAmountTo", filter.SupplierInvoiceInvoiceAmountTo },
                { "SupplierInvoiceStatus", filter.SupplierInvoiceStatus?.ToLower() != "all" ? filter.SupplierInvoiceStatus : null },
                { "SupplierInvoicePage", filter.SupplierInvoicePage },
                {"SupplierInvoiceSupplierName",filter.SupplierInvoiceSupplierName },
                {"SupplierInvoiceSupplierCountry",filter.SupplierInvoiceSupplierCountry }
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public async Task<ICollection<SupplierInvoiceSupplierDTO>> GetAll(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<SupplierInvoiceSupplierDTO>(client, "supplier-invoice", queryString);
            return returnResult;
        }

        public async Task<SupplierInvoiceSupplierDTO> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SupplierInvoiceSupplierDTO>(client, $"supplier-invoice/{id}", "Supplier Invoice");
            return returnResult;
        }

        public async Task<int> Count(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var reutnResult = await GetCount(client, "supplier-invoice/count", queryString);
            return reutnResult;
        }

        public async Task<SupplierInvoice> Create(SupplierInvoice entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnRestult = await PostItem(client, "supplier-invoice", entity, "Supplier Invoice");
            return returnRestult;
        }

        public async Task<SupplierInvoice> Update(int id, SupplierInvoice entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"supplier-invoice/{id}", entity, "Supplier Invoice");
            return returnResult;
        }

        public async Task<SupplierInvoice> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItem<SupplierInvoice>(client, $"supplier-invoice/{id}", "Supplier Invoice");
            return returnResult;
        }
        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"supplier-invoice/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<SupplierInvoice> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"supplier-invoice/mass-update", newEntity);
            return returnResult;
        }
    }
}
