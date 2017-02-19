using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Utility;

namespace AddPizza
{
    class AddPizza
    {
        public static IDictionary<string, string> RetrieveParameters;
        public static Header Header = new Header();
        public static Session Session;

        static void Main()
        {
            Session = WebUtil.GetSession();
            if (Session == null)
            {
                Header.Print();
                WebUtil.PageNotAllowed();
                return;
            }
            if (WebUtil.IsGet())
            {
                ShowGetPage();
            }
            else if (WebUtil.IsPost())
            {
                RetrieveParameters = WebUtil.RetrievePostParameters();
                string title = RetrieveParameters["title"];
                string recipe = RetrieveParameters["recipe"];
                string url = RetrieveParameters["url"];
                using (var pizzaMoreContext = new PizzaMoreContext())
                {
                    var user = pizzaMoreContext.Users.FirstOrDefault(u => u.Id == Session.UserId);
                    user.Suggestions.Add(new Pizza()
                    {
                        ImageUrl = url,
                        Recipe = recipe,
                        Title = title,
                        OwnerId = user.Id,
                        DownVotes = 0,
                        UpVotes = 0
                    });
                    pizzaMoreContext.SaveChanges();
                }
                ShowGetPage();
            }
        }

        private static void ShowGetPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.AddPizzaHtml);
        }
    }
}
