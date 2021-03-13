using System.Collections.Generic;

namespace SharpTrends.Explore
{
    //and <see href="https://trends.google.com/trends/api/explore/pickers/category?hl=en-US&tz=240"/>

    public class ExploreCategories
    {
        /// See <see href="https://github.com/pat310/google-trends-api/wiki/Google-Trends-Categories"/>
        public static ExploreCategory All => new ExploreCategory(0, "All");
    }
}