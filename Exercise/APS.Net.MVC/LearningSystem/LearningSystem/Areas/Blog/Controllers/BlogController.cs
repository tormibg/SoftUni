using System.Collections.Generic;
using System.Web.Mvc;
using LearningSystem.Models.BindingModels.Blog;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services;
using LearningSystem.Services.Interfaces;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
	[RouteArea("blog")]
	[Authorize(Roles = "Student")]
	public class BlogController : Controller
	{
		private readonly IBlogService _service;

		public BlogController(IBlogService service)
		{
			this._service = service;
		}

		[Route("AllArticles")]
		public ActionResult AllArticles()
		{
			IEnumerable<ArticleVm> vm = this._service.GetAllArticles();
			return View(vm);
		}

		[HttpGet]
		[Route("Add")]
		public ActionResult Add()
		{
			return this.View();
		}

		[HttpPost]
		[Route("Add")]
		public ActionResult Add(AddArticleBm bind)
		{
			if (ModelState.IsValid)
			{
				string userName = this.User.Identity.Name;
				this._service.AddNewArticle(bind, userName);
				return this.RedirectToAction("AllArticles");
			}

			return this.View();
		}
	}
}