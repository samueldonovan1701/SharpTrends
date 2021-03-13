using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    internal static class RQJSON
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class RankedKeyword
        {
            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }

            [JsonProperty("formattedValue")]
            public string FormattedValue { get; set; }

            [JsonProperty("hasData")]
            public bool HasData { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }
        }

        public class RankedList
        {
            [JsonProperty("rankedKeyword")]
            public List<RankedKeyword> RankedKeyword { get; set; }
        }

        public class Default
        {
            [JsonProperty("rankedList")]
            public List<RankedList> RankedList { get; set; }
        }

        public class Response
        {
            [JsonProperty("default")]
            public Default Default { get; set; }
        }


    }
}
