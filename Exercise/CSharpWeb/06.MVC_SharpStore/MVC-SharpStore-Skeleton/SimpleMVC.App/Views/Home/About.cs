using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about.html");
        }
    }
}