using SharpTrends;
using SharpTrends.Autocomplete;
using System;
using System.Collections.Generic;

namespace Examples
{
    public static class Autocomplete
    {
        public static void print(List<Topic> data)
        {
            foreach (var i in data)
            {
                Console.WriteLine($"{i.Name} ({i.MID}), {i.Type}");
            }
        }

        public static void Basic()
        {
            var client = new SharpTrends.Client();

            List<Topic> data = client.Autocomplete("dog");

            print(data);
        }

        public static void Params()
        {
            var client = new SharpTrends.Client();

            var p = new AutocompleteParams()
            {
                Snippet = "dog"
            };
            p.Locale = Locales.Chinese_PRC;
            p.TimeZone = TimeZones.Default;

            List<Topic> data = client.Autocomplete(p);

            print(data);
        }
    }
}
