using System;
using System.Net.Http;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework
{
    internal class ClientAPI
    {
        public string BaseUri { get; private set; }
        public HttpClient Client { get; private set; }
        UserService _serviceToken;
        public ClientAPI()
        {
            BaseUri = "http://localhost:5069/api/";
            Client = new HttpClient { BaseAddress = new Uri(BaseUri) };
        }

        public ClientAPI(string token)
        {
            _serviceToken = new UserService();
            BaseUri = "http://localhost:5069/api/";
            _serviceToken.RefreshToken();
            Client = new HttpClient { BaseAddress = new Uri(BaseUri) };
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Uri.EscapeDataString(token));
        }

        public string GetBaseUri() => BaseUri;
        public HttpClient GetClient() => Client;
    }
}
