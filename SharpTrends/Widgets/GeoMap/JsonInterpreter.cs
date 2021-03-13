using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Widgets
{
    public class GeoMapJsonInterpreter
    {
        public GeoMap Interpret(string json)
        {
            var map = new GeoMap();

            if (String.IsNullOrEmpty(json))
                return map;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<GeoMapJSON.Response>(json).Default.GeoMapData;

            foreach(var jsonData in jsonObj)
            {
                var p = new GeoPoint();
                p.GeoCode = new GeoCode(jsonData.GeoCode, jsonData.GeoName);

                if (jsonData.Coordinates != null)
                {
                    p.Coordinates.lat = jsonData.Coordinates.lat;
                    p.Coordinates.lng = jsonData.Coordinates.lng;
                }

                foreach(var val in jsonData.Value)
                    p.Value.Add(val);

                map.Add(p);
            }

            return map;
        }
    }
}
