using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Widgets
{
    public class StoryJsonInterpreter
    {
        private TimeSpan _parseTimeAgo(string str)
        {
            //Example string: "12h ago"
            TimeSpan ts;
            char[] possibleUnits = { 'w', 'd', 'h', 'm', 's', ' ' };
            char unit;
            string digits;

            //Get unit index
            int unitIndex = str.IndexOfAny(possibleUnits);

            //Get unit
            unit = str[unitIndex];

            //Get digit substring
            digits = str.Substring(0, unitIndex-1);

            //Parse digits & Invert (time ago)
            int quanta = -Int32.Parse(digits);

            //Scale based on unit
            switch (unit)
            {
                case 'w':
                    ts = TimeSpan.FromDays(quanta * 7);
                    break;
                case 'd':
                    ts = TimeSpan.FromDays(quanta);
                    break;
                case 'h':
                    ts = TimeSpan.FromHours(quanta);
                    break;
                case 'm':
                    ts = TimeSpan.FromMinutes(quanta);
                    break;
                case 's':
                    ts = TimeSpan.FromSeconds(quanta);
                    break;
                default:
                    ts = new TimeSpan();
                    break;
            }

            return ts;
        }
        private DateTime _parseDateTime(int timestamp)
        {
            return ((long)timestamp).ToUnixTime();
        }
        private DateTimeRange _extractTimeRange(string s)
        {
            var dtr = new DateTimeRange();

            var times = s.Split('-');
            string from = times[0].Trim();
            string to = times[1].Trim();

            dtr.From = DateTime.Parse(from);

            dtr.To = (to == "Now" ? DateTime.Now : DateTime.Parse(to));

            return dtr;
        }
        private List<Article> _extractArticles(StoryJSON.Response jsonObj)
        {
            var list = new List<Article>();
            int i = jsonObj.WidgetIds.IndexOf("NEWS_ARTICLE");

            if (i == -1)
                return list;

            foreach(var jsonArticle in jsonObj.Widgets[i].Articles)
            {
                list.Add(new Article()
                {
                    Title = jsonArticle.Title,
                    TimeAgo = _parseTimeAgo(jsonArticle.Time),
                    Uri = new Uri(jsonArticle.Url),
                    SourceName = jsonArticle.Source,
                    Image = new Image()
                    {
                        Uri = new Uri(jsonArticle.ImageUrl)
                    }
                });
            }

            return list;
        }
        private Uri _extractNewsClusterLink(StoryJSON.Response jsonObj)
        {
            int i = jsonObj.WidgetIds.IndexOf("NEWS_ARTICLE");
            return new Uri(jsonObj.Widgets[i].NewsClusterLinkUrl);
        }
        private List<Topic> _extractTopics(StoryJSON.Response jsonObj)
        {
            var list = new List<Topic>();

            for(int i = 0; i < jsonObj.EntityNames.Count; i++)
            {
                var uri = jsonObj.EntityExploreLinks[i];
                var startIndex = uri.IndexOf("?q=")+3;
                var endIndex = uri.IndexOf('&', startIndex);
                var mid = uri.Substring(startIndex, endIndex-startIndex);

                var name = jsonObj.EntityNames[i];

                list.Add(new Topic(mid, name));
            }


            return list;
        }
        private List<BarData> _extractBarData(StoryJSON.Response jsonObj)
        {
            var list = new List<BarData>();
            var i = jsonObj.WidgetIds.IndexOf("TIMESERIES");

            foreach(var jsonBarData in jsonObj.Widgets[i].BarData)
            {
                list.Add(new BarData()
                {
                    TimeStamp = _parseDateTime(jsonBarData.StartTime),
                    Accumulate = jsonBarData.Accumulative,
                    Value = jsonBarData.Articles
                });
            }

            return list;
        }
        private void _extractWidgets(StoryJSON.Response jsonObj, ref NewsStory story)
        {
            int i;

            //Timeseries
            i = jsonObj.WidgetIds.IndexOf("TIMESERIES");
            if(i != -1)
            {
                story.Timeseries = new TimeseriesWidget()
                {
                    Token = jsonObj.Widgets[i].Token,
                    Request = jsonObj.Widgets[i].Request
                };
            }

            //GeoMap
            i = jsonObj.WidgetIds.IndexOf("GEOMAP");
            if (i != -1)
            {
                story.GeoMap = new GeoMapWidget()
                {
                    Token = jsonObj.Widgets[i].Token,
                    Request = jsonObj.Widgets[i].Request
                };
            }

            //RelatedTopics
            i = jsonObj.WidgetIds.IndexOf("RELATED_TOPICS");
            if (i != -1)
            {
                story.RelatedTopics = new RelatedTopicsWidget()
                {
                    Token = jsonObj.Widgets[i].Token,
                    Request = jsonObj.Widgets[i].Request
                };
            }

            //RelatedQueries
            i = jsonObj.WidgetIds.IndexOf("RELATED_QUERIES");
            if (i != -1)
            {
                story.RelatedQueries = new RelatedQueriesWidget()
                {
                    Token = jsonObj.Widgets[i].Token,
                    Request = jsonObj.Widgets[i].Request
                };
            }
        }

        public NewsStory Interpret(string json)
        {
            var story = new NewsStory();

            if (String.IsNullOrEmpty(json))
                return story;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<StoryJSON.Response>(json);

            //Basic stuff
            story.Title = jsonObj.Title;
            story.SubTitle = jsonObj.SubTitle;
            story.Description = jsonObj.Description;
            story.EventName = jsonObj.EventName;
            story.ParentStory = new NewsStoryWidget() { ID = jsonObj.ParentStoryId };
            story.TimeStamp = _parseDateTime(jsonObj.Timestamp);

            //TimeRange
            story.TimeRange = _extractTimeRange(jsonObj.TimeRange);

            //Topics
            story.Topics = _extractTopics(jsonObj);

            //Articles
            story.Articles = _extractArticles(jsonObj);
            story.NewsClusterLink = _extractNewsClusterLink(jsonObj);

            //BarData
            story.BarData = _extractBarData(jsonObj);

            //Widgets
            _extractWidgets(jsonObj, ref story);

            return story;
        }
    }
}
