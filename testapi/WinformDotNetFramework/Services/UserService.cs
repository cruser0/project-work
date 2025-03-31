using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities.Preference;
using Entity_Validator.Entity.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace WinformDotNetFramework.Services
{
    internal class UserService : BaseCallService
    {
        public async Task<string> Register(UserDTOCreate user)
        {
            ClientAPI client = new ClientAPI();
            var reuturnResult = await PostRegister(client, $"register", user, "User");
            return reuturnResult;
        }



        public async Task<UserAccessInfoDTO> Login(UserDTO entity)
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

        public async Task<string> MassDelete(List<int> id)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassDeleteWithStringResult(client, $"user/mass-delete", id);
            return returnResult;
        }

        public async Task<string> MassUpdate(List<UserDTOGet> newEntity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await MassUpdateWithStringResult(client, $"user/mass-update", newEntity);
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

            var filters = new Dictionary<string, object>
            {
                { "UserName", filter.UserName },
                { "UserLastName", filter.UserLastName },
                { "Userpage", filter.UserPage },
                { "UserEmail", filter.UserEmail },

            };

            foreach (var kvp in filters)
            {
                if (kvp.Value != null)
                    queryParameters.Add($"{kvp.Key}={kvp.Value}");
            }
            foreach (var kvp in filter.UserRoles)
            {
                queryParameters.Add($"UserRoles={kvp}");
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
            var returnResult = await GetItem<UserRoleDTO>(client, $"user/{id}", "User");
            return returnResult;
        }


        public async Task<int> Count(UserFilter filter)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            string queryString = BuildQueryParams(filter);
            var returnResult = await GetCount(client, "user/count", queryString);
            return returnResult;
        }




        public async Task<CustomerDGV> GetCustomerDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerDGV>(client, $"preference/customerdgv/{UserAccessInfo.RefreshUserID}", "Customer DGV");
            return returnResult;
        }

        public async Task<CustomerInvoiceDGV> GetCustomerInvoiceDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerInvoiceDGV>(client, $"preference/customer-invoicedgv/{UserAccessInfo.RefreshUserID}", "Customer DGV");
            return returnResult;
        }

        public async Task<CustomerInvoiceCostDGV> GetCustomerInvoiceCostDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<CustomerInvoiceCostDGV>(client, $"preference/customer-invoice-costdgv/{UserAccessInfo.RefreshUserID}", "Customer DGV");
            return returnResult;
        }



        public async Task<SupplierDGV> GetSupplierDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SupplierDGV>(client, $"preference/supplierdgv/{UserAccessInfo.RefreshUserID}", "Supplier DGV");
            return returnResult;
        }

        public async Task<SupplierInvoiceDGV> GetSupplierInvoiceDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SupplierInvoiceDGV>(client, $"preference/supplier-invoicedgv/{UserAccessInfo.RefreshUserID}", "Supplier DGV");
            return returnResult;
        }

        public async Task<SupplierInvoiceCostDGV> GetSupplierInvoiceCostDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SupplierInvoiceCostDGV>(client, $"preference/supplier-invoice-costdgv/{UserAccessInfo.RefreshUserID}", "Supplier DGV");
            return returnResult;
        }

        public async Task<SaleDGV> GetSaleDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<SaleDGV>(client, $"preference/saledgv/{UserAccessInfo.RefreshUserID}", "Sale DGV");
            return returnResult;
        }
        public async Task<UserDGV> GetUserDGV()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await GetItem<UserDGV>(client, $"preference/userdgv/{UserAccessInfo.RefreshUserID}", "User DGV");
            return returnResult;
        }

        public async Task<CustomerDGV> PostCustomerDGV(CustomerDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/customerdgv", entity, "Customer DGV");
            return returnResult;
        }

        public async Task<CustomerInvoiceDGV> PostCustomerInvoiceDGV(CustomerInvoiceDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/customer-invoicedgv", entity, "Customer Invoice DGV");
            return returnResult;
        }

        public async Task<CustomerInvoiceCostDGV> PostCustomerInvoiceCostDGV(CustomerInvoiceCostDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/customer-invoice-costdgv", entity, "Customer Invoice Cost DGV");
            return returnResult;
        }


        public async Task<SupplierDGV> PostSupplierDGV(SupplierDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/supplierdgv", entity, "Supplier DGV");
            return returnResult;
        }

        public async Task<SupplierInvoiceDGV> PostSupplierInvoiceDGV(SupplierInvoiceDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/supplier-invoicedgv", entity, "Supplier Invoice DGV");
            return returnResult;
        }

        public async Task<SupplierInvoiceCostDGV> PostSupplierInvoiceCostDGV(SupplierInvoiceCostDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/supplier-invoice-costdgv", entity, "Supplier Invoice Cost DGV");
            return returnResult;
        }


        public async Task<SaleDGV> PostSaleDGV(SaleDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/saledgv", entity, "Sale DGV");
            return returnResult;
        }

        public async Task<UserDGV> PostUserDGV(UserDGV entity)
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            var returnResult = await PostItem(client, $"preference/userdgv", entity, "User DGV");
            return returnResult;
        }


        public async Task<string> CreateFavouritePage(string newPage)
        {
            string jsonContent = JsonSerializer.Serialize(newPage);
            var returnUser = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = client.GetClient().PostAsync(client.GetBaseUri() + $"preference/create-favourite-page", returnUser).Result;
            if (response.IsSuccessStatusCode)
            {
                return await StatusOKStringReturn(response);
            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the creation of a new favourite page: {errorMessage}");
        }

        public async Task<string> AddUserFavouritePage(List<string> value)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = await GetResponsePost(client, $"preference/add-user-favourite-page/{UserAccessInfo.RefreshUserID}", value);
            if (response.IsSuccessStatusCode)
            {
                return await StatusOKStringReturn(response);
            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the Add of the favourite page to user: {errorMessage}");
        }
        public async Task<string> RemoveUserFavouritePage(List<string> value)
        {
            ClientAPI client = new ClientAPI();
            HttpResponseMessage response = await GetResponseDelete(client, $"preference/remove-user-favourite-page/{UserAccessInfo.RefreshUserID}", value);
            if (response.IsSuccessStatusCode)
            {
                return await StatusOKStringReturn(response);
            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error during the Removal of the favourite page to user: {errorMessage}");
        }

        public async Task<ICollection<string>> GetAllPreferredPagesUser()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);

            HttpResponseMessage response = await client.GetClient().GetAsync(client.GetBaseUri() + $"preference/user-favourite-pages/{UserAccessInfo.RefreshUserID}");
            if (response.IsSuccessStatusCode)
            {
                return await StatusOKListStringReturn(response);

            }
            return new List<string>();
        }
    }
}
