using System.Collections.Generic;
using System.IO;
using System.Text;
using ExamWeb.ViewModels;
using SimpleMVC.Interfaces.Generic;
using static ExamWeb.Constants.HtmlConstants;

namespace ExamWeb.Views.Home
{
    public class Users : IRenderable<HashSet<AllUserViewModel>>
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + Header);
            string navigation = File.ReadAllText(ContentPath + NavLogged);
            //navigation = string.Format(navigation, ViewBag.Bag["username"]);

            string categories = File.ReadAllText(ContentPath + AdminCategories);
            foreach (var allUserViewModel in Model)
            {
                categories = string.Format(categories, allUserViewModel);
            }

            string footer = File.ReadAllText(ContentPath + Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(categories);
            builder.Append(footer);

            return builder.ToString();
        }

        public HashSet<AllUserViewModel> Model { get; set; }
    }
}