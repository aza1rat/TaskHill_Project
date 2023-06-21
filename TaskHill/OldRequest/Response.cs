using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskHill.OldRequest
{
    public class Response
    {
        public int code;
        public string body;
        public JObject Body;
        public JArray BodyArray;

        public Response(JObject response)
        {
            this.code = response["status"].Value<int>();
            try
            {
                this.body = response["body"].ToString();
            }
            catch (NullReferenceException ex) { 
                body = null; return; 
            };
            try
            {
                this.BodyArray = JArray.Parse(body);
            }
            catch
            {
                this.Body = JObject.Parse(body);
            }
        }
    }
}
