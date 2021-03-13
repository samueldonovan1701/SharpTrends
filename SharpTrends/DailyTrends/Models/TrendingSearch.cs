using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.DailyTrends
{
    public class TrendingSearch
    {

        public DateTime Date;
        public string Title;
        public Image Image;
        public List<string> RelatedQueries;
        public List<Article> Articles;
        public double Traffic;

        public override bool Equals(Object obj)
        {
            TrendingSearch other = obj as TrendingSearch;
            if (other == null)
                return false;
            return this.Title.Equals(other.Title);
        }

        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }
    }
}
