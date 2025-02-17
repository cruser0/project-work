using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Winform.Entities;

namespace Winform.Services
{
    internal class SupplierInvoiceService : ICalls<SupplierInvoice>
    {
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

        public ICollection<SupplierInvoice> GetAll(string? saleID,string? supplierID,DateTime? date,string? status)
        {
            ClientAPI client = new ClientAPI();
            List<string> parameters = new();
            if (!string.IsNullOrEmpty(saleID))
                parameters.Add("SaleID="+saleID);
            if (!string.IsNullOrEmpty(supplierID))
                parameters.Add("SupplierID="+supplierID.ToString());
            if(date != null)
                parameters.Add("InvoiceDate="+date.ToString());
            if(status != null)
                parameters.Add("Status="+status);
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

        public SupplierInvoice Update(int id, SupplierInvoice entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSupplierInvoice = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"supplier-invoice/{id}", returnSupplierInvoice).Result;
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
    }
}
