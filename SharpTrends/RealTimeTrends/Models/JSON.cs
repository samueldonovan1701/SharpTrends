using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.RealTimeTrends
{
    public static class JSON
    {
        public class Image
        {
            [JsonProperty("newsUrl")]
            public string NewsUrl;

            [JsonProperty("source")]
            public string Source;

            [JsonProperty("imgUrl")]
            public string ImgUrl;
        }

        public class Article
        {
            [JsonProperty("articleTitle")]
            public string ArticleTitle;

            [JsonProperty("url")]
            public string Url;

            [JsonProperty("source")]
            public string Source;

            [JsonProperty("time")]
            public string Time;

            [JsonProperty("snippet")]
            public string Snippet;
        }

        public class TrendingStory
        {
            [JsonProperty("image")]
            public Image Image;

            [JsonProperty("shareUrl")]
            public string ShareUrl;

            [JsonProperty("articles")]
            public List<Article> Articles;

            [JsonProperty("idsForDedup")]
            public List<string> IdsForDedup;

            [JsonProperty("id")]
            public string Id;

            [JsonProperty("title")]
            public string Title;

            [JsonProperty("entityNames")]
            public List<string> EntityNames;
        }

        public class StorySummaries
        {
            [JsonProperty("featuredStories")]
            public List<TrendingStory> FeaturedStories;

            [JsonProperty("trendingStories")]
            public List<TrendingStory> TrendingStories;
        }

        public class Response
        {
            [JsonProperty("featuredStoryIds")]
            public List<string> FeaturedStoryIds;

            [JsonProperty("trendingStoryIds")]
            public List<string> TrendingStoryIds;

            [JsonProperty("storySummaries")]
            public StorySummaries StorySummaries;

            [JsonProperty("date")]
            public string Date;

            [JsonProperty("hideAllImages")]
            public bool HideAllImages;
        }
    }
}
