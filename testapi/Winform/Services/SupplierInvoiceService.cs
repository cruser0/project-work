using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class SupplierInvoiceService :ICalls<SupplierInvoice>
    {
        public ICollection<SupplierInvoice> GetAll(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI();
            List<string> parameters = new();
            if (filter.SaleID != null)
                parameters.Add($"SaleID={filter.SaleID}");
            if (filter.SupplierID != null)
                parameters.Add($"SupplierID={filter.SupplierID}");
            if (filter.InvoiceDateFrom != null)
                parameters.Add("InvoiceDateFrom=" + filter.InvoiceDateFrom.ToString());
            if (filter.InvoiceDateTo != null)
                parameters.Add("InvoiceDateTo=" + filter.InvoiceDateTo.ToString());
            if (filter.Status != null)
                parameters.Add("Status=" + filter.Status);
            if (filter.page != null)
                parameters.Add($"page={filter.page}");
            string queryString = parameters.Any() ? "?" + string.Join("&", parameters) : string.Empty;

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "supplier-invoice" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierInvoiceDTOGet
                var items = JsonSerializer.Deserialize<List<SupplierInvoice>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<SupplierInvoice>();
        }

        public SupplierInvoice GetById(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"supplier-invoice/{id}").Result;
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
            throw new Exception($"Error getting supplier invoice: {errorMessage}");
        }

        public int Count(SupplierInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI();
            List<string> parameters = new();
            if (filter.SaleID != null)
                parameters.Add($"SaleID={filter.SaleID}");
            if (filter.SupplierID != null)
                parameters.Add($"SupplierID={filter.SupplierID}");
            if (filter.InvoiceDateFrom != null)
                parameters.Add("InvoiceDateFrom=" + filter.InvoiceDateFrom.ToString());
            if (filter.InvoiceDateTo != null)
                parameters.Add("InvoiceDateTo=" + filter.InvoiceDateTo.ToString());
            if (filter.Status != null)
                parameters.Add("Status=" + filter.Status);
            if (filter.page != null)
                parameters.Add($"page={filter.page}");
            string queryString = parameters.Any() ? "?" + string.Join("&", parameters) : string.Empty;

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

            ClientAPI client = new ClientAPI();
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

            ClientAPI client = new ClientAPI();
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
            ClientAPI client = new ClientAPI();
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
