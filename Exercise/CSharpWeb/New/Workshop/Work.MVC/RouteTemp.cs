using System;
using Work.HTTP;

namespace Work.MVC
{
    public class RouteTemp  
    {
        public RouteTemp(HttpMethodType httpMethod, string path, Func<HttpRequest, HttpResponse> action)
        {
            this.HttpMethod = httpMethod;
            this.Path = path;
            this.Action = action;
        }
        public string Path { get; set; }
        public HttpMethodType HttpMethod { get; set; }
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
