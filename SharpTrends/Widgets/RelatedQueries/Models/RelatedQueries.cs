using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class RelatedQueries
    {
        public List<RelatedQuery> Rising;
        public List<RelatedQuery> Top;

        public RelatedQueries()
        {
            Rising = new List<RelatedQuery>();
            Top = new List<RelatedQuery>();
        }
    }
    public class RelatedQuery
    {
        public string Query;
        public int Value;
    }
}
