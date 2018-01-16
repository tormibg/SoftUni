using static ExamWeb.Constants.HtmlConstants;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace ExamWeb.Views.Home
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + Header);
            string navigation = File.ReadAllText(ContentPath + NavNotLogged);
            string login = File.ReadAllText(ContentPath + LoginHTML);
            string footer = File.ReadAllText(ContentPath + Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(login);
            sb.Append(footer);

            return sb.ToString();
        }
    }
}