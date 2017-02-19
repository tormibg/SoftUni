using System;
using System.Text;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpResponse
    {

        public HttpResponse(ResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }

        public byte[] Content { get; set; }

        public string ContentAsUtf8
        {
            set { this.Content = Encoding.UTF8.GetBytes(value); }
        }

        public Header Header { get; set; }

        public ResponseStatusCode StatusCode { get; set; }

        private string StringMessage => Enum.GetName(typeof(ResponseStatusCode), this.StatusCode);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"HTTP/1.0 {this.StatusCode} {this.StringMessage}");
            sb.AppendLine($"{Header}");
            return sb.ToString();
        }
    }
}