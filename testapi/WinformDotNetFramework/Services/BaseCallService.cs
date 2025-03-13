using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;

namespace WinformDotNetFramework.Services
{
    internal class BaseCallService
    {
        //serializes an entity to be usable by the HTTPClient
        protected StringContent SerializeEntity<T>(T entity)
        {
            string jsonContent = JsonSerializer.Serialize(entity);
            var returnResult = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            return returnResult;
        }

        //makes a delete call to the api with query string used for getAll and Count
        private async Task<HttpResponseMessage> GetRepsponseGetWithQueryString(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await client.GetClient().GetAsync(client.GetBaseUri() + uri + queryString);
            return response;
        }

        //makes a get call to the api without the query string(used for getByID)
        private async Task<HttpResponseMessage> GetRepsponseGet(ClientAPI client, string uri)
        {
            HttpResponseMessage response = await client.GetClient().GetAsync(client.GetBaseUri() + uri);
            return response;
        }

        //makes a post call to the api
        protected async Task<HttpResponseMessage> GetResponsePost<T>(ClientAPI client, string uri, T entity)
        {
            var returnResult = SerializeEntity(entity);
            HttpResponseMessage response = await client.GetClient().PostAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }
        private async Task<HttpResponseMessage> GetRepsponsePost(ClientAPI client, string uri)
        {
            HttpResponseMessage response = await client.GetClient().PostAsync(client.GetBaseUri() + uri, null);
            return response;
        }
        protected async Task<string> StatusOKStringReturn(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync();
            return await json;
        }
        protected async Task<List<string>> StatusOKListStringReturn(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStreamAsync();

            // Deserializzare la risposta JSON in una lista di oggetti SupplierDTOGet
            var items = JsonSerializer.DeserializeAsync<List<string>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return await items;
        }


        //makes a put call to the api
        private async Task<HttpResponseMessage> GetRepsponsePut<T>(ClientAPI client, string uri, T entity)
        {
            var returnResult = SerializeEntity(entity);
            HttpResponseMessage response = await client.GetClient().PutAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }
        //makes a delete call to the api
        private async Task<HttpResponseMessage> GetResponseDelete(ClientAPI client, string uri)
        {
            HttpResponseMessage response = await client.GetClient().DeleteAsync(client.GetBaseUri() + uri);
            return response;
        }
        private async Task<HttpResponseMessage> GetResponseMassDelete(ClientAPI client, string uri, List<int> id)
        {
            var queryParameters = new List<string>();
            foreach (var i in id)
            {
                queryParameters.Add($"id={i}");
            }
            string queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : string.Empty;
            HttpResponseMessage response = await client.GetClient().DeleteAsync(client.GetBaseUri() + uri + queryString);
            return response;
        }

        private async Task<HttpResponseMessage> GetResponseMassUpdate<T>(ClientAPI client, string uri, List<T> newEntity)
        {
            var returnResult = SerializeEntity(newEntity);
            HttpResponseMessage response = await client.GetClient().PutAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }

        internal async Task<HttpResponseMessage> GetResponseDelete(ClientAPI client, string uri, List<string> entity)
        {
            var returnResult = SerializeEntity(entity);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(client.GetBaseUri() + uri),
                Content = returnResult
            };

            HttpResponseMessage response = await client.GetClient().SendAsync(request);
            return response;
        }



        //Used for getting a list of items
        protected async Task<List<T>> GetList<T>(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await GetRepsponseGetWithQueryString(client, uri, queryString);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = await JsonSerializer.DeserializeAsync<List<T>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return items ?? new List<T>();
            }
            return new List<T>();
        }

        //Used for getting a list of items
        protected async Task<Dictionary<TKey, TValue>> GetDictionary<TKey, TValue>(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await GetRepsponseGetWithQueryString(client, uri, queryString);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = await JsonSerializer.DeserializeAsync<Dictionary<TKey, TValue>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return items ?? new Dictionary<TKey, TValue>();
            }
            return new Dictionary<TKey, TValue>();
        }


        //Used for getting an item by ID
        protected async Task<T> GetItem<T>(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await GetRepsponseGet(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var item = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return await item;
            }
            var errorMessage = await response.Content.ReadAsStreamAsync();
            throw new Exception($"Error getting {error}: {errorMessage}");
        }



        //get the number of items from the getAll
        protected async Task<int> GetCount(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await GetRepsponseGetWithQueryString(client, uri, queryString);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = JsonSerializer.DeserializeAsync<int>(json);

                return await items;
            }
            return 0;
        }




        //Post an item
        protected async Task<T> PostItem<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await GetResponsePost(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var item = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return await item;
            }
            var errorMessage = await response.Content.ReadAsStreamAsync();
            throw new Exception($"Error creating {error}: {errorMessage}");
        }
        //Post for Registering a User
        protected async Task<string> PostRegister<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await GetResponsePost(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            string errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error creating {error}: {errorMessage}");
        }
        //Post for Logging a User
        protected async Task<UserAccessTemp> PostLogin<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await GetResponsePost(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = await JsonSerializer.DeserializeAsync<UserAccessTemp>(json,
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
            var errorMessage = await response.Content.ReadAsStreamAsync();
            throw new Exception($"Error creating {error}: {errorMessage}");
        }

        //Post for Refersh Token
        protected async Task PostRefreshToken(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await GetRepsponsePost(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStreamAsync().Result;
                var items = await JsonSerializer.DeserializeAsync<UserAccessTemp>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                UserAccessInfo.Email = items.Email;
                UserAccessInfo.Name = items.Name;
                UserAccessInfo.Token = items.Token;
                UserAccessInfo.LastName = items.LastName;
                UserAccessInfo.Role = items.Role;
                return;
            }
            var errorMessage = await response.Content.ReadAsStreamAsync();
            throw new Exception($"Error creating {error}: {errorMessage}");
        }


        //updates an item
        protected async Task<T> PutItem<T>(ClientAPI client, string uri, T entity, string error) where T : class
        {
            HttpResponseMessage response = await GetRepsponsePut(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStreamAsync().Result;
                var items = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return await items;
            }
            var errorMessage = response.Content.ReadAsStreamAsync().Result;
            throw new Exception($"Error updating {error}: {errorMessage}");
        }
        //updates an item with string return
        protected async Task<string> PutItemWithStringReturn<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await GetRepsponsePut(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            string errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error updating {error}: {errorMessage}");
        }


        //deletes an item by id
        protected async Task<T> DeleteItem<T>(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await GetResponseDelete(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return await items;
            }
            var errorMessage = response.Content.ReadAsStreamAsync().Result;
            throw new Exception($"Error deleting {error}: {errorMessage}");
        }

        //deletes an item by id with string return
        protected async Task<string> DeleteItemWithReturnString(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await GetResponseDelete(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Error deleting {error}: {errorMessage}");
        }

        protected async Task<string> MassDeleteWithStringResult(ClientAPI client, string uri, List<int> id)
        {
            HttpResponseMessage response = await GetResponseMassDelete(client, uri, id);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"{errorMessage}");
        }

        protected async Task<string> MassUpdateWithStringResult<T>(ClientAPI client, string uri, List<T> newEntities)
        {
            HttpResponseMessage response = await GetResponseMassUpdate<T>(client, uri, newEntities);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            var errorMessage = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"{errorMessage}");
        }




    }
}
