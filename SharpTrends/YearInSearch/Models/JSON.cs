using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.YearInSearch
{
    internal static class JSON
    {
        public class ListItem
        {
            [JsonProperty("title")]
            public string Title;

            [JsonProperty("exploreQuery")]
            public string ExploreQuery;
        }

        public class TopChart
        {
            [JsonProperty("listTitle")]
            public string ListTitle;

            [JsonProperty("listItems")]
            public List<ListItem> ListItems;

            [JsonProperty("id")]
            public string Id;

            [JsonProperty("type")]
            public string Type;

            [JsonProperty("title")]
            public string Title;

            [JsonProperty("template")]
            public string Template;

            [JsonProperty("embedTemplate")]
            public string EmbedTemplate;

            [JsonProperty("version")]
            public string Version;

            [JsonProperty("isLong")]
            public bool IsLong;

            [JsonProperty("isCurated")]
            public bool IsCurated;
        }

        public class Interactive
        {
            [JsonProperty("url")]
            public string Url;

            [JsonProperty("imgUrl")]
            public string ImgUrl;
        }

        public class Response
        {
            [JsonProperty("topCharts")]
            public List<TopChart> TopCharts;

            [JsonProperty("interactive")]
            public Interactive Interactive;
        }
    }
}
