using SharpTrends;
using SharpTrends.DailyTrends;
using System;
using System.Collections.Generic;

namespace Examples
{
    public static class DailyTrends
    {
        public static void print(List<TrendingSearch> data)
        {
            foreach (var i in data)
            {
                Console.WriteLine($"{i.Title}:" +
                    $"\n\tDate:\t{i.Date}" +
                    $"\n\tTraffic:\t{i.Traffic:E2}" +
                    $"\n\tRelated:\t{String.Join(", ", i.RelatedQueries)}" +
                    $"\n\tArticles:\t{i.Articles.Count}");
            }
        }

        public static void Basic()
        {
            var client = new SharpTrends.Client();

            List<TrendingSearch> data = client.DailyTrends();

            print(data);
        }

        public static void Date()
        {
            var client = new SharpTrends.Client();

            List<TrendingSearch> data = client.DailyTrends(DateTime.Today.AddDays(-1));

            print(data);
        }

        public static void Params()
        {
            var client = new SharpTrends.Client();

            DailyTrendsParams p = new DailyTrendsParams()
            {
                Date = DateTime.Today.AddDays(-1),
                GeoCode = GeoCodes.UnitedKingdom,
            };

            List<TrendingSearch> data = client.DailyTrends(p);

            print(data);
        }
    }
}
