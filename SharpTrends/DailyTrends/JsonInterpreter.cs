using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharpTrends.DailyTrends
{
    public class JsonInterpreter
    {
        private TimeSpan _parseTimeAgo(string str)
        {
            char[] possibleUnits = { 'y', 'w', 'd', 'h', 'm', 's' };
            char unit;
            string digits;

            //Get unit index
            int unitIndex = str.IndexOfAny(possibleUnits);

            //Get unit
            unit = str[unitIndex];

            //Get digit substring
            digits = str.Substring(0, unitIndex);

            //Parse digits & Invert (time ago)
            int quanta = -Int32.Parse(digits);
            var ts = unit switch
            {
                'y' => (DateTime.Now.AddYears(quanta) - DateTime.Now),
                'w' => TimeSpan.FromDays(quanta * 7),
                'd' => TimeSpan.FromDays(quanta),
                'h' => TimeSpan.FromHours(quanta),
                'm' => TimeSpan.FromMinutes(quanta),
                's' => TimeSpan.FromSeconds(quanta),
                _ => new TimeSpan()
            };
            return ts;
        }
        private double _parseTrafic(string str)
        {

            //Example string: "50K+"
            char[] possibleUnits = { 'B', 'M', 'K', '+' };
            char unit;
            string digits;

            //Get unit index
            int unitIndex = str.IndexOfAny(possibleUnits);
            if (unitIndex == -1)
                return -1;

            //Get unit
            unit = str[unitIndex];

            //Get digit substring
            digits = str.Substring(0, unitIndex);

            //Parse digits
            try
            {
                int quanta = Int32.Parse(digits);
                var traffic = unit switch
                {
                    'B' => quanta * Math.Pow(10, 9),
                    'M' => quanta * Math.Pow(10, 6),
                    'K' => quanta * Math.Pow(10, 3),
                    _ => quanta
                };
                return traffic;
            } catch
            {
                return -1;
            }
        }
        private Article _parseArticle(JSON.Article jsonArticle)
        {
            var article = new Article();

            //Input validation
            if (jsonArticle == null)
                return article;

            //Title
            article.Title = jsonArticle.Title;

            //Time Stamp
            article.TimeAgo = _parseTimeAgo(jsonArticle.TimeAgo);

            //Extract URI, if present
            if(!String.IsNullOrEmpty(jsonArticle.Url))
                article.Uri = new Uri(jsonArticle.Url);

            //Source
            article.SourceName = jsonArticle.Source;

            //Image
            article.Image = _parseImage(jsonArticle.Image);

            //Snippet
            article.Snippet = jsonArticle.Snippet;

            return article;
        }
        private Image _parseImage(JSON.Image jsonImg)
        {
            //Input validation
            if (jsonImg == null)
                return null;

            var img = new Image();

            //Extract Image's URI, if present
            if (!String.IsNullOrEmpty(jsonImg.ImageUrl))
                img.Uri = new Uri(jsonImg.ImageUrl);

            //Extract Source's URI, if present
            if (!String.IsNullOrEmpty(jsonImg.NewsUrl))
                img.SourceUri = new Uri(jsonImg.NewsUrl);

            //Set source
            img.Source = jsonImg.Source;

            return img;
        }
        private TrendingSearch _parseTrend(JSON.TrendingSearch jsonTrend)
        {
            var trend = new TrendingSearch()
            {
                //Title
                Title = jsonTrend.Title.Query ?? String.Empty,
                //Traffic
                Traffic = _parseTrafic(jsonTrend.FormattedTraffic),
                //Image
                Image = _parseImage(jsonTrend.Image),
                //Related Queries
                RelatedQueries = new List<string>()
            };


            foreach (var jsonQuery in jsonTrend.RelatedQueries)
            {
                trend.RelatedQueries.Add(jsonQuery.Query);
            }

            //Articles
            trend.Articles = new List<Article>();
            foreach (var jsonArticle in jsonTrend.Articles)
            {
                trend.Articles.Add(_parseArticle(jsonArticle));
            }

            return trend;
        }
        private DateTime _parseDate(JSON.TrendingSearchesDay jsonDay)
        {
            try
            {
                return DateTime.ParseExact(jsonDay.Date, "yyyyMMdd", null);
            } catch
            {
                return DateTime.MinValue;
            }
        }

        public List<TrendingSearch> Interpret(string json)
        {
            //Vars
            var list = new List<TrendingSearch>();

            //Input validation
            if (String.IsNullOrEmpty(json))
                return list;

            //Convert json
            json = json.Substring(5);
            var jsonObj = JsonConvert.DeserializeObject<JSON.Response>(json);

            //Special case (nothing from json)
            if (jsonObj.Default.TrendingSearchesDays.Count == 0) 
                return list;

            //Get first day (json often contains multiple)
            var jsonDay = jsonObj.Default.TrendingSearchesDays[0]; 

            //Extract date
            DateTime date = _parseDate(jsonDay);

            //Extract trends
            foreach (var jsonTrend in jsonDay.TrendingSearches)
            {
                var trend = _parseTrend(jsonTrend);
                trend.Date = date;
                list.Add(trend);
            }

            return list;
        }
    }
}
