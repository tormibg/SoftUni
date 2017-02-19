using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Utility
{
    public class CookieCollection : ICookieCollection
    {
        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public Cookie this[string key]
        {
            get { return this.Cookies[key]; }
            set
            {
                if (this.Cookies.ContainsKey(key))
                {
                    this.Cookies[key] = value;
                }
                else
                {
                    this.Cookies.Add(key, value);
                }
            }
        }

        public Dictionary<string, Cookie> Cookies { get; private set; }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void AddCookie(Cookie cookie)
        {
            if (!this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies.Add(cookie.Name, new Cookie());
            }

            this.Cookies[cookie.Name] = cookie;
        }

        public void RemoveCokie(string cookieName)
        {
            if (this.Cookies.ContainsKey(cookieName))
            {
                this.Cookies.Remove(cookieName);
            }
        }

        public bool ContainsKey(string key)
        {
            //Logger.Log(Cookies.ContainsKey(key).ToString());
            return this.Cookies.ContainsKey(key);
        }

        public int Count => this.Cookies.Count;
    }
}