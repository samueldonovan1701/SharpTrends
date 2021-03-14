using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SharpTrends.YearInSearch
{
    public class YearInSearchParams
    {
        public Locale Locale;
        public GeoCode GeoCode;
        public int Year;

        public YearInSearchParams()
        {
            this.Locale = Locales.Default;
            this.Year = DateTime.Now.Year - 1;
            this.GeoCode = GeoCodes.Default;
        }
    }
}
