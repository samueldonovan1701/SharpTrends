using System;

namespace SharpTrends
{
    public class Article
    {
        public string Title;
        public TimeSpan TimeAgo;
        public Uri Uri;
        public string SourceName;
        public Image Image;
        public string Snippet;
        public override bool Equals(Object obj)
        {
            Article other = obj as Article;
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
