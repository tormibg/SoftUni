using System.Web.Mvc;

namespace LiveTest.Controllers
{
    [RoutePrefix("home")]
    [Route("{action=index}")]
    public class HomeController : Controller
    {
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}