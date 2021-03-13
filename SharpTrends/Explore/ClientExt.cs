using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Explore
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

        private static void _copyTzAndHl(ExploreParams p, ref ExploreResult r)
        {
            if (r.Timeseries != null)
            {
                r.Timeseries.TimeZone = p.TimeZone;
                r.Timeseries.Locale = p.Locale;
            }
            if (r.GeoMap != null)
            {
                r.GeoMap.TimeZone = p.TimeZone;
                r.GeoMap.Locale = p.Locale;
            }
            if (r.RelatedQueries != null)
            {
                r.RelatedQueries.TimeZone = p.TimeZone;
                r.RelatedQueries.Locale = p.Locale;
            }
            if (r.RelatedTopics != null)
            {
                r.RelatedTopics.TimeZone = p.TimeZone;
                r.RelatedTopics.Locale = p.Locale;
            }

            foreach (var widgetColl in r.Values)
            {
                if (widgetColl.Timeseries != null)
                {
                    widgetColl.Timeseries.TimeZone = p.TimeZone;
                    widgetColl.Timeseries.Locale = p.Locale;
                }
                if (widgetColl.GeoMap != null)
                {
                    widgetColl.GeoMap.TimeZone = p.TimeZone;
                    widgetColl.GeoMap.Locale = p.Locale;
                }
                if (widgetColl.RelatedQueries != null)
                {
                    widgetColl.RelatedQueries.TimeZone = p.TimeZone;
                    widgetColl.RelatedQueries.Locale = p.Locale;
                }
                if (widgetColl.RelatedTopics != null)
                {
                    widgetColl.RelatedTopics.TimeZone = p.TimeZone;
                    widgetColl.RelatedTopics.Locale = p.Locale;
                }
            }
        }

        public static async Task<ExploreResult> ExploreAsync(this Client client, ExploreParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            //For an unkown reason, the first request always returns a 429 status code (TooManyRequests)
            string response = "";
            try
            {
                response = await client.HttpClient.RetrieveJson(uri);
            }
            catch(HttpRequestException)
            {
                response = await client.HttpClient.RetrieveJson(uri);
            }
            var data = _jsonInterpreter.Interpret(response, p);

            //Set tz and hl of widgets
            _copyTzAndHl(p, ref data);


            return data;
        }
        public static async Task<ExploreResult> ExploreAsync(this Client client, params ExploreItem[] items)
        {
            var p = new ExploreParams();
            foreach (var item in items)
                p.AddItem(item);

            return await client.ExploreAsync(p);
        }
        public static async Task<ExploreResult> ExploreAsync(this Client client, params string[] searchTerms)
        {
            var p = new ExploreParams();
            foreach (var word in searchTerms)
                p.AddItem(new ExploreItem(word));

            return await client.ExploreAsync(p);
        }
        public static async Task<ExploreResult> ExploreAsync(this Client client, params Topic[] topics)
        {
            var p = new ExploreParams();
            foreach (var topic in topics)
                p.Items.Add(new ExploreItem(topic));

            return await client.ExploreAsync(p);
        }
        public static async Task<ExploreResult> ExploreAsync(this Client client)
        {
            var p = new ExploreParams();
            return await client.ExploreAsync(p);
        }

        public static ExploreResult Explore(this Client client, ExploreParams p)
        {
            return client.ExploreAsync(p).Result;
        }
        public static ExploreResult Explore(this Client client, params ExploreItem[] items)
        {
            return client.ExploreAsync(items).Result;
        }
        public static ExploreResult Explore(this Client client, params string[] searchTerms)
        {
            return client.ExploreAsync(searchTerms).Result;
        }
        public static ExploreResult Explore(this Client client, params Topic[] topics)
        {
            return client.ExploreAsync(topics).Result;
        }
        public static ExploreResult Explore(this Client client)
        {
            return client.ExploreAsync().Result;
        }
    }
}
