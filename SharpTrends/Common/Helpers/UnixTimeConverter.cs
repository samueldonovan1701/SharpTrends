using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends
{
    public static class UnixTimeConverter
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToUnixTime(this long timestamp)
        {
            return epoch.AddSeconds(timestamp);
        }
    }
}
