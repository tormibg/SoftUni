using System;
using System.Text;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpRequest
    {
        public readonly string URL;

        public readonly RequestMethod Method;

        public HttpRequest(string url, RequestMethod method)
        {
            this.Method = method;
            this.URL = url;
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public string Content { get; set; }

        public Header Header { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Method} {this.URL} HTTP/1.0");
            sb.AppendLine($"{Header}");
            sb.AppendLine();
            sb.AppendLine();
            if (this.Method == RequestMethod.POST && !String.IsNullOrEmpty(this.Content))
            {
                sb.AppendLine(this.Content);
            }
            return sb.ToString();
        }
    }
}