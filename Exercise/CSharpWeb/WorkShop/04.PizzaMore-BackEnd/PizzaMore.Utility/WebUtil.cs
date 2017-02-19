using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using PizzaMore.Data;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            var environmentMethod = Environment.GetEnvironmentVariable(Constants.Request);
            if (environmentMethod != null)
            {
                string requestMethod = environmentMethod.ToLower();
                if (requestMethod == "post")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsGet()
        {
            var environmentMethod = Environment.GetEnvironmentVariable(Constants.Request);
            if (environmentMethod != null)
            {
                string requestMethod = environmentMethod.ToLower();
                if (requestMethod == "get")
                {
                    return true;
                }
            }
            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.Query));
            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());
            return RetrieveRequestParameters(parametersString);
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string parametersString)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();
            var parameters = parametersString.Split('&');
            foreach (var parameter in parameters)
            {
                var paramss = parameter.Split('=');
                var paramName = paramss[0];
                string paramValue = null;
                if (paramss.Length > 1)
                {
                    paramValue = paramss[1];
                }

                result.Add(paramName, paramValue);
            }

            return result;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieStr = Environment.GetEnvironmentVariable(Constants.HttpCookie);
            if (string.IsNullOrEmpty(cookieStr))
            {
                return new CookieCollection();
            }
            var cookies = new CookieCollection();
            string[] cookiesSaves = cookieStr.Split(';');
            foreach (var cookiesSave in cookiesSaves)
            {
                string[] cookiePair = cookiesSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }
            return cookies;
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();
            //Logger.Log(cookies.ToString());
            if (!cookies.ContainsKey(Constants.SessionIdKey))
            {
                return null;
            }
            var sessionCookie = cookies[Constants.SessionIdKey];
            var ctx = new PizzaMoreContext();
            //Logger.Log(sessionCookie.Value);
            var session = ctx.Sessions.FirstOrDefault(s => s.Id == sessionCookie.Value);
            return session;
        }

        public static void PrintFileContent(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine(content);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent(Constants.PageNotFoundHtml);
        }
    }
}