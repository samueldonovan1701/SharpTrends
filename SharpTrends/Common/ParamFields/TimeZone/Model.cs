using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends
{
    public class TimeZone
    {
        public TimeSpan UTC_Offset;
        public string Description;

        public TimeZone(TimeSpan UTC_Offset)
        {
            Description = "UTC" + (UTC_Offset < TimeSpan.Zero ? "-" : "+") + UTC_Offset.ToString(@"hh\:mm");
            this.UTC_Offset = UTC_Offset;
        }

        public override string ToString()
        {
            return Description;
        }

        public override int GetHashCode()
        {
            return UTC_Offset.GetHashCode();
        }
    }
}
