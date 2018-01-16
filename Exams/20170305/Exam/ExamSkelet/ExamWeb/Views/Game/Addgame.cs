using System;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.App.Constants;
using SoftUniStore.App.Utility;

namespace SoftUniStore.App.Views.Game
{
    public class Addgame : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string currentUser = ViewBag.GetUserName();
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavLogged);
            navigation = string.Format(navigation, currentUser);
            string home = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.AddGame);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(home);
            sb.Append(footer);

            return sb.ToString();
        }
    }
}