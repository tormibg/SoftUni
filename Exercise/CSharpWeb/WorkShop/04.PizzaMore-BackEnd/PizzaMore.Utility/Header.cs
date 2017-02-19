using System;
using System.Text;

namespace PizzaMore.Utility
{
    public class Header
    {
        public Header()
        {
            this.Type = "Content-type: text/html";
            this.Cookies = new CookieCollection();
        }
        public string Type { get; set; }
        public string Location { get; set; }
        public ICookieCollection Cookies { get; set; }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Type);
            if (Cookies.Count > 0)
            {
                foreach (var cookie in Cookies)
                {
                    sb.AppendLine($"Set-Cookie: {cookie.ToString()}");
                }
            }

            if (this.Location != null)
            {
                sb.AppendLine(this.Location);
            }

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
