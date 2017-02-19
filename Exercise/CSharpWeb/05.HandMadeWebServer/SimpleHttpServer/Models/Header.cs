using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class Header
    {
        public Header(HeaderType type)
        {
            this.Type = type;
            this.ContentType = "text/html";
            this.Cokies = new CookieCollection();
            this.OthersParameters = new Dictionary<string, string>();
        }

        public Dictionary<string, string> OthersParameters { get; set; }

        public CookieCollection Cokies { get; set; }

        public string ContentType { get; set; }

        public HeaderType Type { get; private set; }

        public string ContentLenght { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Content-Type: " + this.ContentType);
            if (this.Cokies.Any())
            {
                if (this.Type == HeaderType.HttpRequest)
                {
                    sb.AppendLine("Cokie: " + this.Cokies.ToString());
                }
                else if (this.Type == HeaderType.HttpResponse)
                {
                    foreach (var cookie in Cokies)
                    {
                        sb.AppendLine("Set-Cookie: " + cookie);
                    }
                }
            }
            if (this.ContentType != null)
            {
                sb.AppendLine("Content-Length: " + this.ContentType);
            }
            foreach (var othersParameter in this.OthersParameters)
            {
                sb.AppendLine($"{othersParameter.Key}: {othersParameter.Value}");
            }
            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}