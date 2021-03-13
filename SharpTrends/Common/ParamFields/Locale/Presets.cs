using System.Globalization;

namespace SharpTrends
{
    public static class Locales
    {
        public static Locale Arabic => new Locale("ar", "Arabic");
        public static Locale English_UK => new Locale("en-GB", "English (United Kingdom)");
        public static Locale English_US => new Locale("en-US", "English (United States)");
        public static Locale Hebrew => new Locale("iw", "Hebrew");
        public static Locale Chinese_PRC => new Locale("zh-CN", "Chinese (PRC)");
        public static Locale Chinese_Taiwan => new Locale("zh-TW", "Chinese (Taiwan)");

        public static Locale Default
        {
            get
            {
                var sysLocale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

                if (sysLocale == "ar")
                    return Arabic;
                else if (sysLocale == "zh")
                    return Chinese_PRC;
                else if (sysLocale == "iw")
                    return Hebrew;
                else
                    return English_UK;
            }
        }
    }
}
