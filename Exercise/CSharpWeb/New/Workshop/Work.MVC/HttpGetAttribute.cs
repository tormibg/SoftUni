using System;
using Work.HTTP;

namespace Work.MVC
{
    public class HttpGetAttribute : HttpMethodAttribute
    {

        public HttpGetAttribute()
        {

        }

        public HttpGetAttribute(string url) : base(url)
        {
        }

        public override HttpMethodType Type => HttpMethodType.Get;
    }
}