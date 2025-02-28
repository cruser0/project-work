using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;
using Winform.Entities.DTO;

namespace Winform.Services
{
    internal class SupplierInvoiceService : ICalls<SupplierInvoice>
    {
        private string BuildQueryParams(SupplierInvoiceFilter filter)
        {
            List<string> queryParameters = new();

            var filters = new Dictionary<string, object?>
            {
                { "SaleID", filter.SupplierInvoiceSaleID },
                { "SupplierID", filter.SupplierInvoiceSupplierID },
                { "InvoiceDateFrom", filter.SupplierInvoiceInvoiceDateFrom ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "InvoiceDateTo", filter.SupplierInvoiceInvoiceDateTo ?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "InvoiceAmountFrom", filter.SupplierInvoiceInvoiceAmountFrom },
                { "InvoiceAmountTo", filter.SupplierInvoiceInvoiceAmountTo },
                { "Status", filter.SupplierInvoiceStatus?.ToLower() != "all" ? filter.SupplierInvoiceStatus : null },
                { "page", filter.SupplierInvoicePage }

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public ICollection<SupplierInvoiceSupplierDTO> GetAll(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<List<SupplierInvoiceSupplierDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<SupplierInvoiceSupplierDTO>();
        }

        public SupplierInvoiceSupplierDTO GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"supplier-invoice/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceSupplierDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting supplier invoice: {errorMessage}");
        }

        public int Count(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice/count" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

        public SupplierInvoice Create(SupplierInvoice entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplierInvoice = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"supplier-invoice", returnSupplierInvoice).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating supplier invoice: {errorMessage}");
        }

        public SupplierInvoice Update(int id, SupplierInvoice entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupllierInvoice = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"supplier-invoice/{id}", returnSupllierInvoice).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating supplier invoice: {errorMessage}");
        }

        public SupplierInvoice Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"supplier-invoice/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting supplier invoice: {errorMessage}");
        }
    }
}
