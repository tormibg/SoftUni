using System.Web.Mvc;
using LearningSystem.Models.BindingModels.Users;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;
using LearningSystem.Web.Attributes;

namespace LearningSystem.Web.Controllers
{
	[MyAuthorize(Roles = "Admin, Student")]
	[RoutePrefix("users")]
	public class UsersController : Controller
	{
		private readonly IUsersService _service;

		public UsersController(IUsersService service)
		{
			this._service = service;
		}

		[HttpPost]
		[Route("enroll")]
		public ActionResult Enroll(int courseId)
		{
			string userName = this.User.Identity.Name;
			Student student = this._service.GetStudentByName(userName);
			this._service.EnrollStudentInCourse(courseId, student);
			return this.RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Route("profile")]
		public new ActionResult Profile()
		{
			string userName = this.User.Identity.Name;
			ProfileVm vm = this._service.GetProfileVm(userName);

			return this.View(vm);
		}

		[HttpGet]
		[Route("edit")]
		public ActionResult Edit()
		{
			string userName = this.User.Identity.Name;
			UserEditVm vm = this._service.GetUserEditVm(userName);
			return this.View(vm);
		}

		[HttpPost]
		[Route("edit")]
		public ActionResult Edit(UserEditBm bind)
		{
			string userName = this.User.Identity.Name;
			if (ModelState.IsValid)
			{
				this._service.EditUser(bind, userName);
				return this.RedirectToAction("Profile", "Users");
			}
			UserEditVm vm = this._service.GetUserEditVm(userName);
			return this.View(vm);
		}
	}
}