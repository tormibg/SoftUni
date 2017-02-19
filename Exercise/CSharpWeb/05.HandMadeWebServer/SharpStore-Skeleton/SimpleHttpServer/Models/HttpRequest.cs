namespace SimpleHttpServer.Models
{
    using Enums;

    public class HttpRequest
    {
        public RequestMethod Method { get; set; }
        public string Url { get; set; }
        //public string Path { get; set; } // either the Url, or the first regex group
        public string Content { get; set; }

        public Header Header { get; set; }

        public HttpRequest()
        {
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public override string ToString()
        {
            return $"{this.Method} {this.Url} HTTP/1.0\r\n{this.Header}{this.Content}";
        }
    }
}
