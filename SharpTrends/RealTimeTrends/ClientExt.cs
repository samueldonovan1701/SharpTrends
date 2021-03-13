using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.RealTimeTrends
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

        public static async Task<List<NewsStoryWidget>> RealTimeTrendsAsync(this Client client, RealTimeTrendsParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            foreach(var widget in data)
            {   //Copy tz & hl
                widget.Locale = p.Locale;
                widget.TimeZone = p.TimeZone;
            }

            return data;
        }
        public static async Task<List<NewsStoryWidget>> RealTimeTrendsAsync(this Client client)
        {
            var p = new RealTimeTrendsParams();

            return await client.RealTimeTrendsAsync(p);
        }
        public static List<NewsStoryWidget> RealTimeTrends(this Client client, RealTimeTrendsParams p)
        {
            return client.RealTimeTrendsAsync(p).Result;
        }
        public static List<NewsStoryWidget> RealTimeTrends(this Client client)
        {
            return client.RealTimeTrendsAsync().Result;
        }
    }
}
