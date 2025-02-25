namespace Winform
{
    internal class ClientAPI
    {
        public string BaseUri { get; private set; }
        public HttpClient Client { get; private set; }

        public ClientAPI()
        {
            BaseUri = "http://localhost:5069/api/";
            Client = new HttpClient { BaseAddress = new Uri(BaseUri) };
        }

        public ClientAPI(string token)
        {
            BaseUri = "http://localhost:5069/api/";
            Client = new HttpClient { BaseAddress = new Uri(BaseUri) };
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }

        public string GetBaseUri() => BaseUri;
        public HttpClient GetClient() => Client;
    }
}
