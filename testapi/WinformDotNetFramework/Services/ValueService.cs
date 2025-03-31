
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//http://localhost:5069/api/Values/customer-invoice-costs

namespace WinformDotNetFramework.Services
{
    internal class ValueService : BaseCallService
    {
        private string BuildQueryParamsCustomer(CustomerFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
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

        private string BuildQueryParamsSale(SaleCustomerFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SaleBookingNumber", filter.SaleBookingNumber??null },
                { "SaleBoLnumber", filter.SaleBoLnumber ??null},
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ??null },
                { "SaleRevenueFrom", filter.SaleRevenueFrom ??null},
                { "SaleRevenueTo", filter.SaleRevenueTo ??null},
                { "SaleStatus", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "SalePage", filter.SalePage ??null},
                { "SaleCustomerName", filter.SaleCustomerName },
                { "SaleCustomerCountry", filter.SaleCustomerCountry },
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

            var filters = new Dictionary<string, object>
            {
                { "CustomerInvoiceSaleBk", filter.CustomerInvoiceSaleBk ??null},
                { "CustomerInvoiceSaleBoL", filter.CustomerInvoiceSaleBoL ??null},
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

            var filters = new Dictionary<string, object>
            {
                { "CustomerInvoiceCostCustomerInvoiceCode", filter.CustomerInvoiceCostCustomerInvoiceCode??null },
                { "CustomerInvoiceCostCostFrom", filter.CustomerInvoiceCostCostFrom??null },
                { "CustomerInvoiceCostCostTo", filter.CustomerInvoiceCostCostTo ??null},
                { "CustomerInvoiceCostQuantity", filter.CustomerInvoiceCostQuantity??null },
                { "CustomerInvoiceCostPage", filter.CustomerInvoiceCostPage??null },
                { "CustomerInvoiceCostName", filter.CustomerInvoiceCostName ??null},
                { "RegistryCode", filter.RegistryCode ??null},
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

            var filters = new Dictionary<string, object>
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

        private string BuildQueryParamsSupplierInvoice(SupplierInvoiceSupplierFilter filter)
        {
            List<string> queryParameters = new List<string>();

            var filters = new Dictionary<string, object>
            {
                { "SupplierInvoiceSaleBk", filter.SupplierInvoiceSaleBk??null },
                { "SupplierInvoiceSaleBoL", filter.SupplierInvoiceSaleBoL??null },
                { "SupplierInvoiceSupplierName", filter.SupplierInvoiceSupplierName??null },
                { "SupplierInvoiceSupplierCountry", filter.SupplierInvoiceSupplierCountry??null },
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

            var filters = new Dictionary<string, object>
            {
                { "SupplierInvoiceCostSupplierInvoiceCode", filter.SupplierInvoiceCostSupplierInvoiceCode??null },
                { "SupplierInvoiceCostCostFrom", filter.SupplierInvoiceCostCostFrom??null },
                { "SupplierInvoiceCostCostTo", filter.SupplierInvoiceCostCostTo??null },
                { "SupplierInvoiceCostQuantity", filter.SupplierInvoiceCostQuantity??null },
                { "SupplierInvoiceCostName", filter.SupplierInvoiceCostName??string.Empty },
                { "SupplierInvoiceCostRegistryCode", filter.SupplierInvoiceCostRegistryCode??string.Empty },
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

        public async Task<CustomerGroupDTO> GetTables(CustomerFilter cfilter, SaleCustomerFilter sfilter, CustomerInvoiceFilter cifilter, CustomerInvoiceCostFilter cicfilter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString1 = BuildQueryParamsCustomer(cfilter);
            string queryString2 = BuildQueryParamsSale(sfilter);
            string queryString3 = BuildQueryParamsCustomerInvoice(cifilter);
            string queryString4 = BuildQueryParamsCustomerInvoiceCost(cicfilter);
            string queryString = queryString1 + "&" + queryString2 + "&" + queryString3 + "&" + queryString4;
            if (queryString.Length > 0) queryString = "?" + queryString;


            var returnResult = await GetItem<CustomerGroupDTO>(client, "Values/customers" + queryString, "Customer Tables");
            return returnResult;
        }

        public async Task<SupplierGroupDTO> GetSupplierTables(SupplierFilter sfilter, SupplierInvoiceSupplierFilter sifilter, SupplierInvoiceCostFilter sicfilter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString1 = BuildQueryParamsSupplier(sfilter);
            string queryString2 = BuildQueryParamsSupplierInvoice(sifilter);
            string queryString3 = BuildQueryParamsSupplierInvoiceCosts(sicfilter);


            string queryString = queryString1 + "&" + queryString2 + "&" + queryString3;
            if (queryString.Length > 0) queryString = "?" + queryString;

            var returnResult = await GetItem<SupplierGroupDTO>(client, "Values/suppliers" + queryString, "Supplier Tables");
            return returnResult;
        }
    }
}
