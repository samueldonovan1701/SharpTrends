using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SharpTrends.YearInSearch
{
    public class YearInSearchParams
    {
        public Locale Locale;
        public TimeZone TimeZone;
        public int Year;
        public GeoCode GeoCode;
        public bool isMobile;

        public YearInSearchParams()
        {
            this.Locale = Locales.Default;
            this.TimeZone = TimeZones.Default;
            this.Year = DateTime.Now.Year - 1;
            this.GeoCode = GeoCodes.Default;
            this.isMobile = false;
        }
    }
}
