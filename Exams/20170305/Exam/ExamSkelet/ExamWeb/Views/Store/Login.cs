using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.App.Constants;

namespace SoftUniStore.App.Views.Store
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavNotLogged);
            string login = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.LoginHTML);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(login);
            sb.Append(footer);

            return sb.ToString();
        }
    }
}