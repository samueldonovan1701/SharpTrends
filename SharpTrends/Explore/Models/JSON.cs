using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Explore
{
    public static class JSON
    {
        public class Keyword
        {
            [JsonProperty("keyword")]
            public string Value;

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("type")]
            public string Type;
        }
        
        public class Bullet
        {
            [JsonProperty("text")]
            public string Text;

            [JsonProperty("value")]
            public string Value;

            [JsonProperty("color")]
            public string Color;
        }

        public class HelpDialog
        {
            [JsonProperty("title")]
            public string Title;

            [JsonProperty("content")]
            public string Content;

            [JsonProperty("url")]
            public string Url;
        }

        public class Text
        {
            [JsonProperty("text")]
            public string Value;
        }

        public class Widget
        {
            [JsonProperty("request")]
            public object Request;

            [JsonProperty("lineAnnotationText")]
            public string LineAnnotationText;

            [JsonProperty("bullets")]
            public List<Bullet> Bullets;

            [JsonProperty("showLegend")]
            public bool ShowLegend;

            [JsonProperty("showAverages")]
            public bool ShowAverages;

            [JsonProperty("helpDialog")]
            public HelpDialog HelpDialog;

            [JsonProperty("token")]
            public string Token;

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

            [JsonProperty("geo")]
            public string Geo;

            [JsonProperty("resolution")]
            public string Resolution;

            [JsonProperty("searchInterestLabel")]
            public string SearchInterestLabel;

            [JsonProperty("displayMode")]
            public string DisplayMode;

            [JsonProperty("text")]
            public Text Text;

            [JsonProperty("color")]
            public string Color;

            [JsonProperty("index")]
            public int? Index;

            [JsonProperty("bullet")]
            public string Bullet;

            [JsonProperty("keywordName")]
            public string KeywordName;
        }

        public class Response
        {
            [JsonProperty("widgets")]
            public List<Widget> Widgets;

            [JsonProperty("keywords")]
            public List<Keyword> Keywords;

            [JsonProperty("timeRanges")]
            public List<string> TimeRanges;

            [JsonProperty("examples")]
            public List<object> Examples;

            [JsonProperty("shareText")]
            public string ShareText;

            [JsonProperty("shouldShowMultiHeatMapMessage")]
            public bool ShouldShowMultiHeatMapMessage;
        }



        public class Request
        {
            [JsonProperty("comparisonItem")]
            public List<ComparisonItem> ComparisonItems;

            [JsonProperty("category")]
            public int Category;

            [JsonProperty("property")]
            public string Property;
        }
        public class ComparisonItem
        {
            [JsonProperty("keyword")]
            public string Keyword;
            [JsonProperty("geo")]
            public string Geo;
            [JsonProperty("time")]
            public string Time;
        }
    }
}
