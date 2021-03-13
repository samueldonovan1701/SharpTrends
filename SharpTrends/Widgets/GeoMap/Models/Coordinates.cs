using System;

namespace SharpTrends.Widgets
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public double lat;
        public double lng;

        public bool Equals(Coordinates other)
        {
            if (other == null)
                return false;

            var latDiff = this.lat - other.lat;
            var lngDiff = this.lng - other.lng;
            var e = 0.00000001;
            return (latDiff < e) && (lngDiff < e);
        }
    }
}
