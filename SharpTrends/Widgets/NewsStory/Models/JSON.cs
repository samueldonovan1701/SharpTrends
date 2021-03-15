using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    internal static class StoryJSON
    {
        public class Article
        {
            [JsonProperty("imageUrl")]
            public string ImageUrl { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("time")]
            public string Time { get; set; }
        }

        public class Geo
        {
            [JsonProperty("country")]
            public string Country { get; set; }
        }

        public class TrendinessSettings
        {
            [JsonProperty("compareTime")]
            public string CompareTime { get; set; }

            [JsonProperty("jumpThreshold")]
            public double JumpThreshold { get; set; }
        }

        public class Request
        {
            [JsonProperty("geo")]
            public Geo Geo { get; set; }

            [JsonProperty("time")]
            public string Time { get; set; }

            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            [JsonProperty("mid")]
            public List<string> Mid { get; set; }

            [JsonProperty("locale")]
            public string Locale { get; set; }

            [JsonProperty("skipPrivacyChecksForGeos")]
            public bool? SkipPrivacyChecksForGeos { get; set; }

            [JsonProperty("term")]
            public List<string> Term { get; set; }

            [JsonProperty("trendinessSettings")]
            public TrendinessSettings TrendinessSettings { get; set; }
        }

        public class BarData
        {
            [JsonProperty("startTime")]
            public int StartTime { get; set; }

            [JsonProperty("articles")]
            public int Articles { get; set; }

            [JsonProperty("accumulative")]
            public int Accumulative { get; set; }

            [JsonProperty("formattedArticles")]
            public string FormattedArticles { get; set; }

            [JsonProperty("formattedAccumulative")]
            public string FormattedAccumulative { get; set; }
        }

        public class Widget
        {
            [JsonProperty("newsClusterLinkUrl")]
            public string NewsClusterLinkUrl { get; set; }

            [JsonProperty("articles")]
            public List<Article> Articles { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("template")]
            public string Template { get; set; }

            [JsonProperty("embedTemplate")]
            public string EmbedTemplate { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("isLong")]
            public bool IsLong { get; set; }

            [JsonProperty("isCurated")]
            public bool IsCurated { get; set; }

            [JsonProperty("request")]
            public Request Request { get; set; }

            [JsonProperty("barData")]
            public List<BarData> BarData { get; set; }

            [JsonProperty("barAnnotationText")]
            public string BarAnnotationText { get; set; }

            [JsonProperty("lineAnnotationText")]
            public string LineAnnotationText { get; set; }

            [JsonProperty("sumAnnotationText")]
            public string SumAnnotationText { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("geo")]
            public string Geo { get; set; }

            [JsonProperty("resolution")]
            public string Resolution { get; set; }

            [JsonProperty("searchInterestLabel")]
            public string SearchInterestLabel { get; set; }

            [JsonProperty("displayMode")]
            public string DisplayMode { get; set; }
        }

        public class Response
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("entityNames")]
            public List<string> EntityNames { get; set; }

            [JsonProperty("entityExploreLinks")]
            public List<string> EntityExploreLinks { get; set; }

            [JsonProperty("timeRange")]
            public string TimeRange { get; set; }

            [JsonProperty("timestamp")]
            public int Timestamp { get; set; }

            [JsonProperty("bannerImgUrl")]
            public string BannerImgUrl { get; set; }

            [JsonProperty("bannerVideoUrl")]
            public string BannerVideoUrl { get; set; }

            [JsonProperty("pageLayout")]
            public string PageLayout { get; set; }

            [JsonProperty("translate")]
            public bool Translate { get; set; }

            [JsonProperty("parentStoryId")]
            public string ParentStoryId { get; set; }

            [JsonProperty("subTitle")]
            public string SubTitle { get; set; }

            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("colorTheme")]
            public string ColorTheme { get; set; }

            [JsonProperty("widgets")]
            public List<Widget> Widgets { get; set; }

            [JsonProperty("widgetIds")]
            public List<string> WidgetIds { get; set; }

            [JsonProperty("components")]
            public List<object> Components { get; set; }
        }
    }
}
