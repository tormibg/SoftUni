using System.IO;
using Work.HTTP;
using Work.HTTP.Response;
using Work.MVC;

namespace SlusApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Bootstrap()
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/bootstrap.min.css"),"text/css");
        }
        public HttpResponse Reset()
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/reset-css.css"), "text/css");
        }
        public HttpResponse Site()
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/site.css"), "text/css");
        }
        public HttpResponse Text()
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/text.css"), "text/css");
        }
    }
}