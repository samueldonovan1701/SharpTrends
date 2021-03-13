using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.DailyTrends
{
    public class UriBuilder
    {
        public Uri BuildUri(DailyTrendsParams p)
        {
            var qsb = new QueryStringBuilder
            {
                { "hl", p.Locale.Code },
                { "tz", -p.TimeZone.UTC_Offset.Minutes },
                { "ed", p.Date.ToString("yyyyMMdd") },
                { "geo", p.GeoCode.ID },
                { "ns", p.ns }
            };

            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/dailytrends?{qs}");
        }
    }
}
