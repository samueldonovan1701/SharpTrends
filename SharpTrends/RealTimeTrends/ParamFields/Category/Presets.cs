using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.RealTimeTrends
{ 
    public static class Categories
    {
        public static Category All => new Category("all", "All Categories");
        public static Category Business => new Category("b", "Business");
        public static Category Entertainment => new Category("e", "Entertainment");
        public static Category Health => new Category("m", "Health");
        public static Category SciTech => new Category("t", "Sci/Tech");
        public static Category Sports => new Category("s", "Sports");
        public static Category TopStories => new Category("h", "TopStories");
    }
}
