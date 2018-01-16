using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Attributes;

namespace LearningSystem.Web.Controllers
{
	[MyAuthorize(Roles = "Admin")]
	public class HomeController : Controller
	{

		private readonly IHomeService _service;

		public HomeController(IHomeService service)
		{
			this._service = service;
		}

		[AllowAnonymous]
		public ActionResult Index()
		{
			IEnumerable<CourseVm> vms = this._service.GetAllCourses();
			return View(vms);
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

		[HttpGet]
		[Route("Upload")]
		public ActionResult UploadFile()
		{
			return this.View();
		}

		[HttpPost]
		[Route("Upload")]
		[ActionName("UploadFile")]
		public ActionResult Upload()
		{
			HttpPostedFileBase file = this.Request.Files[0];
			string fileName = Path.GetFileName(file.FileName);
			string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
			file.SaveAs(path);
			return this.RedirectToAction("Index");
		}
	}
}