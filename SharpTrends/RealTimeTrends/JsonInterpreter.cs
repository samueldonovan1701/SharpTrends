using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.RealTimeTrends
{
    public class JsonInterpreter
    {
        public List<NewsStoryWidget> Interpret(string json)
        {
            //Vars
            var r = new List<NewsStoryWidget>();

            //Input validation
            if (String.IsNullOrEmpty(json))
                return r;

            //Convert json
            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<JSON.Response>(json);

            //Feature Stories
            foreach (var jsonStoryID in jsonObj.FeaturedStoryIds)
                r.Add(new NewsStoryWidget() { ID = jsonStoryID, isFeatured = true });

            //Trending Stories
            foreach (var jsonStoryID in jsonObj.TrendingStoryIds)
                r.Add(new NewsStoryWidget() { ID = jsonStoryID, isFeatured = false});

           return r;
        }
    }
}
