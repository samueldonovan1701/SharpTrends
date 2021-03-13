using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Widgets
{
    public class TimeseriesJsonInterpreter
    {

        private DateTime _parseDateTime(string s)
        {
            var val = long.Parse(s);
            return val.ToUnixTime();
        }
        public Timeseries Interpret(string json)
        {
            var ts = new Timeseries();

            if (String.IsNullOrEmpty(json))
                return ts;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<TimeseriesJSON.Response>(json).Default;

            //Averages
            foreach (var jsonAvg in jsonObj.Averages)
                ts.Averages.Add(jsonAvg);

            //Values
            foreach(var jsonData in jsonObj.TimelineData)
            {
                var p = new TimePoint();
                p.Time = _parseDateTime(jsonData.Time);
                foreach (var jsonVal in jsonData.Value)
                    p.Value.Add(jsonVal);

                ts.Add(p);
            }

            return ts;
        }
    }
}
