using System.Web.Mvc;

namespace LiveTest.Controllers
{
    public class EmptyController : Controller
    {
        // GET: Empty
        public ActionResult Index()
        {
            return View();
        }
    }
}