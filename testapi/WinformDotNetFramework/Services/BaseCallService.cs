using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

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
        private async Task<HttpResponseMessage> GetResponse(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response;
            if (string.IsNullOrEmpty(queryString))
                response = await client.GetClient().GetAsync(client.GetBaseUri() + uri);
            else
                response = await client.GetClient().GetAsync(client.GetBaseUri() + uri + queryString);
            return response;
        }

        //makes a get call to the api without the query string(used for getByID)
        private async Task<HttpResponseMessage> GetResponse(ClientAPI client, string uri)
        {
            HttpResponseMessage response = await client.GetClient().GetAsync(client.GetBaseUri() + uri);
            return response;
        }

        //makes a post call to the api
        protected async Task<HttpResponseMessage> PostResponse<T>(ClientAPI client, string uri, T entity)
        {
            var returnResult = SerializeEntity(entity);
            var response = await client.GetClient().PostAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }
        private async Task<HttpResponseMessage> PostResponse(ClientAPI client, string uri)
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
            var items = JsonSerializer.DeserializeAsync<List<string>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return await items;
        }


        //makes a put call to the api
        private async Task<HttpResponseMessage> PutResponse<T>(ClientAPI client, string uri, T entity)
        {
            var returnResult = SerializeEntity(entity);
            HttpResponseMessage response = await client.GetClient().PutAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }
        private async Task<HttpResponseMessage> MassUpdateResponse<T>(ClientAPI client, string uri, List<T> newEntity)
        {
            var returnResult = SerializeEntity(newEntity);
            HttpResponseMessage response = await client.GetClient().PutAsync(client.GetBaseUri() + uri, returnResult);
            return response;
        }
        //makes a delete call to the api
        private async Task<HttpResponseMessage> DeleteResponse(ClientAPI client, string uri)
        {
            HttpResponseMessage response = await client.GetClient().DeleteAsync(client.GetBaseUri() + uri);
            return response;
        }
        internal async Task<HttpResponseMessage> DeleteResponse(ClientAPI client, string uri, List<string> entity)
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
        private async Task<HttpResponseMessage> MassDeleteResponse(ClientAPI client, string uri, List<int> id)
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





        //Used for getting a list of items
        protected async Task<List<T>> GetList<T>(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await GetResponse(client, uri, queryString);
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
            HttpResponseMessage response = await GetResponse(client, uri, queryString);
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
            HttpResponseMessage response = await GetResponse(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var item = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return await item;
            }
            await ExceptionHandler(response,error);
            return default; 
        }
        //get the number of items from the getAll
        protected async Task<int> GetCount(ClientAPI client, string uri, string queryString)
        {
            HttpResponseMessage response = await GetResponse(client, uri, queryString);
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
            HttpResponseMessage response = await PostResponse(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var item = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return await item;
            }
            await ExceptionHandler(response, error);
            return default;
        }
        //Post for Registering a User
        protected async Task<string> PostRegister<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await PostResponse(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            await ExceptionHandler(response, error);
            return default;
        }
        //Post for Logging a User
        protected async Task<UserAccessInfoDTO> PostLogin<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await PostResponse(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = await JsonSerializer.DeserializeAsync<UserAccessInfoDTO>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                UserAccessInfo.Email = items.Email;
                UserAccessInfo.Name = items.Name;
                UserAccessInfo.Token = items.Token;
                UserAccessInfo.LastName = items.LastName;
                UserAccessInfo.Role = items.Role;
                UserAccessInfo.RefreshToken = items.RefreshToken;
                UserAccessInfo.RefreshCreated = (DateTime)items.RefreshCreated;
                UserAccessInfo.RefreshExpires = (DateTime)items.RefreshExpires;
                UserAccessInfo.RefreshTokenID = items.RefreshTokenID;
                UserAccessInfo.RefreshUserID = items.RefreshUserID;
                return items;
            }
            await ExceptionHandler(response,error);
            return default; 
        }
        //Post for Refersh Token
        protected async Task PostRefreshToken(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await PostResponse(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStreamAsync().Result;
                var items = await JsonSerializer.DeserializeAsync<UserAccessInfoDTO>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                UserAccessInfo.Email = items.Email;
                UserAccessInfo.Name = items.Name;
                UserAccessInfo.Token = items.Token;
                UserAccessInfo.LastName = items.LastName;
                UserAccessInfo.Role = items.Role;
                return;
            }
            await ExceptionHandler(response,error);
        }







        //updates an item
        protected async Task<T> PutItem<T>(ClientAPI client, string uri, T entity, string error) where T : class
        {
            HttpResponseMessage response = await PutResponse(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStreamAsync().Result;
                var items = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return await items;
            }
            await ExceptionHandler(response, error);
            return default;
        }
        //updates an item with string return
        protected async Task<string> PutItemWithStringReturn<T>(ClientAPI client, string uri, T entity, string error)
        {
            HttpResponseMessage response = await PutResponse(client, uri, entity);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            await ExceptionHandler(response, error);
            return default;
        }
        protected async Task<string> MassUpdateWithStringResult<T>(ClientAPI client, string uri, List<T> newEntities)
        {
            HttpResponseMessage response = await MassUpdateResponse<T>(client, uri, newEntities);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            await ExceptionHandler(response, "Mass Update Error");
            return default; 
        }







        //deletes an item by id
        protected async Task<T> DeleteItem<T>(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await DeleteResponse(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var items = JsonSerializer.DeserializeAsync<T>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return await items;
            }
            await ExceptionHandler(response, error);
            return default;
        }

        //deletes an item by id with string return
        protected async Task<string> DeleteItemWithReturnString(ClientAPI client, string uri, string error)
        {
            HttpResponseMessage response = await DeleteResponse(client, uri);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            await ExceptionHandler(response, error);
            return default;
        }

        protected async Task<string> MassDeleteWithStringResult(ClientAPI client, string uri, List<int> id)
        {
            HttpResponseMessage response = await MassDeleteResponse(client, uri, id);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
            await ExceptionHandler(response, "Mass Delete Error");
            return default;
        }






        private async Task ExceptionHandler(HttpResponseMessage response,string error)
        {
            var errorJson = await response.Content.ReadAsStringAsync();
            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(errorJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (problemDetails != null)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new KeyNotFoundException(problemDetails.Detail);
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException(problemDetails.Detail);
                    case HttpStatusCode.BadRequest:
                        throw new InvalidOperationException(problemDetails.Detail);
                    case HttpStatusCode.InternalServerError:
                        throw new InvalidOperationException("Server error: " + problemDetails.Detail);
                    default:
                        throw new Exception($"Unexpected error: {problemDetails.Detail}");
                }
            }

            throw new Exception($"Error getting {error}: {errorJson}");
        }

    }
}
