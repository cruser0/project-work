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
                UserAccessInfo.RefreshToken = items.RefreshToken;
                UserAccessInfo.RefreshCreated = items.RefreshCreated;
                UserAccessInfo.RefreshExpires = items.RefreshExpires;
                UserAccessInfo.RefreshTokenID = items.RefreshTokenID;
                UserAccessInfo.RefreshUserID = items.RefreshUserID;
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }

        public async Task RefreshToken()
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = await client.GetClient()
                .PostAsync(client.GetBaseUri() + $"refresh-token?refToken={UserAccessInfo.RefreshToken}", null);
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
                UserAccessInfo.RefreshToken = items.RefreshToken;
                UserAccessInfo.RefreshCreated = items.RefreshCreated;
                UserAccessInfo.RefreshExpires = items.RefreshExpires;
                UserAccessInfo.RefreshTokenID = items.RefreshTokenID;
                UserAccessInfo.RefreshUserID = items.RefreshUserID;
                return;

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
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }




        public string Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().DeleteAsync(client.GetBaseUri() + $"user/delete-user/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting supplier: {errorMessage}");
        }




        public string EditUserRoles(AssignRoleDTO entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnRoles = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"user/assign-roles", returnRoles).Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsStringAsync().Result;
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the login process: {errorMessage}");
        }





        public string Update(int id, UserDTOEdit entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PutAsync(client.GetBaseUri() + $"user/edit-user/{id}", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating User: {errorMessage}");
        }




        private string BuildQueryParams(UserFilter filter)
        {
            var queryParameters = new List<string>();

            var filters = new Dictionary<string, object?>
            {
                { "Name", filter.UserName },
                { "LastName", filter.UserLastName },
                { "page", filter.UserPage },
                { "Email", filter.UserEmail },

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            foreach (var kvp in filter.UserRoles)
            {
                queryParameters.Add($"Roles={kvp}");
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




        public UserRoleDTO GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"user/{id}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<UserRoleDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting User: {errorMessage}");
        }


        public int Count(UserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + "user/count" + queryString).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                int count = JsonSerializer.Deserialize<int>(json);
                return count;


            }
            return 0;
        }

    }
}
