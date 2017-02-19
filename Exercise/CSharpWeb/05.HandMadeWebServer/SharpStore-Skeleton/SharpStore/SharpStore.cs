using System.Collections.Generic;
using System.IO;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SharpStore
{
    internal class SharpStore
    {
        private static void Main(string[] args)
        {
            var routes = new List<Route>
            {
                new Route
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = request =>
                    {
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route
                {
                    Name = "Carousel CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = request =>
                    {
                        var response = new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css"),
                            Header = {ContentType = "text/css"}
                        };
                        return response;
                    }
                },
                new Route
                {
                    Name = "Bootstrap JS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = request =>
                    {
                        var response = new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js"),
                            Header = {ContentType = "application/x-javascript"}
                        };
                        return response;
                    }
                },
                new Route
                {
                    Name = "Bootstrap CSS",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                    Callable = request =>
                    {
                        var response = new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css"),
                            Header = {ContentType = "text/css"}
                        };
                        return response;
                    }
                },
                new Route
                {
                    Name = "About",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/about$",
                    Callable = request =>
                    {
                        var response = new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText(   "../../about.html"    ),
                            Header = {ContentType = "text/html"}
                        };
                        return response;
                    }
                }
            };

            var server = new HttpServer(8081, routes);
            server.Listen();
        }
    }
}