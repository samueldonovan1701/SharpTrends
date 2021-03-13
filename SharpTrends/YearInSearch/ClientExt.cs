using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.YearInSearch
{
    public static class ClientExt
    {
        private static UriBuilder _uriBuilder;
        private static JsonInterpreter _jsonInterpreter;
        static ClientExt()
        {
            _uriBuilder = new UriBuilder();
            _jsonInterpreter = new JsonInterpreter();
        }

        public static async Task<Dictionary<string, List<string>>> YISAsync(this Client client, YearInSearchParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static async Task<Dictionary<string, List<string>>> YISAsync(this Client client, int year)
        {
            var p = new YearInSearchParams();
            p.Year = year;

            return await client.YISAsync(p);
        }
        public static Dictionary<string, List<string>> YIS(this Client client, YearInSearchParams p)
        {
            return client.YISAsync(p).Result;
        }
        public static Dictionary<string, List<string>> YIS(this Client client, int year)
        {
            return client.YISAsync(year).Result;
        }
    }
}
