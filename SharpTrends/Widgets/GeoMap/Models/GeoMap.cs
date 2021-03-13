using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class GeoMap : List<GeoPoint>
    {
    }
    public class GeoPoint
    {
        public GeoCode GeoCode;
        public Coordinates Coordinates;
        public List<int> Value;

        public GeoPoint()
        {
            GeoCode = new GeoCode("");
            Coordinates = new Coordinates();
            Value = new List<int>();
        }
    }
}
