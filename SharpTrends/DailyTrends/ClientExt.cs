using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.DailyTrends
{
    public static class ClientExt
    {
        private readonly static UriBuilder _uriBuilder;
        private readonly static JsonInterpreter _jsonInterpreter;
        static ClientExt()
        {
            _uriBuilder = new UriBuilder();
            _jsonInterpreter = new JsonInterpreter();
        }

        public static async Task<List<TrendingSearch>> DailyTrendsAsync(this Client client, DailyTrendsParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static async Task<List<TrendingSearch>> DailyTrendsAsync(this Client client, DateTime date)
        {
            var p = new DailyTrendsParams();
            p.Date = date;
            return await client.DailyTrendsAsync(p);
        }
        public static async Task<List<TrendingSearch>> DailyTrendsAsync(this Client client)
        {
            var p = new DailyTrendsParams();

            return await client.DailyTrendsAsync(p);
        }


        public static List<TrendingSearch> DailyTrends(this Client client, DailyTrendsParams p)
        {
            return client.DailyTrendsAsync(p).Result;
        }
        public static List<TrendingSearch> DailyTrends(this Client client, DateTime date)
        {
            return client.DailyTrendsAsync(date).Result;
        }
        public static List<TrendingSearch> DailyTrends(this Client client)
        {
            return client.DailyTrendsAsync().Result;
        }
    }
}
