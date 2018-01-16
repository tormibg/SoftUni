using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.Constants;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Views.Store
{
    class All : IRenderable<HashSet<AllGamesViewModel>>
    {
        public string Render()
        {
            string header = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Header);
            string currentUser = ViewBag.GetUserName();
            string navigation = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.NavLogged);
            navigation = string.Format(navigation, currentUser);
            
            StringBuilder builder = new StringBuilder();
            int index = 0;
            builder.AppendLine("<div class=\"card-group\">");
            foreach (var model in this.Model)
            {
                if (index != 0 && index % 3 == 0)
                {
                    builder.AppendLine("</div>");
                    builder.AppendLine("<div class=\"card-group\">");
                }
                builder.Append(model);
                index++;
            }
            builder.AppendLine("</div>");
            
            string home = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.HomeHTML);
            string footer = File.ReadAllText(HtmlConstants.ContentPath + HtmlConstants.Footer);

            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navigation);
            sb.Append(string.Format(home,builder));
            sb.Append(footer);

            return sb.ToString();
        }

        public HashSet<AllGamesViewModel> Model { get; set; }
    }
}
