namespace SharpTrends
{
    public static class SearchMediums
    {
        public static SearchMedium Web => new SearchMedium("", "Web Search");
        public static SearchMedium Image => new SearchMedium("images", "Image Search");
        public static SearchMedium News => new SearchMedium("news", "News Search");
        public static SearchMedium Shopping => new SearchMedium("froogle", "Google Shopping");
        public static SearchMedium YouTube => new SearchMedium("youtube", "YouTube Search");

        public static SearchMedium Default => Web;
    }
}
