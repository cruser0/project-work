using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Services
{
    internal class CustomerInvoiceAmountPaidService : BaseCallService
    {
        private string BuildQueryParams(CustomerInvoiceAmountPaidFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "PaidCustomerSaleID", filter.PaidCustomerSaleID },
        };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public async Task<ICollection<CustomerInvoiceAmountPaidDTOGet>> GetAllSale(CustomerInvoiceAmountPaidFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetList<CustomerInvoiceAmountPaidDTOGet>(client, "customer-invoice-amount", queryString);
            return returnResult;
        }

        public async Task<CustomerInvoiceAmountPaidDTOGet> PayInvoice(int id, CustomerInvoiceAmountPaidDTOGet entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItem(client, $"customer-invoice-amount/{id}", entity, "Customer Invoice Amount");
            return returnResult;
        }


    }
}
