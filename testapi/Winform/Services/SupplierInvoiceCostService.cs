using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class SupplierInvoiceCostService :ICalls<SupplierInvoiceCost>
    {
        public ICollection<SupplierInvoiceCost> GetAll(SupplierInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (filter.SupplierInvoiceId != null)
                queryParameters.Add($"SupplierInvoiceId={filter.SupplierInvoiceId}");

            if (filter.Cost != null)
                queryParameters.Add($"Cost={filter.Cost}");

            if (filter.Quantity != null)
                queryParameters.Add($"Quantity={filter.Quantity}");

            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
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
            ClientAPI client = new ClientAPI();
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
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (filter.SupplierInvoiceId != null)
                queryParameters.Add($"SupplierInvoiceId={filter.SupplierInvoiceId}");

            if (filter.Cost != null)
                queryParameters.Add($"Cost={filter.Cost}");

            if (filter.Quantity != null)
                queryParameters.Add($"Quantity={filter.Quantity}");

            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
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

            ClientAPI client = new ClientAPI();
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

            ClientAPI client = new ClientAPI();
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
            ClientAPI client = new ClientAPI();
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
