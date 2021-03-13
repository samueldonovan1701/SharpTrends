using System.Collections.Generic;

namespace SharpTrends.Explore
{
    public class ExploreResult : Dictionary<ExploreItem, WidgetCollection>
    {
        public TimeseriesWidget Timeseries;
        public GeoMapWidget GeoMap;
        public RelatedQueriesWidget RelatedQueries;
        public RelatedTopicsWidget RelatedTopics;


        //String-based key
        public WidgetCollection this[string key]
        {
            get
            {
                foreach (var k in this.Keys)
                {
                    if (k.Topic.MID == key)
                        return this[k];
                }

                throw new KeyNotFoundException($"Key \"{key}\" not found");
            }
            set
            {
                foreach (var k in this.Keys)
                {
                    if(k.Topic.MID == key)
                        this[k] = value;
                }

                throw new KeyNotFoundException($"Key \"{key}\" not found");
            }
        }
        public void Add(string key, WidgetCollection value)
        {
            this.Add(new ExploreItem(key), value);
        }
        public bool ContainsKey(string key)
        {
            foreach (var k in this.Keys)
            {
                if (k.Topic.MID == key)
                    return true;
            }

            return false;
        }
        public bool Remove(string key)
        {
            foreach (var k in this.Keys)
            {
                if(k.Topic.MID == key)
                    return this.Remove(k);
            }
            return false;
        }
        public bool TryAdd(string key, WidgetCollection value)
        {
            if (this.ContainsKey(key))
                return false;

            return this.TryAdd(new ExploreItem(key), value);
        }
        public bool TryGetValue(string key, out WidgetCollection value)
        {
            foreach (var k in this.Keys)
            {
                if(k.Topic.MID == key)
                {
                    value = this[k];
                    return true;
                }
            }

            value = default;
            return false;
        }

        //Topic-based key
        public WidgetCollection this[Topic key]
        {
            get
            {
                foreach (var k in this.Keys)
                {
                    if (k.Topic.Equals(key))
                        return this[k];
                }

                throw new KeyNotFoundException($"Key \"{key}\" not found");
            }
            set
            {
                foreach (var k in this.Keys)
                {
                    if (k.Topic.Equals(key))
                        this[k] = value;
                }

                throw new KeyNotFoundException($"Key \"{key}\" not found");
            }
        }
        public void Add(Topic key, WidgetCollection value)
        {
            this.Add(new ExploreItem(key), value);
        }
        public bool ContainsKey(Topic key)
        {
            foreach (var k in this.Keys)
            {
                if (k.Topic.Equals(key))
                    return true;
            }

            return false;
        }
        public bool Remove(Topic key)
        {
            foreach (var k in this.Keys)
            {
                if (k.Topic.Equals(key))
                    return this.Remove(k);
            }
            return false;
        }
        public bool TryAdd(Topic key, WidgetCollection value)
        {
            if (this.ContainsKey(key))
                return false;

            return this.TryAdd(new ExploreItem(key), value);
        }
        public bool TryGetValue(Topic key, out WidgetCollection value)
        {
            foreach (var k in this.Keys)
            {
                if (k.Topic.Equals(key))
                {
                    value = this[k];
                    return true;
                }
            }

            value = default;
            return false;
        }

    }
}
