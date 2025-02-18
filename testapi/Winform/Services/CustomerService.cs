using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class CustomerService : ICalls<Customer>
    {
        public Customer Create(Customer entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomer = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"customer", returnCustomer).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<Customer>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating customer: {errorMessage}");
        }

        public Customer Delete(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"customer/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<Customer>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting customer: {errorMessage}");
        }

        public ICollection<Customer> GetAll(CustomerFilter filter)
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
            string vediamo = "/customer" + queryString;
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer" + queryString).Result;

            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<List<Customer>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<Customer>();
        }



        public Customer GetById(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"customer/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerDTOGet
                var items = JsonSerializer.Deserialize<Customer>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting customer: {errorMessage}");
        }

        public Customer Update(int id, Customer entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomer = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"customer/{id}", returnCustomer).Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;

                var items = JsonSerializer.Deserialize<Customer>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating customer: {errorMessage}");
        }
    }
}
