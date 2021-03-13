namespace SharpTrends
{ 
    public class Locale
    {
        public string Code;
        public string Description;

        public Locale(string code, string description="N/A")
        {
            Code = code;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Description} ({Code})";
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
