using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharpTrends
{
    internal static class HttpClientExtensions
    {
        public static async Task<string> RetrieveJson(this HttpClient client, Uri uri)
        {
            var resp = await client.GetAsync(uri);

            if (!resp.IsSuccessStatusCode)
                throw new HttpRequestException("HttpRequest unsuccessful. Status code: " + resp.StatusCode);
            else if (resp.Content.Headers.ContentType.MediaType != "application/json")
                throw new HttpRequestException("Endpoint did not return a JSON");

            var json = resp.Content.ReadAsStringAsync().Result;
            return json;
        }
    }
}
