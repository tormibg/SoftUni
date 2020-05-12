using System;
using Work.HTTP;

namespace Work.MVC
{
    public abstract class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute()
        {
        }

        protected HttpMethodAttribute(string url)
        {
            Url = url;
        }
        public string Url { get;  }

        public abstract HttpMethodType Type { get; }
    }
}