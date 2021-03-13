using System.Collections.Generic;

namespace SharpTrends.Explore
{
    public class ExploreCategory
    {
        public int ID;
        public string Description;
        public ExploreCategory(int id, string description="N/A")
        {
            ID = id;
            Description = description;
        }
        override public string ToString()
        {
            return Description;
        }
    }
}