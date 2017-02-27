using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    public class Greet : IRenderable<GreetViewModel>
    {
        public string Render()
        {
            return $"Hello user with seesionId : {Model.SessionId}";
        }

        public GreetViewModel Model { get; set; }
    }
}