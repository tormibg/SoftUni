using System;
using System.Collections.Generic;
using System.Text;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    class All : IRenderable<IEnumerable<AllUsersViewModel>>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<h3> All users</h3>");
            sb.AppendLine("<a href=\"/home/index\">&#8810; Home<a/>");
            sb.AppendLine("<ul>");
            foreach (var modelUsername in ((IRenderable<IEnumerable<AllUsersViewModel>>)this).Model)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={modelUsername.Id}\">{modelUsername.Username}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }

        //public IEnumerable<AllUsersViewModel> Model { get; set; }
        IEnumerable<AllUsersViewModel> IRenderable<IEnumerable<AllUsersViewModel>>.Model { get; set; }
    }

    //public class All : IRenderable<AllUserNamesViewModel>
    //{
    //    public string Render()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendLine(@"<h3> All users</h3>");
    //        sb.AppendLine("<ul>");
    //        foreach (var modelUsername in Model.Usernames)
    //        {
    //            sb.AppendLine($"<li>{modelUsername}</li>");
    //        }
    //        sb.AppendLine("</ul>");

    //        return sb.ToString();
    //    }

    //    public AllUserNamesViewModel Model { get; set; }
    //}
}