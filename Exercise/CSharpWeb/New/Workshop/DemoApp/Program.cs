using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.HTTP;
using Work.HTTP.Response;
using Work.MVC;

namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Post, "/Tweet/Create", CreateTweet));

            //routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            //routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            //routeTable.Add(new Route(HttpMethodType.Get, "/Contact", Contact));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));

            var httpServer = new HttpServer(1234, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse CreateTweet(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            db.Tweets.Add(new Tweet()
            {
                CreateOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Body = request.FormData["tweetName"]
            });
            db.SaveChanges();
            return new RedirectResponse("/");
        }

        private static HttpResponse FavIcon(HttpRequest arg)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent,"image/x-icon");
        }
        private static HttpResponse Contact(HttpRequest request)
        {
            return new HtmlResponse("<h1>Contact page</h1>");
        }
        internal static HttpResponse Index(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            var tweets = db.Tweets.Select(x => new {x.CreateOn, x.Creator, x.Body}).ToList();
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<table><tr><th>Date</th><th>Creator</th><th>Content</th></tr>");
            foreach (var tweet in tweets)
            {
                htmlBuilder.Append($"<tr><td>{tweet.CreateOn}</td><td>{tweet.Creator}</td><td>{tweet.Body}</td></tr>");
            }
            htmlBuilder.Append("</table>");
            htmlBuilder.Append($"<form action='Tweet/Create' method='post'><input name='creator' /><br /><textarea name='tweetText'></textarea><br /><input type='submit' /></form>");
            return new HtmlResponse(htmlBuilder.ToString());
        }
        internal static HttpResponse Login(HttpRequest request)
        {
            request.SessionData["UserName"] = "Pesho";
            return new HtmlResponse("<h1>Login page</h1>");
        }
        internal static HttpResponse DoLogin(HttpRequest request)
        {
            return new HtmlResponse("<h1>DoLogin page</h1>");
        }
    }
}
