using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Widgets
{

    public static class GeoMapClientExt
    {
        private static GeoMapUriBuilder _uriBuilder;
        private static GeoMapJsonInterpreter _jsonInterpreter;
        static GeoMapClientExt()
        {
            _uriBuilder = new GeoMapUriBuilder();
            _jsonInterpreter = new GeoMapJsonInterpreter();
        }

        public static async Task<GeoMap> GetWidgetAsync(this Client client, GeoMapWidget w)
        {
            var uri = _uriBuilder.BuildUri(w);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static GeoMap GetWidget(this Client client, GeoMapWidget w)
        {
            return client.GetWidgetAsync(w).Result;
        }

    }
}
