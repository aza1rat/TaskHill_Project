using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHill.Classes
{
    public static class Helper
    {
        public static string SessionToken;
        public static void SaveSession()
        {
            if (!File.Exists("session.json"))
                File.Create("session.json");
            JObject jsonSession = new JObject();
            jsonSession.Add("token", SessionToken);
            File.WriteAllText("session.json",jsonSession.ToString());
        }
        public static void LoadSession()
        {
            string jsonSession = File.ReadAllText("session.json");
            JObject session = JObject.Parse(jsonSession);
            SessionToken = session["token"].ToString();
        }

        public static async void DropSession()
        {
            JObject key = new JObject()
            {
                {"token",SessionToken }
            };
            Request request = new Request("/sessions/method", key.ToString(), "DELETE");
            try
            {
                Response response = await request.Send();
            }
            catch (Exception ex) {
                Logger.Write(new string[]
                {
                    ex.Message
                }, System.ConsoleColor.Yellow);
            };
        }
    }
}
