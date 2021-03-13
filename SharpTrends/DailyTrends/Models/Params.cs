using System;

namespace SharpTrends.DailyTrends
{
    public class DailyTrendsParams
    {
        public Locale Locale;
        public TimeZone TimeZone;
        public GeoCode GeoCode;
        public DateTime Date;
        public int ns;
        public DailyTrendsParams()
        {
            this.Locale = Locales.Default;
            this.TimeZone = TimeZones.Default;
            this.GeoCode = GeoCodes.Default;
            this.Date = DateTime.Today;

            ns = 15;
        }
    }
}
