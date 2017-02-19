using System.IO;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SimpleHttpServer
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            string html = File.ReadAllText(@"../../../SimpleHttpServer/Resources/Pages/500.html");
            return new HttpResponse(ResponseStatusCode.InternalServerError)
            {
                ContentAsUtf8 = html
            };
        }

        public static HttpResponse NotFound()
        {
            string html = File.ReadAllText(@"../../../SimpleHttpServer/Resources/Pages/404.html");
            return new HttpResponse(ResponseStatusCode.NotFound)
            {
                ContentAsUtf8 = html
            };
        }
    }
}