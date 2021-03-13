using System;

namespace SharpTrends.RealTimeTrends
{
    public class RealTimeTrendsParams
    {
        public Locale Locale;
        public TimeZone TimeZone;
        public Category Category;
        public GeoCode GeoCode;

        public int fi;
        public int fs;
        public int ri;
        public int rs;
        public int sort;

        public RealTimeTrendsParams()
        {
            this.Locale = Locales.Default;
            this.TimeZone = TimeZones.Default;
            this.GeoCode = GeoCodes.Default;
            this.Category = Categories.All;

            fi = 0;
            fs = 0;
            ri = 300;
            rs = 20;
            sort = 0;
        }
    }
}
