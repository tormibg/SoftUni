using System.Web.Mvc;

namespace LiveTest.Controllers
{
    public class MouseController : Controller
    {
        // GET: Mouse
        public ActionResult Index(int? id)
        {

            return View(id);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}