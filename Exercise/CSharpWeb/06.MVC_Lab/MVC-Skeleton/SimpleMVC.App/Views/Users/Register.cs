﻿using System.Text;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>Register new user</h1><br/>");
            sb.AppendLine("<a href=\"/home/index\">&#8810; Home<a/>");
            sb.AppendLine("<form action=\"register\" method=\"post\"><br/>");
            sb.AppendLine("Username: <input type=\"text\" name=\"Username\"><br/>");
            sb.AppendLine("Password: <input type=\"password\" name=\"Password\"><br/>");
            sb.AppendLine("<input type=\"submit\" value=\"Submit\">");
            sb.AppendLine("</form><br/>");
            return sb.ToString();
        }
    }
}