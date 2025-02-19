using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;

namespace Winform.Services
{
    internal class SaleService : ICalls<Sale>
    {
        public ICollection<Sale> GetAll(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (!string.IsNullOrEmpty(filter.BookingNumber))
                queryParameters.Add($"BookingNumber={filter.BookingNumber}");
            if (!string.IsNullOrEmpty(filter.BoLnumber))
                queryParameters.Add($"BoLnumber={filter.BoLnumber}");
            if (filter.SaleDateFrom != null)
                queryParameters.Add($"SaleDateFrom={filter.SaleDateFrom}");
            if (filter.SaleDateTo != null)
                queryParameters.Add($"SaleDateTo={filter.SaleDateTo}");
            if (filter.CustomerId != null)
                queryParameters.Add($"CustomerId={filter.CustomerId}");
            if (!string.IsNullOrEmpty(filter.Status))
                queryParameters.Add($"Status={filter.Status}");
            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;


            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "sale" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<List<Sale>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<Sale>();
        }

        public Sale GetById(int id)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"sale/{id}").Result;
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
            throw new Exception($"Error getting sale: {errorMessage}");
        }

        public int Count(SaleFilter filter)
        {
            ClientAPI client = new ClientAPI();
            var queryParameters = new List<string>();

            if (!string.IsNullOrEmpty(filter.BookingNumber))
                queryParameters.Add($"BookingNumber={filter.BookingNumber}");
            if (!string.IsNullOrEmpty(filter.BoLnumber))
                queryParameters.Add($"BoLnumber={filter.BoLnumber}");
            if (filter.SaleDateFrom != null)
                queryParameters.Add($"SaleDateFrom={filter.SaleDateFrom}");
            if (filter.SaleDateTo != null)
                queryParameters.Add($"SaleDateTo={filter.SaleDateTo}");
            if (filter.CustomerId != null)
                queryParameters.Add($"CustomerId={filter.CustomerId}");
            if (!string.IsNullOrEmpty(filter.Status))
                queryParameters.Add($"Status={filter.Status}");
            if (filter.page != null)
                queryParameters.Add($"page={filter.page}");
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;


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

            ClientAPI client = new ClientAPI();
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

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"sale/{id}", returnSale).Result;
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
            ClientAPI client = new ClientAPI();
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
