using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.RealTimeTrends
{ 
    public class Category
    {
        public string ID;
        public string Description;
        public Category(string id, string description = "N/A")
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
