using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Widgets
{
    public static class TimeseriesClientExt
    {
        private static TimeseriesUriBuilder _uriBuilder;
        private static TimeseriesJsonInterpreter _jsonInterpreter;
        static TimeseriesClientExt()
        {
            _uriBuilder = new TimeseriesUriBuilder();
            _jsonInterpreter = new TimeseriesJsonInterpreter();
        }

        public static async Task<Timeseries> GetWidgetAsync(this Client client, TimeseriesWidget w)
        {
            var uri = _uriBuilder.BuildUri(w);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static Timeseries GetWidget(this Client client, TimeseriesWidget w)
        {
            return client.GetWidgetAsync(w).Result;
        }

    }
}
