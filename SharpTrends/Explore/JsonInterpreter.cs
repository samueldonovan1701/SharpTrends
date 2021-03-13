using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.Explore
{
    public class JsonInterpreter
    {
        private enum WidgetType
        {
            TIMESERIES,
            GEO_MAP,
            RELATED_QUERIES,
            RELATED_TOPICS,
            IGNORED //TITLE, topics_note
        }
        private WidgetType _getWidgetType(JSON.Widget widget)
        {
            if (widget.Id.StartsWith("TIME"))
                return WidgetType.TIMESERIES;
            else if (widget.Id.StartsWith("GEO"))
                return WidgetType.GEO_MAP;
            else if (widget.Id.StartsWith("RELATED_QUERIES"))
                return WidgetType.RELATED_QUERIES;
            else if (widget.Id.StartsWith("RELATED_TOPICS"))
                return WidgetType.RELATED_TOPICS;
            else
                return WidgetType.IGNORED;
        }
        private int _getWidgetIndex(JSON.Widget widget)
        {
            if (char.IsDigit(widget.Id[^1]))
            {   //Ends with a digit

                var i = widget.Id.LastIndexOf('_');
                var s = widget.Id.Substring(i + 1);
                return int.Parse(s);
            }
            else
            {   //Does not end with a digit
                return -1;
            }
        }
        private ExploreResult _extractWidgets(JSON.Response jsonObj, ExploreParams inputParams)
        {
            //Setup Extraction Point
            var result = new ExploreResult();
            foreach (var item in inputParams.Items)
            {
                var coll = new WidgetCollection();
                result.Add(item, coll);
            }

            //Extract Widgets
            foreach (var jsonWidget in jsonObj.Widgets)
            {
                //Get properties
                var type = _getWidgetType(jsonWidget);
                var index = _getWidgetIndex(jsonWidget);
                var token = jsonWidget.Token;
                var request = JsonConvert.SerializeObject(jsonWidget.Request);

                if (index == -1)
                {   //Global Widget
                    switch(type)
                    {
                        case (WidgetType.TIMESERIES):
                            result.Timeseries = new TimeseriesWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.GEO_MAP):
                            result.GeoMap = new GeoMapWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.RELATED_QUERIES):
                            result.RelatedQueries = new RelatedQueriesWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.RELATED_TOPICS):
                            result.RelatedTopics = new RelatedTopicsWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        default: //WidgetType.IGNORED
                            break;
                    }
                }
                else
                {   //Topic widget
                    switch (type)
                    {
                        case (WidgetType.TIMESERIES):
                            result[inputParams.Items[index]].Timeseries = new TimeseriesWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.GEO_MAP):
                            result[inputParams.Items[index]].GeoMap = new GeoMapWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.RELATED_QUERIES):
                            result[inputParams.Items[index]].RelatedQueries = new RelatedQueriesWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        case (WidgetType.RELATED_TOPICS):
                            result[inputParams.Items[index]].RelatedTopics = new RelatedTopicsWidget()
                            {
                                Token = token,
                                Request = request
                            };
                            break;
                        default: //WidgetType.IGNORED
                            break;
                    }
                }
            }

            return result;
        }

        public ExploreResult Interpret(string json, ExploreParams inputParams)
        {
            //Input validation
            if (String.IsNullOrEmpty(json))
                return new ExploreResult();

            //Parse JSON
            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<JSON.Response>(json);

            //Get items
            _extractItems(jsonObj, ref inputParams);

            //Get widgets
            var result = _extractWidgets(jsonObj, inputParams);

            return result;
        }

        private void _extractItems(JSON.Response jsonObj, ref ExploreParams p)
        {
            foreach(var item in p.Items)
            {
                foreach(var jsonTopic in jsonObj.Keywords)
                {
                    if(item.Topic.MID == jsonTopic.Value)
                    {
                        item.Topic.Name = jsonTopic.Name;
                        item.Topic.Type = jsonTopic.Type;
                        //jsonObj.Keywords.Remove(jsonTopic);
                        break;
                    }
                }
            }
        }
    }
}
