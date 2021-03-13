using System;

namespace SharpTrends
{
    public static class TimeZones
    {
        public static TimeZone US_EST => UTC_m5;
        public static TimeZone US_CT => UTC_m6;
        public static TimeZone US_MT => UTC_m7;
        public static TimeZone US_PT => UTC_m8;
        public static TimeZone US_AK => UTC_m9;
        public static TimeZone US_HAST => UTC_m10;


        public static TimeZone UTC_m12 => new TimeZone(new TimeSpan(-12, 0, 0));
        public static TimeZone UTC_m11 => new TimeZone(new TimeSpan(-11, 0, 0));
        public static TimeZone UTC_m10 => new TimeZone(new TimeSpan(-10, 0, 0));
        public static TimeZone UTC_m9 => new TimeZone(new TimeSpan(-9, 0, 0));
        public static TimeZone UTC_m8 => new TimeZone(new TimeSpan(-8, 0, 0));
        public static TimeZone UTC_m7 => new TimeZone(new TimeSpan(-7, 0, 0));
        public static TimeZone UTC_m6 => new TimeZone(new TimeSpan(-6, 0, 0));
        public static TimeZone UTC_m5 => new TimeZone(new TimeSpan(-5, 0, 0));
        public static TimeZone UTC_m4 => new TimeZone(new TimeSpan(-4, 0, 0));
        public static TimeZone UTC_m3 => new TimeZone(new TimeSpan(-3, 0, 0));
        public static TimeZone UTC_m2 => new TimeZone(new TimeSpan(-2, 0, 0));
        public static TimeZone UTC_m1 => new TimeZone(new TimeSpan(-1, 0, 0));
        public static TimeZone UTC => new TimeZone(new TimeSpan(0, 0, 0));
        public static TimeZone UTC_p1 => new TimeZone(new TimeSpan(1, 0, 0));
        public static TimeZone UTC_p2 => new TimeZone(new TimeSpan(2, 0, 0));
        public static TimeZone UTC_p3 => new TimeZone(new TimeSpan(3, 0, 0));
        public static TimeZone UTC_p4 => new TimeZone(new TimeSpan(4, 0, 0));
        public static TimeZone UTC_p5 => new TimeZone(new TimeSpan(5, 0, 0));
        public static TimeZone UTC_p6 => new TimeZone(new TimeSpan(6, 0, 0));
        public static TimeZone UTC_p7 => new TimeZone(new TimeSpan(7, 0, 0));
        public static TimeZone UTC_p8 => new TimeZone(new TimeSpan(8, 0, 0));
        public static TimeZone UTC_p9 => new TimeZone(new TimeSpan(9, 0, 0));
        public static TimeZone UTC_10 => new TimeZone(new TimeSpan(10, 0, 0));
        public static TimeZone UTC_p11 => new TimeZone(new TimeSpan(11, 0, 0));
        public static TimeZone UTC_p12 => new TimeZone(new TimeSpan(12, 0, 0));


        public static TimeZone Default
        {
            get
            {
                var sysUTCOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);

                return new TimeZone(sysUTCOffset);
            }
        }
    }
}
