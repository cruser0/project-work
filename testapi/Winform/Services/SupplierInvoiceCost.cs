using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Winform.Services
{
    internal class SupplierInvoiceCost : ICalls<SupplierInvoiceCost>
    {
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
            throw new Exception($"Error deleting supplier invoice cost: {errorMessage}");
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

        public ICollection<SupplierInvoiceCost> GetAll()
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice-cost").Result;
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
            return new SupplierInvoiceCost();
        }

        public SupplierInvoiceCost Update(int id, SupplierInvoiceCost entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplierInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"supplier-invoice-cost/{id}", returnSupplierInvoiceCost).Result;
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
            throw new Exception($"Error deleting supplier invoice cost: {errorMessage}");
        }
    }
}
