using API.Models.Filters;
using System.Text.Json;
using Winform.Entities;


//http://localhost:5069/api/Values/customer-invoice-costs

namespace Winform.Services
{
    internal class ValueService
    {
        private string BuildQueryParamsCustomer(CustomerFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "CustomerName", filter.CustomerName },
                { "CustomerCountry", filter.CustomerCountry },
                { "CustomerDeprecated", filter.CustomerDeprecated },
                { "CustomerPage", filter.CustomerPage },
                { "CustomerCreatedDateFrom", filter.CustomerCreatedDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty  },
                { "CustomerCreatedDateTo", filter.CustomerCreatedDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty }

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsSale(SaleFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SaleBookingNumber", filter.SaleBookingNumber },
                { "SaleBoLnumber", filter.SaleBoLnumber },
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleRevenueFrom", filter.SaleRevenueFrom },
                { "SaleRevenueTo", filter.SaleRevenueTo },
                { "SaleCustomerId", filter.SaleCustomerId },
                { "SaleStatus", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "SalePage", filter.SalePage }
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsCustomerInvoice(CustomerInvoiceFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "CustomerInvoiceSaleId", filter.CustomerInvoiceSaleId },
                { "CustomerInvoiceInvoiceAmountFrom", filter.CustomerInvoiceInvoiceAmountFrom },
                { "CustomerInvoiceInvoiceAmountTo", filter.CustomerInvoiceInvoiceAmountTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "CustomerInvoiceInvoiceDateFrom", filter.CustomerInvoiceInvoiceDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty  },
                { "CustomerInvoiceInvoiceDateTo", filter.CustomerInvoiceInvoiceDateTo },
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

        private string BuildQueryParamsCustomerInvoiceCost(CustomerInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
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

        public ICollection<Customer> GetCustomers(CustomerFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsCustomer(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer" + queryString).Result;

            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<List<Customer>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<Customer>();
        }

        public ICollection<CustomerInvoice> GetCustomerInvoices(CustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParamsCustomerInvoice(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<List<CustomerInvoice>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<CustomerInvoice>();
        }
    }
}
