using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TaskHill.OldRequest
{
    public class VKConnection
    {
        public readonly string vkToken;
        public readonly string vkGroupId;
        public string server;
        public string key;
        public int lastEvent;
        public VKConnection(string token, string groupId)
        {
            vkToken = token;
            vkGroupId = groupId;
        }
        public static async Task Connect(VKConnection vk)
        {
            try
            {
                var request = await WebRequest.Create(
                    $"https://api.vk.com/method/groups.getLongPollServer?group_id={vk.vkGroupId}&access_token={vk.vkToken}&v=5.131")
                    .GetResponseAsync();
                StreamReader streamRead = new StreamReader(request.GetResponseStream());
                var jsonGet = JObject.Parse(streamRead.ReadToEnd());
                JToken jsonResponse = jsonGet.GetValue("response");
                vk.server = jsonResponse["server"].ToString();
                vk.key = jsonResponse["key"].ToString();
                vk.lastEvent = int.Parse(jsonResponse["ts"].ToString());
                return;
            }
            catch
            {
                MessageBox.Show("Хьюстон, мы не можем подключиться!");
                return;

            }
        }
    }
}
