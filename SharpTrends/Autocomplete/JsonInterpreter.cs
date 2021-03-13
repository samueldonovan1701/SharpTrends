using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTrends.Autocomplete
{
    public class JsonInterpreter
    {
        private List<Topic> _extractTopics(JSON.Response jsonObj)
        {
            var list = new List<Topic>();

            foreach (var jsonTopic in jsonObj.Default.Topics)
            {
                list.Add(new Topic(jsonTopic.Mid)
                {
                    Name = jsonTopic.Title,
                    Type = jsonTopic.Type
                });
            }

            return list;
        }
        public List<Topic> Interpret(string json)
        {
            var list = new List<Topic>();

            if (String.IsNullOrEmpty(json))
                return list;

            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<JSON.Response>(json);

            list = _extractTopics(jsonObj);
            
            return list;
        }
    }
}
