using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Utility;

namespace YourSuggestions
{
    class YourSuggestions
    {
        public static IDictionary<string, string> RetrieveParameters;
        public static Session Session;
        public static readonly Header Header = new Header();

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
            if (WebUtil.IsPost())
            {
                DeletePizza();
                ShowGetPage();
            }
        }

        private static void DeletePizza()
        {
            RetrieveParameters = WebUtil.RetrievePostParameters();
            int pizzaId = int.Parse(RetrieveParameters["pizzaId"]);
            using (var pizzaMoreContext = new PizzaMoreContext())
            {
                var pizza = pizzaMoreContext.Pizzas.FirstOrDefault(p => p.Id == pizzaId);
                pizzaMoreContext.Pizzas.Remove(pizza);
                pizzaMoreContext.SaveChanges();
            }
        }

        private static void ShowGetPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.YourSuggestionsTopHtml);
            PrintListOfSuggestedItems();
            WebUtil.PrintFileContent(Constants.YourSuggestionsBottomHtml);
        }

        private static void PrintListOfSuggestedItems()
        {
            using (var pizzaMoreContext = new PizzaMoreContext())
            {
                var pizzas = pizzaMoreContext.Pizzas.Where(p => p.OwnerId == Session.UserId);
                Console.WriteLine("<ul>");
                foreach (var suggestion in pizzas)
                {
                    Console.WriteLine("<form method=\"POST\">");
                    Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                    Console.WriteLine("</form>");
                }
                Console.WriteLine("</ul>");
            }
        }
    }
}
