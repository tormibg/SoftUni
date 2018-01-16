using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.App.Constants;

namespace SoftUniStore.App.Views.Store
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavNotLogged);
            string register = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.RegisterHTML);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(register);
            sb.Append(footer);

            return sb.ToString();
        }

    }
}