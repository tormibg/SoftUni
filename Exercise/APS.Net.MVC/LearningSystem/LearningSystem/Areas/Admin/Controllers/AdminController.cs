using System.Web.Mvc;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Attributes;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
	[MyAuthorize(Roles = "Admin")]
	[RouteArea("Admin")]
	public class AdminController : Controller
	{

		private readonly IAdminServices _service;

		public AdminController(IAdminServices services)
		{
			this._service = services;
		}

		// GET: Admin/Admin
		[HttpGet]
		[Route]
		public ActionResult Index()
		{
			AdminPageVm vm = this._service.GetAdminPage();
			return View(vm);
		}

		[HttpGet]
		[Route("courses/add")]
		public ActionResult AddCourse()
		{
			return this.View();
		}

		[HttpGet]
		[Route("courses/{id}/edit")]
		public ActionResult EditCourse(int Id)
		{
			return this.View();
		}

		[HttpGet]
		[Route("users/{id}/edit")]
		public ActionResult EditUser(int Id)
		{
			return this.View();
		}
	}
}