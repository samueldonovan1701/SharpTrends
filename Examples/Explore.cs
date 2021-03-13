using SharpTrends;
using SharpTrends.Explore;
using System;

namespace Examples
{
    public static class Explore
    {
        private static void print(ExploreResult data)
        {
            Console.WriteLine($"Overview:");
            Console.WriteLine($"\tSpanning Timeseries : {data.Timeseries != null}");
            Console.WriteLine($"\tSpanning GeoMap: {data.GeoMap != null}");
            Console.WriteLine($"\tSpanning Related Topics: {data.RelatedTopics != null}");
            Console.WriteLine($"\tSpanning Related Queries: {data.RelatedQueries != null}");
            Console.WriteLine("");
            Console.WriteLine($"List of explored topics:");
            foreach (ExploreItem item in data.Keys)
            {
                Console.WriteLine($"\t{item.Topic.Name} ({item.Topic.MID}) [{item.Topic.Type}], {item.From} -> {item.To}, @{item.Geo.ID} ({item.Geo.Description})");
                Console.WriteLine($"\t\tTimeseries ({item.From} -> {item.To}): {data[item].Timeseries != null}");
                Console.WriteLine($"\t\tGeoMap ({item.Geo.ID}): {data[item].GeoMap != null}");
                Console.WriteLine($"\t\tRelated Topics ({item.Topic.MID}): {data[item].RelatedTopics != null}");
                Console.WriteLine($"\t\tRelated Queries ({item.Topic.Name}): {data[item].RelatedQueries != null}");
                Console.WriteLine("");
            }
        }


        public static void Keywords_Basic()
        {
            var client = new SharpTrends.Client();

            ExploreResult data = client.Explore("dog", "/m/0bt9lr");

            print(data);
        }

        public static void Topics_Basic()
        {
            var client = new SharpTrends.Client();

            var topicA = new Topic("dog", "dog", "Search Term");
            var topicB = new Topic("/m/0bt9lr", "Dog", "Animal");

            ExploreResult data = client.Explore(topicA, topicB);

            print(data);
        }

        public static void Items_Basic()
        {
            var client = new SharpTrends.Client();

            ExploreItem itemA = new ExploreItem("dog");
            ExploreItem itemB = new ExploreItem("/m/0bt9lr");

            ExploreResult data = client.Explore(itemA, itemB);

            print(data);
        }

        public static void Items_Geo()
        {
            var client = new SharpTrends.Client();

            ExploreItem itemA = new ExploreItem("/m/0bt9lr");
            itemA.Geo = GeoCodes.UnitedKingdom;

            ExploreItem itemB = new ExploreItem("/m/0bt9lr");
            itemB.Geo = GeoCodes.UnitedStates;

            ExploreResult data = client.Explore(itemA, itemB);

            print(data);
        }

        public static void Items_Time()
        {
            var client = new SharpTrends.Client();

            ExploreItem itemA = new ExploreItem("/m/0bt9lr");
            itemA.From = new DateTime(2015, 1, 1);
            itemA.To = new DateTime(2015, 12, 31);

            ExploreItem itemB = new ExploreItem("/m/0bt9lr");
            itemB.From = new DateTime(2020, 1, 1);
            itemB.To = new DateTime(2020, 12, 31);

            ExploreResult data = client.Explore(itemA, itemB);

            print(data);
        }

        public static void Params_Basic()
        {
            var client = new SharpTrends.Client();

            ExploreParams p = new ExploreParams();
            p.AddItem("dog");
            p.AddItem("/m/0bt9lr");

            ExploreResult data = client.Explore(p);

            print(data);
        }

        public static void Params_Time()
        {
            var client = new SharpTrends.Client();

            ExploreParams p = new ExploreParams();
            p.AddItem("dog");
            p.AddItem("/m/0bt9lr");

            p.SetFrom(new DateTime(2010, 1, 1));
            p.SetTo(new DateTime(2020, 12, 31));

            ExploreResult data = client.Explore(p);

            print(data);
        }

        public static void Params_Geo()
        {
            var client = new SharpTrends.Client();

            ExploreParams p = new ExploreParams();
            p.AddItem("dog");
            p.AddItem("/m/0bt9lr");

            p.SetGeo(GeoCodes.Australia);

            ExploreResult data = client.Explore(p);

            print(data);
        }
        
        public static void Params_Options()
        {
            var client = new SharpTrends.Client();

            ExploreParams p = new ExploreParams();
            var itemA = p.AddItem("/m/01yrx"); //Cat
            var itemB = p.AddItem("/m/0bt9lr"); //Dog
            p.SetFrom(DateTime.Now.AddDays(-7));
            p.SetTo(DateTime.Now);
            p.SetGeo(GeoCodes.Worldwide);
            p.Locale = Locales.Chinese_PRC;
            p.SearchMedium = SearchMediums.YouTube;
            p.TimeZone = TimeZones.UTC_p9;

            ExploreResult data = client.Explore(p);

            print(data);
        }
    }
}
