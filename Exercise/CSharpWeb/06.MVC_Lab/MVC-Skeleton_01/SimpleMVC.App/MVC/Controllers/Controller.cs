using System.Runtime.CompilerServices;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.MVC.ViewEngine;
using SimpleMVC.App.MVC.ViewEngine.Generic;

namespace SimpleMVC.App.MVC.Controllers
{
    public class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllerSuffix, string.Empty);

            string fullQualifedName =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{callee}";

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifedName =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}";

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControllerSuffix, string.Empty);

            string fullQualifedName =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{callee}";

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName =
                $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}";

            return new ActionResult<T>(fullQualifedName, model);
        }
    }
}