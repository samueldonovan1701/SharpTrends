using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.RealTimeTrends
{
    public class UriBuilder
    {
        public Uri BuildUri(RealTimeTrendsParams p)
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("hl", p.Locale.Code);
            qsb.Add("tz", -p.TimeZone.UTC_Offset.Minutes);
            qsb.Add("cat", p.Category.ID);
            qsb.Add("fi", p.fi);
            qsb.Add("fs", p.fs);
            qsb.Add("geo", p.GeoCode.ID);
            qsb.Add("ri", p.ri);
            qsb.Add("rs", p.rs);
            qsb.Add("sort", p.sort);

            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/realtimetrends?{qs}");
        }
    }
}
