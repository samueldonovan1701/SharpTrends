using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Widgets
{
    public class RTJsonInterpreter
    {
        public RelatedTopics Interpret(string json)
        {
            var rt = new RelatedTopics();

            if (String.IsNullOrEmpty(json))
                return rt;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<RTJSON.Response>(json).Default;

            //Top
            foreach (var jsonKeyword in jsonObj.RankedList[0].RankedKeyword)
            {
                rt.Top.Add(new RelatedTopic()
                {
                    Topic = new Topic(jsonKeyword.Topic.Mid, jsonKeyword.Topic.Title, jsonKeyword.Topic.Type),
                    Value = jsonKeyword.Value
                });
            }

            //Rising
            foreach (var jsonKeyword in jsonObj.RankedList[1].RankedKeyword)
            {
                rt.Rising.Add(new RelatedTopic()
                {
                    Topic = new Topic(jsonKeyword.Topic.Mid, jsonKeyword.Topic.Title, jsonKeyword.Topic.Type),
                    Value = jsonKeyword.Value
                });
            }

            return rt;
        }
    }
}
