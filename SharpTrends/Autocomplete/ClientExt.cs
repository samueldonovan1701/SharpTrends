using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpTrends.Autocomplete
{
    public static class ClientExt
    {
        private readonly static Autocomplete.UriBuilder _uriBuilder;
        private readonly static Autocomplete.JsonInterpreter _jsonInterpreter;
        static ClientExt()
        {
            _uriBuilder = new Autocomplete.UriBuilder();
            _jsonInterpreter = new Autocomplete.JsonInterpreter();
        }

        public static async Task<List<Topic>> AutocompleteAsync(this Client client, AutocompleteParams p)
        {
            var uri = _uriBuilder.BuildUri(p);

            var response = await client.HttpClient.RetrieveJson(uri);

            var data = _jsonInterpreter.Interpret(response);

            return data;
        }
        public static async Task<List<Topic>> AutocompleteAsync(this Client client, string snippet)
        {
            var p = new AutocompleteParams()
            {
                Snippet = snippet
            };

            return await client.AutocompleteAsync(p);
        }

        public static List<Topic> Autocomplete(this Client client, AutocompleteParams p)
        {
            return client.AutocompleteAsync(p).Result;
        }
        public static List<Topic> Autocomplete(this Client client, string snippet)
        {
            return client.AutocompleteAsync(snippet).Result;
        }
    }
}
