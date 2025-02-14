using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform
{
    internal class ClientAPI
    {
        string BaseUri { get; set; }
        HttpClient Client { get; set; }

        public ClientAPI()
        {
            BaseUri = "http://localhost:5069/api/";
            Client = new HttpClient();
        }

        public string GetBaseUri() => BaseUri;
        public HttpClient GetClient() => Client;


    }
}
