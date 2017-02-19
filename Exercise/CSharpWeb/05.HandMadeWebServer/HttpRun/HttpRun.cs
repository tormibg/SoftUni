using System.Collections.Generic;
using System.Threading;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace HttpRun
{
    class HttpRun
    {
        static void Main()
        {
            var routes = new List<Route>()
            {
                new Route
                {
                    Name = "Hello Handler",
                    UrlRegex = $"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>
                    {
                        return new HttpResponse(ResponseStatusCode.OK)
                        {
                            ContentAsUtf8 = "<h3>Hello from HttpServer :)</h3>",
                        };
                    }
                }
            };

            HttpServer httpServer = new HttpServer(8081, routes);
            httpServer.Listen();

            Thread thread = new Thread(httpServer.Listen);
            thread.Start();
        }
    }
}
