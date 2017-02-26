using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Controllers;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}