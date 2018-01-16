using System.Linq;
using System.Web.Mvc;
using LiveTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LiveTest.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private ApplicationDbContext context;

		public AdminController()
		{
			this.context = new ApplicationDbContext();
		}

		// GET: Admin
		public ActionResult Roles()
		{
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

			var users = this.context.Users.Select(u => new SelectListItem()
			{
				Value = u.Id,
				Text = u.Email
			});

			var roles = this.context.Roles.Select(r => new SelectListItem()
			{
				Value = r.Name,
				Text = r.Name
			});

			ViewBag.User = users;
			ViewBag.Role = roles;

			return View(new RoleViewModel());
		}

		[HttpPost]
		public ActionResult Assign(RoleViewModel rvm)
		{
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context));
			userManager.AddToRole(rvm.User, rvm.Role);
			return RedirectToAction("Roles");
		}

	}
}