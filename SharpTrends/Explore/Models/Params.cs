using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SharpTrends.Explore
{
    public class ExploreParams
    {
        public Locale Locale;
        public TimeZone TimeZone;
        public List<ExploreItem> Items;
        public SearchMedium SearchMedium;
        public ExploreCategory Category;

        public ExploreParams()
        {
            this.Locale = Locales.Default;
            this.TimeZone = TimeZones.Default;
            this.Items = new List<ExploreItem>();
            this.SearchMedium = SearchMediums.Default;
            this.Category = ExploreCategories.All;
        }

        public void SetFrom(DateTime from)
        {
            foreach (var item in Items)
                item.From = from;
        }
        public void SetTo(DateTime to)
        {
            foreach (var item in Items)
                item.To = to;
        }
        public void SetGeo(GeoCode geo)
        {
            foreach (var item in Items)
                item.Geo = geo;
        }

        public ExploreItem AddItem(ExploreItem item)
        {
            Items.Add(item);
            return item;
        }
        public ExploreItem AddItem(Topic t)
        {
            var r = new ExploreItem(t);
            Items.Add(r);
            return r;
        }
        public ExploreItem AddItem(string keyword)
        {
            var r = new ExploreItem(keyword);
            Items.Add(r);
            return r;
        }
    }
}
