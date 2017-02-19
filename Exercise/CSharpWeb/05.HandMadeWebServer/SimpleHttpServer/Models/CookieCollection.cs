using System.Collections;
using System.Collections.Generic;

namespace SimpleHttpServer.Models
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public IDictionary<string, Cookie> Cookies { get; set; }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Cookie cookie)
        {
            if (!this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies.Add(cookie.Name, new Cookie());
            }
            this.Cookies[cookie.Name] = cookie;
        }

        public bool Contains(string cookieKey)
        {
            return this.Cookies.ContainsKey(cookieKey);
        }

        public int Count()
        {
            return this.Cookies.Count;
        }

        public Cookie this[string cookieName]
        {
            get { return this.Cookies[cookieName]; }
            set
            {
                if (this.Cookies.ContainsKey(cookieName))
                {
                    this.Cookies[cookieName] = value;
                }
                else
                {
                    this.Cookies.Add(cookieName, value);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(";", this.Cookies);
        }
    }
}