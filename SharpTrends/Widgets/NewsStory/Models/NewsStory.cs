using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class NewsStory
    {
        public string Title;
        public string SubTitle;
        public string Description;
        public string EventName;
        public NewsStoryWidget ParentStory;
        public DateTime TimeStamp;
        public DateTimeRange TimeRange; //?
        public List<Topic> Topics;



        //(News Widget)//
        public List<Article> Articles;
        public Uri NewsClusterLink;
        //(Timeseries Widget)//
        public List<BarData> BarData;

        //Widgets
        public TimeseriesWidget Timeseries;
        public GeoMapWidget GeoMap;
        public RelatedQueriesWidget RelatedQueries;
        public RelatedTopicsWidget RelatedTopics;
    }
}
