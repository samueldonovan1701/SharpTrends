using Newtonsoft.Json;
using System.Collections.Generic;

namespace SharpTrends.DailyTrends
{
    internal static class JSON
    {
        public class Title
        {
            [JsonProperty("query")]
            public string Query;

            [JsonProperty("exploreLink")]
            public string ExploreLink;
        }

        public class RelatedQuery
        {
            [JsonProperty("query")]
            public string Query;

            [JsonProperty("exploreLink")]
            public string ExploreLink;
        }

        public class Image
        {
            [JsonProperty("newsUrl")]
            public string NewsUrl;

            [JsonProperty("source")]
            public string Source;

            [JsonProperty("imageUrl")]
            public string ImageUrl;
        }

        public class Article
        {
            [JsonProperty("title")]
            public string Title;

            [JsonProperty("timeAgo")]
            public string TimeAgo;

            [JsonProperty("source")]
            public string Source;

            [JsonProperty("image")]
            public Image Image;

            [JsonProperty("url")]
            public string Url;

            [JsonProperty("snippet")]
            public string Snippet;
        }

        public class TrendingSearch
        {
            [JsonProperty("title")]
            public Title Title;

            [JsonProperty("formattedTraffic")]
            public string FormattedTraffic;

            [JsonProperty("relatedQueries")]
            public List<RelatedQuery> RelatedQueries;

            [JsonProperty("image")]
            public Image Image;

            [JsonProperty("articles")]
            public List<Article> Articles;

            [JsonProperty("shareUrl")]
            public string ShareUrl;
        }

        public class TrendingSearchesDay
        {
            [JsonProperty("date")]
            public string Date;

            [JsonProperty("formattedDate")]
            public string FormattedDate;

            [JsonProperty("trendingSearches")]
            public List<TrendingSearch> TrendingSearches;
        }

        public class Default
        {
            [JsonProperty("trendingSearchesDays")]
            public List<TrendingSearchesDay> TrendingSearchesDays;

            [JsonProperty("endDateForNextRequest")]
            public string EndDateForNextRequest;

            [JsonProperty("rssFeedPageUrl")]
            public string RssFeedPageUrl;
        }

        public class Response
        {
            [JsonProperty("default")]
            public Default Default;
        }
    }
}
