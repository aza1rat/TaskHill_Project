using AngleSharp.Html.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskHill.Properties;

namespace TaskHill.OldRequest
{
    public class VKAction
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<JObject> GetEvent(VKConnection connection)
        {
            var values = new Dictionary<string, string>
            {
                { "act", "a_check" },
                { "key", connection.key },
                { "ts", connection.lastEvent.ToString() },
                { "wait", "25" }
            };
            var response = await client.PostAsync(connection.server, new FormUrlEncodedContent(values));
            string responseString = await response.Content.ReadAsStringAsync();
            JObject jsonGet = JObject.Parse(responseString);
            return jsonGet;
        }
        public static async Task<Object> EditMessage(VKConnection connection, int peerid, string message, int messageid)
        {
            var values = new Dictionary<string, string>
            {
                { "access_token", connection.vkToken },
                { "v", "5.131" },
                { "message", message },
                { "message_id", messageid.ToString() },
                { "peer_id", peerid.ToString() }
            };
            var response = await client.PostAsync($"https://api.vk.com/method/messages.edit", new FormUrlEncodedContent(values));
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public static async Task<Object> SavePage(Request request)
        {
            var values = new Dictionary<string, string>
            {
                { "access_token", Properties.Resources.kme },
                { "text", request.ToString() },
                { "page_id", Resources.idpage },
                { "group_id", Resources.idkit },
                { "user_id", Resources.idme },
                { "v", "5.131" }
            };
            var response = await client.PostAsync($"https://api.vk.com/method/pages.save", new FormUrlEncodedContent(values));
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        public static async Task<JObject> GetRequestAsync(string site)
        {
            var parser = new HtmlParser();
            string document = await client.GetStringAsync(site);
            var doc = parser.ParseDocument(document);
            var parsed = doc.QuerySelector("div.wiki_body");
            return JObject.Parse(parsed.TextContent);
        }
    }
}
