using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.YearInSearch
{
    public class JsonInterpreter
    {
        public Dictionary<string, List<string>> Interpret(string json)
        {
            //Vars
            var dic = new Dictionary<string, List<string>>();

            //Input validation
            if (String.IsNullOrEmpty(json))
                return dic;

            //Convert json
            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<JSON.Response>(json);

            //Extract Lists
            foreach (var jsonList in jsonObj.TopCharts)
            {
                var list = new List<string>();

                foreach (var jsonItem in jsonList.ListItems)
                    list.Add(jsonItem.Title);
                
                dic.Add(jsonList.ListTitle, list);
            }

            return dic;
        }
    }
}
