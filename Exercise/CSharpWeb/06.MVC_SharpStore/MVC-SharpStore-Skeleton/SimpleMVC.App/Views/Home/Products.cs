using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class Products : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/products");
        }
    }
}