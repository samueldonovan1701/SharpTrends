namespace SharpTrends
{
    public class SearchMedium
    {
        public string Code;
        public string Description;
        public SearchMedium(string code, string description="N/A")
        {
            Code = code;
            Description = description;
        }
        public override string ToString()
        {
            return Description;
        }
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}