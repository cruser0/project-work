using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Winform.Entities;

namespace Winform.s
{
    internal class CustomerInvoiceService : ICalls<CustomerInvoice>
    {
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
    

        public ICollection<CustomerInvoice> GetAll()
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice").Result;
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
    }
}
