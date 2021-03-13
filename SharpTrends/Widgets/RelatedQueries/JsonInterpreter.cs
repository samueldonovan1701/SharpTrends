using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Widgets
{
    public class RQJsonInterpreter
    {
        public RelatedQueries Interpret(string json)
        {
            var rt = new RelatedQueries();

            if (String.IsNullOrEmpty(json))
                return rt;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<RQJSON.Response>(json).Default;

            //Top
            foreach (var jsonKeyword in jsonObj.RankedList[0].RankedKeyword)
            {
                rt.Top.Add(new RelatedQuery()
                {
                    Query = jsonKeyword.Query,
                    Value = jsonKeyword.Value
                });
            }

            //Rising
            foreach (var jsonKeyword in jsonObj.RankedList[1].RankedKeyword)
            {
                rt.Rising.Add(new RelatedQuery()
                {
                    Query = jsonKeyword.Query,
                    Value = jsonKeyword.Value
                });
            }

            return rt;
        }
    }
}
