using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskHill.Properties;

namespace TaskHill.OldRequest
{
    public class Request
    {
        private static VKConnection connection;
        private readonly string address;
        public enum RequestType { GET, POST, PUT, DELETE };
        private readonly RequestType type;
        private readonly string body;

        public Request(string address, RequestType type, JObject json)
        {
            this.address = address;
            this.type = type;
            this.body = json.ToString();

        }

        public static void SetConnection(VKConnection vkConnection)
        {
            connection = vkConnection;
        }

        public Request(string address, RequestType type, JArray json)
        {
            this.address = address;
            this.type = type;
            this.body = json.ToString();
        }

        public override string ToString()
        {
            JObject jObject = new JObject
            {
                { "address", address },
                { "type", type.ToString() },
                { "body", body }
            };
            return jObject.ToString();
        }

        public async Task<Response> Send()
        {
            await VKConnection.Connect(connection);
            bool AreGetting = true;
            await VKAction.SavePage(this);
            await VKAction.EditMessage(connection,int.Parse(Resources.idme), "Sending", int.Parse(Resources.editid));
            while (AreGetting)
            {
                JObject response = await VKAction.GetEvent(connection);
                JArray events = JArray.Parse(response["updates"].ToString());
                if (events.Count != 0)
                {
                    foreach (JToken selectedEvent in events)
                    {
                        switch (selectedEvent["type"].ToString())
                        {
                            case "message_edit":
                                JToken gettedMessage = selectedEvent["object"];
                                if (gettedMessage["text"].ToString() == "Returning")
                                {
                                    JObject jsonRequest = await VKAction.GetRequestAsync($"https://vk.com/page-{Resources.idkit}_{Resources.idpage}");
                                    return new Response(jsonRequest);
                                }
                                break;
                        }
                    }
                    ++connection.lastEvent;
                }
            }
            return new Response(null);
        }
    }
}
