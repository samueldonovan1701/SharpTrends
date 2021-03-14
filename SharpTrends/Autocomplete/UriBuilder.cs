using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Autocomplete
{
    public class UriBuilder
    {
        public Uri BuildUri(AutocompleteParams p)
        {
            var qsb = new QueryStringBuilder
            {
                { "hl", p.Locale.Code }
            };
            var qs = qsb.ToString();

            return new Uri($"https://trends.google.com/trends/api/autocomplete/{p.Snippet}?{qs}");
        }
    }
}
