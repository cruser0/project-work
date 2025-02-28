using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class CustomerInvoiceCostService : ICalls<CustomerInvoiceCost>
    {

        private string BuildQueryParams(CustomerInvoiceCostFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "CustomerInvoiceId", filter.CustomerInvoiceCostCustomerInvoiceId },
                { "CostFrom", filter.CustomerInvoiceCostCostFrom },
                { "CostTo", filter.CustomerInvoiceCostCostTo },
                { "Quantity", filter.CustomerInvoiceCostQuantity },
                { "page", filter.CustomerInvoiceCostPage },
                { "Name", filter.CustomerInvoiceCostName },
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }


            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }

        public ICollection<CustomerInvoiceCost> GetAll(CustomerInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice-cost" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<List<CustomerInvoiceCost>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<CustomerInvoiceCost>();
        }

        public CustomerInvoiceCost GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"customer-invoice-cost/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting customer invoice-cost: {errorMessage}");
        }

        public int Count(CustomerInvoiceCostFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "customer-invoice-cost/count" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

        public CustomerInvoiceCost Create(CustomerInvoiceCost entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomerInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"customer-invoice-cost", returnCustomerInvoiceCost).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating customer invoice cost: {errorMessage}");
        }

        public CustomerInvoiceCost Update(int id, CustomerInvoiceCost entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomerInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"customer-invoice-cost/{id}", returnCustomerInvoiceCost).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating customer invoice cost: {errorMessage}");
        }

        public CustomerInvoiceCost Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"customer-invoice-cost/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCost>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting customer invoice-cost: {errorMessage}");
        }
    }
}
