using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace SharpTrends
{
    public class QueryStringBuilder : Dictionary<string, string>
    {
        private string Encode(string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            var sb = new StringBuilder();
            
            foreach (char c in str)
            {
                if((",A-z0-9~._-").IndexOf(c) == -1)
                    sb.AppendFormat("%{0:X2}", (byte)c);
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        public void Add(string key, object value)
        {
            base.Add(key, value.ToString());
        }


        public override string ToString()
        {
            var qs = "";

            foreach (var kvp in this)
            {
                qs += Encode(kvp.Key) + "=" + Encode(kvp.Value)+"&";
            }

            if(this.Count != 0)
                qs = qs.Substring(0, qs.Length - 1);

            return qs;
        }
    }
}
