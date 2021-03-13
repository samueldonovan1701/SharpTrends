using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Explore
{
    public class UriBuilder
    {
        private string _buildReq(ExploreParams p)
        {
            var req = new JSON.Request();
            //Baisc properties
            req.Category = p.Category.ID;
            req.Property = p.SearchMedium.Code;
            req.ComparisonItems = new List<JSON.ComparisonItem>();

            //Case: No items explored
            bool nullExplore = (p.Items.Count == 0);
            if (nullExplore)
                p.Items.Add(new ExploreItem(""));



            foreach (var item in p.Items)
            {
                var jsonItem = new JSON.ComparisonItem();

                jsonItem.Keyword = item.Topic.MID;
                jsonItem.Geo = item.Geo.ID;


                if (item.To > item.From.AddDays(8))
                    jsonItem.Time = $"{item.From:yyyy-MM-dd} {item.To:yyyy-MM-dd}";
                else
                    jsonItem.Time = $"{item.From:yyyy-MM-ddTHH} {item.To:yyyy-MM-ddTHH}";

                req.ComparisonItems.Add(jsonItem);
            }


            //?
            if (nullExplore)
                p.Items.Clear();
            
            return JsonConvert.SerializeObject(req);
        }
        
        public Uri BuildUri(ExploreParams p)
        {
            var qsb = new QueryStringBuilder
            {
                { "hl", p.Locale.Code },
                { "tz", -p.TimeZone.UTC_Offset.Minutes },
                { "req", _buildReq(p) }
            };
            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/explore?{qs}");
        }
    }
}
