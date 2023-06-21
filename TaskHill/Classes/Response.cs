using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHill.Classes
{
    public class Response
    {
        public int Code;
        public JObject Body;
        public JArray BodyArray;
        public Response(int code, string body)
        {
            Code = code;
            try
            {
                BodyArray = JArray.Parse(body);
            }
            catch
            {
                try
                {
                    Body = JObject.Parse(body);
                }
                catch
                {
                    Body = null;
                }
            }
        }
    }
}
