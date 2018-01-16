using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using static ExamWeb.Constants.HtmlConstants;

namespace ExamWeb.Views.Home
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(ContentPath + Header);
            string navigation = File.ReadAllText(ContentPath + NavNotLogged);
            string register = File.ReadAllText(ContentPath + RegisterHTML);
            string footer = File.ReadAllText(ContentPath + Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(register);
            sb.Append(footer);

            return sb.ToString();
        }

    }
}