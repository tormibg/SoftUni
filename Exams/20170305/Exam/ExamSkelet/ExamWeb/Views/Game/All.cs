using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.Constants;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Views.Game
{
    class All : IRenderable<HashSet<AllGamesListViewModel>>
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string currentUser = ViewBag.GetUserName();
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavLogged);
            navigation = string.Format(navigation, currentUser);
            string games = string.Empty;
            foreach (var allGamesViewModel in this.Model)
            {
                games = games + allGamesViewModel;
            }
            string home = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.GameListHTML);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(String.Format(home,games));
            sb.Append(footer);

            return sb.ToString();
        }

        public HashSet<AllGamesListViewModel> Model { get; set; }
    }
}