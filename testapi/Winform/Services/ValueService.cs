using API.Models.Filters;
using System.Text.Json;
using Winform.Entities.DTO;


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
                { "CustomerName", filter.CustomerName??null },
                { "CustomerCountry", filter.CustomerCountry??null },
                { "CustomerDeprecated", filter.CustomerDeprecated??null },
                { "CustomerPage", filter.CustomerPage??null },
                { "CustomerCreatedDateFrom", filter.CustomerCreatedDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "CustomerCreatedDateTo", filter.CustomerCreatedDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ??null }

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsSale(SaleFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SaleBookingNumber", filter.SaleBookingNumber??null },
                { "SaleBoLnumber", filter.SaleBoLnumber ??null},
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "SaleRevenueFrom", filter.SaleRevenueFrom ??null},
                { "SaleRevenueTo", filter.SaleRevenueTo ??null},
                { "SaleCustomerId", filter.SaleCustomerId ??null},
                { "SaleStatus", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "SalePage", filter.SalePage ??null}
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsCustomerInvoice(CustomerInvoiceFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "CustomerInvoiceSaleId", filter.CustomerInvoiceSaleId ??null},
                { "CustomerInvoiceInvoiceAmountFrom", filter.CustomerInvoiceInvoiceAmountFrom ??null},
                { "CustomerInvoiceInvoiceAmountTo", filter.CustomerInvoiceInvoiceAmountTo?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "CustomerInvoiceInvoiceDateFrom", filter.CustomerInvoiceInvoiceDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "CustomerInvoiceInvoiceDateTo", filter.CustomerInvoiceInvoiceDateTo ??null},
                { "CustomerInvoiceStatus", filter.CustomerInvoiceStatus?.ToLower() != "all" ? filter.CustomerInvoiceStatus : null },
                { "CustomerInvoicePage", filter.CustomerInvoicePage ??null}
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }


            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsCustomerInvoiceCost(CustomerInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "CustomerInvoiceCostCustomerInvoiceId", filter.CustomerInvoiceCostCustomerInvoiceId??null },
                { "CustomerInvoiceCostCostFrom", filter.CustomerInvoiceCostCostFrom??null },
                { "CustomerInvoiceCostCostTo", filter.CustomerInvoiceCostCostTo ??null},
                { "CustomerInvoiceCostQuantity", filter.CustomerInvoiceCostQuantity??null },
                { "CustomerInvoiceCostPage", filter.CustomerInvoiceCostPage??null },
                { "CustomerInvoiceCostName", filter.CustomerInvoiceCostName ??null},
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }


            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }


        public testDTO GetTables(CustomerFilter cfilter, SaleFilter sfilter, CustomerInvoiceFilter cifilter, CustomerInvoiceCostFilter cicfilter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString1 = BuildQueryParamsCustomer(cfilter);
            string queryString2 = BuildQueryParamsSale(sfilter);
            string queryString3 = BuildQueryParamsCustomerInvoice(cifilter);
            string queryString4 = BuildQueryParamsCustomerInvoiceCost(cicfilter);

            string queryString = queryString1 + "&" + queryString2 + "&" + queryString3 + "&" + queryString4;
            if (queryString.Length > 0) queryString = "?" + queryString;


            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "Values" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<testDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new testDTO();
        }
    }
}
