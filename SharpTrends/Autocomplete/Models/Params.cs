using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SharpTrends.Autocomplete
{
    public class AutocompleteParams
    {
        public Locale Locale;
        public TimeZone TimeZone;
        public string Snippet;
        public AutocompleteParams()
        {
            this.Snippet = "";
            this.Locale = Locales.Default;
            this.TimeZone = TimeZones.Default;
        }
    }
}
