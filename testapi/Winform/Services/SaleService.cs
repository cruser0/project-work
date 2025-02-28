using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;
using Winform.Entities.DTO;

namespace Winform.Services
{
    internal class SaleService : ICalls<Sale>
    {
        private string BuildQueryParams(SaleFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "BookingNumber", filter.SaleBookingNumber },
                { "BoLnumber", filter.SaleBoLnumber },
                { "SaleDateFrom", filter.SaleDateFrom?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "SaleDateTo", filter.SaleDateTo?.ToString("yyyy-MM-ddTHH:mm:ss") ?? string.Empty },
                { "RevenueFrom", filter.SaleRevenueFrom },
                { "RevenueTo", filter.SaleRevenueTo },
                { "CustomerId", filter.SaleCustomerId },
                { "Status", filter.SaleStatus?.ToLower() != "all" ? filter.SaleStatus : null },
                { "page", filter.SalePage }
            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public ICollection<SaleCustomerDTO> GetAll(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);


            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "sale" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<List<SaleCustomerDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<SaleCustomerDTO>();
        }

        public SaleCustomerDTO GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"sale/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SaleCustomerDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting sale: {errorMessage}");
        }

        public int Count(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);


            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "sale/count" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

        public Sale Create(Sale entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"sale", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<Sale>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error creating sale: {errorMessage}");
        }

        public Sale Update(int id, Sale entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"sale/{id}", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<Sale>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating sale: {errorMessage}");
        }

        public Sale Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"sale/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<Sale>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting sale: {errorMessage}");
        }
    }
}
