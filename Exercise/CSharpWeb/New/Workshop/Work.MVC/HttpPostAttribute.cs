using System;
using Work.HTTP;

namespace Work.MVC
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute()
        {

        }

        public HttpPostAttribute(string url) : base(url)
        {

        }

        public override HttpMethodType Type => HttpMethodType.Post;
    }
}