using System.IO;
using System.Linq;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.Constants;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Views.Game
{
    public class Gamedetails : IRenderable<GameDatailsViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string currentUser = ViewBag.GetUserName();
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavLogged);
            navigation = string.Format(navigation, currentUser);
            string game = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.GameDetails);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(string.Format(game,this.Model));

            if (this.Model.Owners.Any(u => u.Id == this.Model.curUserId))
            {
                
            }
            else
            {
                sb.Append(
                    "<form action=\"#\" method=\"post\">\r\n                    <input type=\"number\" value=\"2\" hidden=\"hidden\" />\r\n                    <br/>\r\n                    <input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />\r\n                </form>");
            }

            sb.Append(footer);

            return sb.ToString();
        }

        public GameDatailsViewModel Model { get; set; }
    }
}