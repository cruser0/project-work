using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class SupplierService : ICalls<Supplier>
    {
        public Supplier Create(Supplier entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplier = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"supplier", returnSupplier).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<Supplier>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating supplier: {errorMessage}");
        }

        public Supplier Delete(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"supplier/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<Supplier>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting supplier: {errorMessage}");
        }

        public ICollection<Supplier> GetAll(SupplierFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (!string.IsNullOrEmpty(filter.Name))
                queryParameters.Add($"Name={filter.Name}");
            if (!string.IsNullOrEmpty(filter.Country))
                queryParameters.Add($"Country={filter.Country}");
            if (filter.Deprecated != null)
                queryParameters.Add($"Deprecated={filter.Deprecated}");

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<List<Supplier>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<Supplier>();
        }

        public Supplier GetById(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"supplier/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<Supplier>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting supplier: {errorMessage}");
        }

        public Supplier Update(int id, Supplier entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplier = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"supplier/{id}", returnSupplier).Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;

                var items = JsonSerializer.Deserialize<Supplier>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating supplier: {errorMessage}");
        }
    }
}
