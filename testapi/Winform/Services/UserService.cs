using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;
using Winform.Entities.DTO;

namespace Winform.Services
{
    internal class UserService
    {
        public string Register(UserDTOCreate user)
        {
            string jsonContent = JsonSerializer.Serialize(user);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"register", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the registration of the User: {errorMessage}");
        }
        public UserAccessTemp Login(UserDTO entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnCustomerInvoiceCost = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"login", returnCustomerInvoiceCost).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<UserAccessTemp>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                UserAccessInfo.Email = items.Email;
                UserAccessInfo.Name = items.Name;
                UserAccessInfo.Token = items.Token;
                UserAccessInfo.LastName = items.LastName;
                UserAccessInfo.Role = items.Role;
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }

        public string AssignRoles(AssignRoleDTO entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnRoles = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"/assign-roles", returnRoles).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<string>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }

        public Supplier Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"user/delete-user/{id}").Result;
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
        public string EditUser(AssignRoleDTO entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnRoles = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"user/assign-roles", returnRoles).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti CustomerInvoiceCostDTOGet
                var items = JsonSerializer.Deserialize<string>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }
        public string Update(int id, UserDTOCreate entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"user/edit-user/{id}", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;

                var items = JsonSerializer.Deserialize<string>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating supplier: {errorMessage}");
        }
        private string BuildQueryParams(UserFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "UserID", filter.UserID },
                { "Name", filter.Name },
                { "LastName", filter.LastName },
                { "page", filter.page },
                { "Email", filter.Email },

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }

            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;

            return queryString;
        }
        public ICollection<UserRoleDTO> GetAll(UserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "user/get-all-users" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<List<UserRoleDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<UserRoleDTO>();
        }
    }
}
