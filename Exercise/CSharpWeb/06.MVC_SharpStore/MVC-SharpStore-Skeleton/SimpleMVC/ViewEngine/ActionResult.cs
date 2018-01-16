using System;
using SimpleMVC.Interfaces;

namespace SimpleMVC.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = Activator.CreateInstance(MvcContext.Current.ApplicationAssembly.GetType(viewFullQualifedName)) as IRenderable;
            //(IRenderable)Activator.CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
