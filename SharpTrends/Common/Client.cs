using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SharpTrends
{
    public class Client : IDisposable
    {
        public readonly HttpClient HttpClient;
        private readonly bool _needsDisposing;

        public Client(HttpClient client)
        {
            HttpClient = client;
            _needsDisposing = false;
        }

        public Client()
        {
            HttpClient = new HttpClient();
            _needsDisposing = true;
        }

        public void Dispose()
        {
            if (_needsDisposing)
                this.HttpClient.Dispose();
        }
    }
}
