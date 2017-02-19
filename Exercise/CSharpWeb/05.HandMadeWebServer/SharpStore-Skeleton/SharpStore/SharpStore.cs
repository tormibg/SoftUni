using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using SharpStoreDB;
using SharpStoreDB.Models;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SharpStore
{
    internal class SharpStore
    {
        private static void Main()
        {
            var routes = new List<Route>
            {
                new Route
                {
                    Name = "PNG",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/images/.+$",
                    Callable = request =>
                    {
                        var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/')+1);
                        var response = new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{nameOfFile}"),
                            Header = {ContentType = "image/*"}
                        };
                        response.Header.ContentLength = response.Content.Length.ToString();
                        return response;
                    }
                },
                //new Route
                //{
                //    Name = "Home Directory",
                //    Method = RequestMethod.GET,
                //    UrlRegex = @"^/.+\.html$",
                //    Callable = request =>
                //    {
                //        var nameOfFile = request.Url.Substring(1);
                //        return new HttpResponse
                //        {
                //            StatusCode = ResponseStatusCode.Ok,
                //            ContentAsUTF8 = File.ReadAllText($"../../content/{nameOfFile}")
                //        };
                //    }
                //},
                new Route
                {
                    Name = "Home Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/home.html$",
                    Callable = request =>
                    {
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/home.html")
                        };
                    }
                },
                new Route
                {
                    Name = "About",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/about.html$",
                    Callable = request =>
                    {
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/about.html")
                        };
                    }
                },
                new Route
                {
                    Name = "Products",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/products.html$",
                    Callable = request =>
                    {
                        var context = new SharpStoreContext();
                        var knives = context.Knives.ToList();
                        string knivesHtml = GenerateKnivesHtml(knives);
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = knivesHtml
                        };
                    }
                },
                new Route
                {
                    Name = "Products",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^/products.html$",
                    Callable = request =>
                    {
                        string filter = request.Content.Split('=')[1];
                        var context = new SharpStoreContext();
                        var knives = context.Knives.Where(k => k.Name.Contains(filter)).ToList();
                        string knivesHtml = GenerateKnivesHtml(knives);
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = knivesHtml
                        };
                    }
                },
                new Route
                {
                    Name = "Contact",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/contacts.html$",
                    Callable = request =>
                    {
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/contacts.html")
                        };
                    }
                },
                new Route
                {
                    Name = "Contact",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^/contacts.html$",
                    Callable = request =>
                    {
                        var context = new SharpStoreContext();
                        GetMessage(request.Content, context);
                        return new HttpResponse
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/contacts.html")
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
                }
            };

            //var context = new SharpStoreContext();
            //var knive = context.Knives.ToList();

            //var kn = new Knive()
            //{
            //    Name = "test 1",
            //    Price = (SqlMoney) 123.12,
            //    ImageUrl = $"http://www.mwgco.com/mm5/graphics/00000001/CRKT_knives_Mini_My_Tighe.jpg"
            //};
            //context.Knives.Add(kn);
            //context.SaveChanges();

            //Console.WriteLine(knive.Count);

            var server = new HttpServer(8081, routes);
            server.Listen();
        }

        private static void GetMessage(string requestContent, SharpStoreContext context)
        {
            string content = WebUtility.UrlDecode(requestContent);
            string[] parameters = content.Split('&');
            Dictionary<string, string> messages = new Dictionary<string, string>();
            foreach (var parameter in parameters)
            {
                string[] paramStrings = parameter.Split('=');
                messages.Add(paramStrings[0], paramStrings[1]);
            }

            Message message = new Message
            {
                Sender = messages["email"],
                Subject = messages["subject"],
                MessageText = messages["message"]
            };

            context.Messages.Add(message);
            context.SaveChanges();
        }

        private static string GenerateKnivesHtml(List<Knive> knives)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var knife in knives)
            {
                if (counter % 3 == 0)
                {
                    sb.AppendLine($"<div class=\"row\">");
                }
                sb.AppendLine(
                    $"<div class=\"img-thumbnail\">\r\n<img src=\"{knife.ImageUrl}\" alt=\"Image\" width=\"300\" height=\"150\">\r\n<div class=\"card-block\">\r\n<h3 class=\"card-title\">{knife.Name}</h3>\r\n<p class=\"card-text\">${knife.Price}</p>\r\n<button class=\"btn btn-primary\" style=\"margin-bottom: 10px\" type=\"submit\">Buy Now</button>\r\n</div>\r\n</div>");
                if (counter % 3 == 2)
                {
                    sb.AppendLine($"</div>");
                }
                counter++;
            }
            StringBuilder html = new StringBuilder();
            html.AppendLine(File.ReadAllText("../../content/products-top.html"));
            html.AppendLine(sb.ToString());
            html.AppendLine(File.ReadAllText("../../content/products-bottom.html"));
            return html.ToString();
        }
    }
}