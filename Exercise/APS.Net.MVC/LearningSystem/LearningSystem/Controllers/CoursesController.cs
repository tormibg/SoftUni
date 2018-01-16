using System.Web.Mvc;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Attributes;

namespace LearningSystem.Web.Controllers
{
	[MyAuthorize(Roles = "Admin, Student")]
	[RoutePrefix("courses")]
	public class CoursesController : Controller
	{
		private readonly ICourseService _service;

		public CoursesController(ICourseService service)
		{
			this._service = service;
		}

		[HttpGet]
		[Route("details/{id}")]
		public ActionResult Details(int Id)
		{
			CourseDetailsVm vm = this._service.GetDetailsById(Id);
			if (vm == null)
			{
				return this.HttpNotFound();
			}
			return this.View(vm);
		}

	}
}