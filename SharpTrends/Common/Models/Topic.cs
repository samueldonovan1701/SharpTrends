using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends
{
    public class Topic : IEquatable<string>
    {
        public string MID;
        public string Name;
        public string Type;
        public Topic(string keyword, string name = "", string type = "")
        {
            MID = keyword;
            Name = name;
            Type = type;
        }

        public bool Equals(string mid)
        {
            if (mid == null)
                return false;
            return MID.Equals(mid);
        }

        public override bool Equals(Object obj)
        {
            Topic other = obj as Topic;
            if (other == null)
                return false;
            return this.MID.Equals(other.MID);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.Name))
                return this.MID;
            return this.Name;
        }

        public override int GetHashCode()
        {
            return this.MID.GetHashCode();
        }
    }
}
