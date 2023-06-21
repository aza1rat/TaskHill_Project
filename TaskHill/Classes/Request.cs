using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace TaskHill.Classes
{
    class Request
    {
        private static readonly string _root = "http://azaservice.ru";
        private readonly string _url;
        private readonly string _body;
        private int _code;
        private string _answer;
        private readonly HttpWebRequest _request;
        public Request(string url, string body, string method)
        {
            _body = body;
            _url = url;
            _request = WebRequest.CreateHttp(_root + _url);
            _request.Method = method;
            _request.ContentType = "application/json";

        }

        public async Task<Response> Send()
        {
            using (var body = new StreamWriter(_request.GetRequestStream()))
                body.Write(_body);
            var httpResponse = (HttpWebResponse)_request.GetResponse();
            _code = (int)httpResponse.StatusCode;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = await streamReader.ReadToEndAsync();
                _answer = result;
            }
            return new Response(_code, _answer);
        }
    }
}
