using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Autocomplete
{
    internal static class JSON
    {
        public class Topic
        {
            [JsonProperty("mid")]
            public string Mid;

            [JsonProperty("title")]
            public string Title;

            [JsonProperty("type")]
            public string Type;
        }

        public class Default
        {
            [JsonProperty("topics")]
            public List<Topic> Topics;
        }

        public class Response
        {
            [JsonProperty("default")]
            public Default Default;
        }
    }
}
