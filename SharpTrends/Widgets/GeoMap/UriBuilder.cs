using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class GeoMapUriBuilder
    {
        public Uri BuildUri(GeoMapWidget w)
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("hl", w.Locale.Code);
            qsb.Add("tz", -w.TimeZone.UTC_Offset.Minutes);
            qsb.Add("req", w.Request);
            qsb.Add("token", w.Token);
            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/widgetdata/comparedgeo?{qs}");
        }
    }
}
