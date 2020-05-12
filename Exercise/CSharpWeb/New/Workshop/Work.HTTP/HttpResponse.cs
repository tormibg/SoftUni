using System.Collections.Generic;
using System.Text;
using static Work.HTTP.HttpConstants;

namespace Work.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(HttpResponseCode code, byte[] body) : this()
        {
            this.Code = code;
            this.Body = body;
            // if (body != null && body.Length > 0)
            if (body?.Length > 0)
            {
                this.Headers.Add(new Header("Content-Length", body.Length.ToString()));
            }
        }

        internal HttpResponse()
        {
            this.Version = HttpVersionType.Http10;
            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();
        }
        public HttpVersionType Version { get; set; }
        public HttpResponseCode Code { get; set; }
        public IList<Header> Headers { get; set; }
        public IList<ResponseCookie> Cookies { get; set; }
        public byte[] Body { get; set; }
        public override string ToString()
        {
            var responseAsString = new StringBuilder();
            var httpVersionAsString = this.Version switch
            {
                HttpVersionType.Http10 => "HTTP/1.0",
                HttpVersionType.Http11 => "HTTP/1.1",
                HttpVersionType.Http20 => "HTTP/2.0",
                _ => "HTTP/1.0",
            };
            responseAsString.Append($"{httpVersionAsString} {(int)this.Code} {this.Code}" + NewLine);
            foreach (var header in this.Headers)
            {
                responseAsString.Append(header + NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseAsString.Append($"Set-Cookie: " + cookie + NewLine);
            }
            responseAsString.Append(NewLine);
            return responseAsString.ToString();
        }
    }
}
