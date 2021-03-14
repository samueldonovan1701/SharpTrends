﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.YearInSearch
{
    public class UriBuilder
    {
        public Uri BuildUri(YearInSearchParams p)
        {
            var qsb = new QueryStringBuilder();
            qsb.Add("hl", p.Locale.Code);
            qsb.Add("date", p.Year);
            qsb.Add("geo", p.GeoCode.ID);

            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/topcharts?{qs}");
        }
    }
}
