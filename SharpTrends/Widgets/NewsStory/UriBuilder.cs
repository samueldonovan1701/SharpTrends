using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class StoryUriBuilder
    {
        public Uri BuildUri(NewsStoryWidget w)
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("hl", w.Locale.Code);
            qsb.Add("tz", -w.TimeZone.UTC_Offset.Minutes);
            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/stories/{w.ID}?{qs}");
        }
    }
}
