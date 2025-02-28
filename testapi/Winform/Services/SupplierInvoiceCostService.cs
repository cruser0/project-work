using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class SupplierInvoiceCostService : ICalls<SupplierInvoiceCost>
    {
        private string BuildQueryParams(SupplierInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "SupplierInvoiceId", filter.SupplierInvoiceCostSupplierInvoiceId },
                { "CostFrom", filter.SupplierInvoiceCostCostFrom },
                { "CostTo", filter.SupplierInvoiceCostCostTo },
                { "Quantity", filter.SupplierInvoiceCostQuantity },
                { "Name", filter.SupplierInvoiceCostName },
                { "page", filter.SupplierInvoiceCostPage }
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public ICollection<SupplierInvoiceCost> GetAll(SupplierInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice-cost" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<List<SupplierInvoiceCost>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<SupplierInvoiceCost>();
        }

        public SupplierInvoiceCost GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"supplier-invoice-cost/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting supplier invoice-cost: {errorMessage}");
        }

        public int Count(SupplierInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice-cost/count" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

        public SupplierInvoiceCost Create(SupplierInvoiceCost entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplierInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"supplier-invoice-cost", returnSupplierInvoiceCost).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating supplier invoice cost: {errorMessage}");
        }

        public SupplierInvoiceCost Update(int id, SupplierInvoiceCost entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplierInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"supplier-invoice-cost/{id}", returnSupplierInvoiceCost).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating supplier invoice cost: {errorMessage}");
        }

        public SupplierInvoiceCost Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"supplier-invoice-cost/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting supplier invoice-cost: {errorMessage}");
        }
    }
}
