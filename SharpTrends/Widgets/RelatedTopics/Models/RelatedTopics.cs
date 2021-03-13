using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class RelatedTopics
    {
        public List<RelatedTopic> Rising;
        public List<RelatedTopic> Top;

        public RelatedTopics()
        {
            Rising = new List<RelatedTopic>();
            Top = new List<RelatedTopic>();
        }
    }
    public class RelatedTopic
    {
        public Topic Topic;
        public int Value;
    }
}
