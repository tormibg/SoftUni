using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.Constants;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Views.Game
{
    public class Editgame : IRenderable<GameEditViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string currentUser = ViewBag.GetUserName();
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavLogged);
            navigation = string.Format(navigation, currentUser);
            string game = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.EditGame);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(string.Format(game,this.Model));
            sb.Append(footer);

            return sb.ToString();
        }

        public GameEditViewModel Model { get; set; }
    }
}