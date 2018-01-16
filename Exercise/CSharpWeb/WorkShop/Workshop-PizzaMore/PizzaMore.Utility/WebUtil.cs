namespace PizzaMore.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Data;
    using Data.Models;
    using Interfaces;

    public static class WebUtil
    {
        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod.ToLower() == "post";
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            return requestMethod.ToLower() == "get";
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable("QUERY_STRING"));

            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());

            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrieveRequestParameters(string parametersString)
        {
            Dictionary<string, string> resultParameters = new Dictionary<string, string>();
            var parameters = parametersString.Split('&');
            foreach (var param in parameters)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;
                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (string.IsNullOrEmpty(cookieString))
            {
                //Console.WriteLine("NULL");
                return new CookieCollection();
            }
            //Console.WriteLine(cookieString);
            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }
            return cookies;
        }

        public static Session GetSession()
        {
            ICookieCollection cookies = GetCookies();
            if (cookies.ContainsKey("sid"))
            {
                Cookie desiredCookie = cookies["sid"];
                PizzaMoreContext context = new PizzaMoreContext();
                int desiredSessionId = int.Parse(desiredCookie.Value);
                return context.Sessions.FirstOrDefault(s => s.Id == desiredSessionId);
            }
            return null;
        }

        public static void PrintFileContent(string path)
        {
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.Game);
        }
    }
}