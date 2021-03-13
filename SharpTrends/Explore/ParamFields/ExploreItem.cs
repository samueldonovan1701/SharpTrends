using System;
using System.Collections.Generic;

namespace SharpTrends.Explore
{
    public class ExploreItem : IEquatable<string>, IEquatable<Topic>
    {
        public Topic Topic;
        public GeoCode Geo;
        public DateTime From;
        public DateTime To;

        public ExploreItem(Topic topic, GeoCode geo=null, DateTime? from=null, DateTime? to=null)
        {
            Topic = topic;
            Geo = geo ?? GeoCodes.Default;
            From = from ?? DateTime.Today.AddYears(-1);
            To = to ?? DateTime.Today;
        }

        public ExploreItem(string keyword, GeoCode geo = null, DateTime? from = null, DateTime? to = null)
        {
            Topic = new Topic(keyword);
            Geo = geo ?? GeoCodes.Default;
            From = from ?? DateTime.Today.AddYears(-1);
            To = to ?? DateTime.Today;
        }

        public bool Equals(string other)
        {
            if (other == null)
                return false;
            return this.Topic.Equals(other);
        }
        public bool Equals(Topic other)
        {
            if(other == null)
                return false;
            return this.Topic.Equals(other);
        }
        public override bool Equals(Object obj)
        {
            ExploreItem other = obj as ExploreItem;
            if (other == null)
                return false;
            return this.GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return this.Topic.ToString();
        }
        public override int GetHashCode() 
        {
            return HashCode.Combine(this.Topic, this.Geo, this.From, this.To);// this.Topic.GetHashCode().Combin;
        }
    }
}