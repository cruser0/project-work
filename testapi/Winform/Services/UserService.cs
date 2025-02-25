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
    }
}
