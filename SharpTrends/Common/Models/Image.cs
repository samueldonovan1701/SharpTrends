using System;

namespace SharpTrends
{
    public class Image
    {
        public Uri Uri;
        public Uri SourceUri;
        public string Source;

        public override bool Equals(Object obj)
        {
            Image other = obj as Image;
            if (other == null)
                return false;
            return this.Uri.Equals(other.Uri);
        }

        public override int GetHashCode()
        {
            return this.Uri.GetHashCode();
        }
    }
}
