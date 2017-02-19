using System.Collections.Generic;
using PizzaMore.Data;
using PizzaMore.Utility;

namespace Home
{
    class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;

        static void Main()
        {

            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }
            ShowPage();
        }

        private static void TryLogOut()
        {
            if (RequestParameters.ContainsKey("logout"))
            {
                if (RequestParameters["logout"] == "true")
                {
                    Session = WebUtil.GetSession();
                    using (var pizzaMoreContext = new PizzaMoreContext())
                    {
                        var seesion = pizzaMoreContext.Sessions.Find(Session.Id);
                        pizzaMoreContext.Sessions.Remove(seesion);
                        pizzaMoreContext.SaveChanges();
                    }
                }
            }
        }

        private static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            if (Language.Equals("DE"))
            {
                ServeHtmlBg();
            }
            else
            {
                ServeHtmlEn();
            }
        }

        private static void ServeHtmlEn()
        {
            WebUtil.PrintFileContent(Constants.HomeEn);
        }

        private static void ServeHtmlBg()
        {
            WebUtil.PrintFileContent(Constants.HomeDe);
        }
    }
}
