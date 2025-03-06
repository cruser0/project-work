using API.Models.Filters;
using System.Text;
using System.Text.Json;
using Winform.Entities;
using Winform.Entities.DTO;
using Winform.Entities.Preference;

namespace Winform.Services
{
    internal class UserService:BaseCallService
    {
        public async Task<string> Register(UserDTOCreate user)
        {
            ClientAPI client = new ClientAPI();
            var reuturnResult = await PostRegister(client, $"register", user, "User");
            return reuturnResult;
        }



        public async Task<UserAccessTemp> Login(UserDTO entity)
        {
            ClientAPI client = new ClientAPI();
            var reuturnResult = await PostLogin(client, $"login", entity, "User");
            return reuturnResult;
        }

        public async Task RefreshToken()
        {
            ClientAPI client = new ClientAPI();
            string token = Uri.EscapeDataString(UserAccessInfo.RefreshToken);
            await PostRefreshToken(client, $"refresh-token?refToken={token}", "Token");

        }



        public async Task<string> AssignRoles(AssignRoleDTO entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItemWithStringReturn(client, $"/assign-roles", entity, "Roles");
            return returnResult;
        }


        public async Task<string> Delete(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await DeleteItemWithReturnString(client, $"user/delete-user/{id}", "User");
            return returnResult;
        }




        public async Task<string> EditUserRoles(AssignRoleDTO entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItemWithStringReturn(client, $"user/assign-roles", entity, "Roles");
            return returnResult;
        }





        public async Task<string> Update(int id, UserDTOEdit entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PutItemWithStringReturn(client, $"user/edit-user/{id}", entity, "Roles");
            return returnResult;
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




        public async Task<ICollection<UserRoleDTO>> GetAll(UserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);

            var returnResult = await GetList<UserRoleDTO>(client, "user/get-all-users", queryString);
            return returnResult;
        }




        public async Task<UserRoleDTO> GetById(int id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<UserRoleDTO>(client, $"user/{id}","User");
            return returnResult;
        }


        public async Task<int> Count(UserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetCount(client, "user/count", queryString);
            return returnResult;
        }







        public CustomerDGV GetCustomerDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/customerdgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<CustomerDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Customer DGV Preferences: {errorMessage}");
        }

        public CustomerInvoiceDGV GetCustomerInvoiceDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/customer-invoicedgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Customer Invoice DGV Preferences: {errorMessage}");
        }

        public CustomerInvoiceCostDGV GetCustomerInvoiceCostDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/customer-invoice-costdgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCostDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Customer Invoice Cost DGV Preferences: {errorMessage}");
        }



        public SupplierDGV GetSupplierDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/supplierdgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<SupplierDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Supplier DGV Preferences: {errorMessage}");
        }

        public SupplierInvoiceDGV GetSupplierInvoiceDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/supplier-invoicedgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Supplier Invoice DGV Preferences: {errorMessage}");
        }

        public SupplierInvoiceCostDGV GetSupplierInvoiceCostDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/supplier-invoice-costdgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCostDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Supplier Invoice Cost DGV Preferences: {errorMessage}");
        }

        public SaleDGV GetSaleDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/saledgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SaleDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting Sale DGV Preferences: {errorMessage}");
        }
        public UserDGV GetUserDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/userdgv/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti UserDTOGet
                var items = JsonSerializer.Deserialize<UserDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error getting User DGV Preferences: {errorMessage}");
        }

        public CustomerDGV PostCustomerDGV(CustomerDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/customerdgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<CustomerDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Customer DGV: {errorMessage}");
        }

        public CustomerInvoiceDGV PostCustomerInvoiceDGV(CustomerInvoiceDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/customer-invoicedgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Customer Invoice DGV: {errorMessage}");
        }

        public CustomerInvoiceCostDGV PostCustomerInvoiceCostDGV(CustomerInvoiceCostDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/customer-invoice-costdgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<CustomerInvoiceCostDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Customer Invoice Cost DGV: {errorMessage}");
        }


        public SupplierDGV PostSupplierDGV(SupplierDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/supplierdgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SupplierDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Supplier DGV: {errorMessage}");
        }

        public SupplierInvoiceDGV PostSupplierInvoiceDGV(SupplierInvoiceDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/supplier-invoicedgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Supplier Invoice DGV: {errorMessage}");
        }

        public SupplierInvoiceCostDGV PostSupplierInvoiceCostDGV(SupplierInvoiceCostDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/supplier-invoice-costdgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SupplierInvoiceCostDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Supplier Invoice Cost DGV: {errorMessage}");
        }


        public SaleDGV PostSaleDGV(SaleDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnSale = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/saledgv", returnSale).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SaleDTOGet
                var items = JsonSerializer.Deserialize<SaleDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating Sale DGV: {errorMessage}");
        }

        public UserDGV PostUserDGV(UserDGV entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/userdgv", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti UserDTOGet
                var items = JsonSerializer.Deserialize<UserDGV>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error Updating User DGV: {errorMessage}");
        }


        public string CreateFavouritePage(string newPage)
        {
            string jsonContent = JsonSerializer.Serialize(newPage);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/create-favourite-page", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the creation of a new favourite page: {errorMessage}");
        }

        public string AddUserFavouritePage(List<string> value)
        {
            string jsonContent = JsonSerializer.Serialize(value);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/add-user-favourite-page/{UserAccessInfo.RefreshUserID}", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the registration of the User: {errorMessage}");
        }
        public string RemoveUserFavouritePage(List<string> value)
        {
            string jsonContent = JsonSerializer.Serialize(value);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/remove-user-favourite-page/{UserAccessInfo.RefreshUserID}", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;
                return json;

            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the registration of the User: {errorMessage}");
        }

        public ICollection<string> GetAllPreferredPagesUser()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);

            HttpResponseMessage response = client.GetClient().GetAsync(client.GetBaseUri() + $"preference/user-favourite-pages/{UserAccessInfo.RefreshUserID}").Result;
            if (response.IsSuccessStatusCode)
            {

                // Leggere il contenuto della risposta
                string json = response.Content.ReadAsStringAsync().Result;

                // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
                var items = JsonSerializer.Deserialize<List<string>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;

            }
            return new List<string>();
        }
    }
}
