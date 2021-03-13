using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Widgets
{
    public class Timeseries : List<TimePoint>
    {
        public List<int> Averages;

        public Timeseries()
        {
            Averages = new List<int>();
        }
    }
    public class TimePoint
    {
        public DateTime Time;
        public List<int> Value;

        public TimePoint()
        {
            Value = new List<int>();
        }
    }
}
