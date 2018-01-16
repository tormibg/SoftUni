using System.IO;
using System.Text;
using ExamWeb.Utility;
using SimpleMVC.Interfaces;
using static ExamWeb.Constants.HtmlConstants;

namespace ExamWeb.Views.Home
{
    class Index : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + Header);
            string navigation;
            string currentUser = ViewBag.GetUserName();
            if (currentUser != null)
            {
                navigation = File.ReadAllText(ContentPath + NavLogged);
                navigation = string.Format(navigation, currentUser);
            }
            else
            {
                navigation = File.ReadAllText(ContentPath + NavNotLogged);
            }

            string footer = File.ReadAllText(ContentPath + Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}
