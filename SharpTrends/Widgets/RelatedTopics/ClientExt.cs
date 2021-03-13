using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Widgets
{
    public static class RTClientExt
    {
        private static RTUriBuilder _uriBuilder;
        private static RTJsonInterpreter _jsonInterpreter;
        static RTClientExt()
        {
            _uriBuilder = new RTUriBuilder();
            _jsonInterpreter = new RTJsonInterpreter();
        }

        public static async Task<RelatedTopics> GetWidgetAsync(this Client client, RelatedTopicsWidget w)
        {
            var uri = _uriBuilder.BuildUri(w);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static RelatedTopics GetWidget(this Client client, RelatedTopicsWidget w)
        {
            return client.GetWidgetAsync(w).Result;
        }

    }
}
