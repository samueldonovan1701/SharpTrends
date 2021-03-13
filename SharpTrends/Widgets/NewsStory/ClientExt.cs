using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpTrends.Widgets
{
    public static class StoryClientExt
    {
        private static StoryUriBuilder _uriBuilder;
        private static StoryJsonInterpreter _jsonInterpreter;
        static StoryClientExt()
        {
            _uriBuilder = new StoryUriBuilder();
            _jsonInterpreter = new StoryJsonInterpreter();
        }

        private static void _copyTzAndHl(NewsStoryWidget p, ref NewsStory story)
        {
            //Parent Story
            if(story.ParentStory != null)
            {
                story.ParentStory.Locale = p.Locale;
                story.ParentStory.TimeZone = p.TimeZone;
            }

            //Timeseries
            if(story.Timeseries != null)
            {
                story.Timeseries.Locale = p.Locale;
                story.Timeseries.TimeZone = p.TimeZone;
            }

            //GeoMap
            if (story.GeoMap != null)
            {
                story.GeoMap.Locale = p.Locale;
                story.GeoMap.TimeZone = p.TimeZone;
            }

            //RelatedQueries
            if (story.RelatedQueries != null)
            {
                story.RelatedQueries.Locale = p.Locale;
                story.RelatedQueries.TimeZone = p.TimeZone;
            }

            //RelatedTopics
            if (story.RelatedTopics != null)
            {
                story.RelatedTopics.Locale = p.Locale;
                story.RelatedTopics.TimeZone = p.TimeZone;
            }
        }
        public static async Task<NewsStory> GetWidgetAsync(this Client client, NewsStoryWidget w)
        {
            var uri = _uriBuilder.BuildUri(w);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            _copyTzAndHl(w, ref data);

            return data;
        }
        public static NewsStory GetWidget(this Client client, NewsStoryWidget w)
        {
            return client.GetWidgetAsync(w).Result;
        }

    }
}
