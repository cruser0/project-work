using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class CustomerInvoiceService : ICalls<CustomerInvoice>
    {
        public ICollection<CustomerInvoice> GetAll(CustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (filter.SaleId != null)
                queryParameters.Add($"SaleId={filter.SaleId}");
            if (filter.InvoiceAmount != null)
                queryParameters.Add($"InvoiceAmount={filter.InvoiceAmount}");
            if (filter.InvoiceDateFrom != null)
                queryParameters.Add($"InvoiceDateFrom={filter.InvoiceDateFrom}");
            if (filter.InvoiceDateTo != null)
                queryParameters.Add($"InvoiceDateTo={filter.InvoiceDateTo}");
            if (filter.Status != null&&filter.Status.ToLower()!="all")
                queryParameters.Add($"Status={filter.Status}");

            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice"+queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<List<CustomerInvoice>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<CustomerInvoice>();
        }

        public CustomerInvoice GetById(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"customer-invoice/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting customer: {errorMessage}");
        }

        public int Count(CustomerInvoiceFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (filter.SaleId != null)
                queryParameters.Add($"SaleId={filter.SaleId}");
            if (filter.InvoiceAmount != null)
                queryParameters.Add($"InvoiceAmount={filter.InvoiceAmount}");
            if (filter.InvoiceDateFrom != null)
                queryParameters.Add($"InvoiceDateFrom={filter.InvoiceDateFrom}");
            if (filter.InvoiceDateTo != null)
                queryParameters.Add($"InvoiceDateTo={filter.InvoiceDateTo}");
            if (filter.Status != null&&filter.Status.ToLower()!="all")
                queryParameters.Add($"Status={filter.Status}");

            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice/count"+ queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

        public CustomerInvoice Create(CustomerInvoice entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomer = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + "customer-invoice", returnCustomer).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating customer: {errorMessage}");
        }

        public CustomerInvoice Update(int id, CustomerInvoice entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomer = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"customer-invoice/{id}", returnCustomer).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating customer: {errorMessage}");
        }

        public CustomerInvoice Delete(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"customer-invoice/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoice>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting customer: {errorMessage}");
        }
    }
}
