using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Widgets
{
    public static class RQClientExt
    {
        private static RQUriBuilder _uriBuilder;
        private static RQJsonInterpreter _jsonInterpreter;
        static RQClientExt()
        {
            _uriBuilder = new RQUriBuilder();
            _jsonInterpreter = new RQJsonInterpreter();
        }

        public static async Task<RelatedQueries> GetWidgetAsync(this Client client, RelatedQueriesWidget w)
        {
            var uri = _uriBuilder.BuildUri(w);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static RelatedQueries GetWidget(this Client client, RelatedQueriesWidget w)
        {
            return client.GetWidgetAsync(w).Result;
        }

    }
}
