using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    internal static class TimeseriesJSON
    {
        public class TimelineData
        {
            [JsonProperty("time")]
            public string Time { get; set; }

            [JsonProperty("formattedTime")]
            public string FormattedTime { get; set; }

            [JsonProperty("formattedAxisTime")]
            public string FormattedAxisTime { get; set; }

            [JsonProperty("value")]
            public List<int> Value { get; set; }

            [JsonProperty("hasData")]
            public List<bool> HasData { get; set; }

            [JsonProperty("formattedValue")]
            public List<string> FormattedValue { get; set; }
        }

        public class Default
        {
            [JsonProperty("timelineData")]
            public List<TimelineData> TimelineData { get; set; }

            [JsonProperty("averages")]
            public List<int> Averages { get; set; }
        }

        public class Response
        {
            [JsonProperty("default")]
            public Default Default { get; set; }
        }
    }
}
