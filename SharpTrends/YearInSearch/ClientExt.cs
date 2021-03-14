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

        public static async Task<Dictionary<string, List<string>>> YearInSearchAsync(this Client client, YearInSearchParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static async Task<Dictionary<string, List<string>>> YearInSearchAsync(this Client client, int year)
        {
            var p = new YearInSearchParams();
            p.Year = year;

            return await client.YearInSearchAsync(p);
        }
        public static Dictionary<string, List<string>> YearInSearch(this Client client, YearInSearchParams p)
        {
            return client.YearInSearchAsync(p).Result;
        }
        public static Dictionary<string, List<string>> YearInSearch(this Client client, int year)
        {
            return client.YearInSearchAsync(year).Result;
        }
    }
}
