namespace SharpTrends
{
    public class GeoCode
    {
        public string ID;
        public string Description;

        public GeoCode(string id, string description="N/A")
        {
            ID = id;
            Description = description;
        }


        public override string ToString()
        {
            return $"{Description} ({ID})";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
