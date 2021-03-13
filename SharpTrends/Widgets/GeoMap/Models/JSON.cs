using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    internal static class GeoMapJSON
    {
        public class Coordinates
        {

            [JsonProperty("lat")]
            public double lat { get; set; }
            [JsonProperty("lng")]
            public double lng { get; set; }
        }

        public class GeoMapData
        {
            [JsonProperty("coordinates")]
            public Coordinates Coordinates;

            [JsonProperty("geoCode")]
            public string GeoCode { get; set; }

            [JsonProperty("geoName")]
            public string GeoName { get; set; }

            [JsonProperty("value")]
            public List<int> Value { get; set; }

            [JsonProperty("formattedValue")]
            public List<string> FormattedValue { get; set; }

            [JsonProperty("maxValueIndex")]
            public int MaxValueIndex { get; set; }

            [JsonProperty("hasData")]
            public List<bool> HasData { get; set; }
        }

        public class Default
        {
            [JsonProperty("geoMapData")]
            public List<GeoMapData> GeoMapData { get; set; }
        }

        public class Response
        {
            [JsonProperty("default")]
            public Default Default { get; set; }
        }
    }

    internal static class GeoMapWidgetJSON
    {
        public class Geo
        {
            [JsonProperty("region")]
            public string Region { get; set; }
        }

        public class Keyword
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        public class ComplexKeywordsRestriction
        {
            [JsonProperty("keyword")]
            public List<Keyword> Keyword { get; set; }
        }

        public class ComparisonItem
        {
            [JsonProperty("time")]
            public string Time { get; set; }

            [JsonProperty("complexKeywordsRestriction")]
            public ComplexKeywordsRestriction ComplexKeywordsRestriction { get; set; }
        }

        public class RequestOptions
        {
            [JsonProperty("property")]
            public string Property { get; set; }

            [JsonProperty("backend")]
            public string Backend { get; set; }

            [JsonProperty("category")]
            public int Category { get; set; }
        }

        public class Root
        {
            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            [JsonProperty("locale")]
            public string Locale { get; set; }

            [JsonProperty("requestOptions")]
            public RequestOptions RequestOptions { get; set; }

            [JsonProperty("dataMode")]
            public string DataMode { get; set; }

            [JsonProperty("includeLowSearchVolumeGeos")]
            public bool IncludeLowSearchVolumeGeos { get; set; }
        }
    }

}
