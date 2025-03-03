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

        private string BuildQueryParamsSupplier(SupplierFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SupplierName", filter.SupplierName??string.Empty },
                { "SupplierCountry", filter.SupplierCountry??string.Empty },
                { "SupplierDeprecated", filter.SupplierDeprecated??null },
                { "SupplierPage", filter.SupplierPage??null },
                { "SupplierCreatedDateFrom", filter.SupplierCreatedDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierCreatedDateTo", filter.SupplierCreatedDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty},
                { "SupplierOriginalID", filter.SupplierOriginalID??null }

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsSupplierInvoice(SupplierInvoiceFilter filter)
        {
            List<string> queryParameters = new();

            var filters = new Dictionary<string, object?>
            {
                { "SupplierInvoiceSaleID", filter.SupplierInvoiceSaleID??null },
                { "SupplierInvoiceSupplierID", filter.SupplierInvoiceSupplierID??null },
                { "SupplierInvoiceInvoiceDateFrom", filter.SupplierInvoiceInvoiceDateFrom ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierInvoiceInvoiceDateTo", filter.SupplierInvoiceInvoiceDateTo ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SupplierInvoiceInvoiceAmountFrom", filter.SupplierInvoiceInvoiceAmountFrom??null },
                { "SupplierInvoiceInvoiceAmountTo", filter.SupplierInvoiceInvoiceAmountTo??null },
                { "SupplierInvoiceStatus", filter.SupplierInvoiceStatus?.ToLower() != "all" ? filter.SupplierInvoiceStatus : string.Empty },
                { "SupplierInvoicePage", filter.SupplierInvoicePage??null }

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        private string BuildQueryParamsSupplierInvoiceCosts(SupplierInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SupplierInvoiceCostSupplierInvoiceId", filter.SupplierInvoiceCostSupplierInvoiceId??null },
                { "SupplierInvoiceCostCostFrom", filter.SupplierInvoiceCostCostFrom??null },
                { "SupplierInvoiceCostCostTo", filter.SupplierInvoiceCostCostTo??null },
                { "SupplierInvoiceCostQuantity", filter.SupplierInvoiceCostQuantity??null },
                { "SupplierInvoiceCostName", filter.SupplierInvoiceCostName??string.Empty },
                { "SupplierInvoiceCostPage", filter.SupplierInvoiceCostPage??null }
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


            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "Values/customers" + queryString).Result;
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

        public supplierGroupDTO GetSupplierTables(SupplierFilter sfilter, SupplierInvoiceFilter sifilter, SupplierInvoiceCostFilter sicfilter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString1 = BuildQueryParamsSupplier(sfilter);
            string queryString2 = BuildQueryParamsSupplierInvoice(sifilter);
            string queryString3 = BuildQueryParamsSupplierInvoiceCosts(sicfilter);


            string queryString = queryString1 + "&" + queryString2 + "&" + queryString3;
            if (queryString.Length > 0) queryString = "?" + queryString;

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "Values/suppliers" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<supplierGroupDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new supplierGroupDTO();
        }
    }
}
