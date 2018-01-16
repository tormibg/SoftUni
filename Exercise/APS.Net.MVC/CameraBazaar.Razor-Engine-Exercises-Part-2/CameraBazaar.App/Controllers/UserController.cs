using System.Web;
using System.Web.Mvc;
using CameraBazaar.App.Security;
using CameraBazaar.App.Service;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels.Users;

namespace CameraBazaar.App.Controllers
{
	[RoutePrefix("user")]
	public class UserController : Controller
	{
		private readonly UsersService _service;
		private readonly AuthenticationManager _authentication;

		public UserController()
		{
			this._service = new UsersService();
			this._authentication = new AuthenticationManager();
		}

		[HttpGet]
		[Route("Register")]
		public ActionResult Register()
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (this._authentication.IsAuthenticated(sessionId))
			{
				return this.RedirectToAction("Profile");
			}

			return View(new RegisterUserVm());
		}

		[HttpPost]
		[Route("Register")]
		public ActionResult Register(RegisterUserVm bind)
		{
			if (this._service.UsernameExists(bind))
			{
				this.ModelState.AddModelError("UsernameEmail", "* There is already a user with such username/email");

				return this.View(bind);
			}

			if (this.ModelState.IsValid && bind.Password == bind.ConfirmPassword)
			{
				this._service.AddUser(bind);
				return this.RedirectToAction("Login");
			}

			return this.View(bind);
		}

		[HttpGet]
		[Route("Login")]
		public ActionResult Login()
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (this._authentication.IsAuthenticated(sessionId))
			{
				return this.RedirectToAction("Profile");
			}
			return this.View(new LoginUserVm());
		}

		[HttpPost]
		[Route("Login")]
		public ActionResult Login(LoginUserVm bind)
		{
			if (this.ModelState.IsValid && this._service.UserExists(bind))
			{
				this._service.LoginUser(bind, this.Session.SessionID);
				this.Response.Cookies.Add(new HttpCookie("sessionId", this.Session.SessionID));
				return this.RedirectToAction("Profile");
			}

			return this.View(bind);
		}

		[HttpPost]
		[Route("logout")]
		public ActionResult Logout()
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (this._authentication.IsAuthenticated(sessionId))
			{
				this._authentication.Logout(sessionId);
			}

			return this.RedirectToAction("Login");
		}

		[HttpGet]
		[Route("profile/{username?}")]
		public new ActionResult Profile(string username)
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (!this._authentication.IsAuthenticated(sessionId))
			{
				return this.RedirectToAction("Login");
			}
			User user = this._authentication.GetAuthenticatedUser(sessionId);
			if (string.IsNullOrEmpty(username))
			{
				ProfilePageVm loggedUserVm = this._service.GetProfilePage(user.Username, user.Username);
				if (loggedUserVm == null)
				{
					return new HttpNotFoundResult();
				}
				return this.View("MyProfile", loggedUserVm);
			}
			ProfilePageVm vm = this._service.GetProfilePage(username, user.Username);
			return this.View(vm);
		}

		[HttpGet]
		[Route("editProfile")]
		public ActionResult EditProfile()
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (!this._authentication.IsAuthenticated(sessionId))
			{
				return this.RedirectToAction("Login");
			}
			User user = this._authentication.GetAuthenticatedUser(sessionId);
			EditUserVm vm = this._service.GetEditUserVm(user);
			return this.View(vm);
		}

		[HttpPost]
		[Route("editProfile")]
		public ActionResult EditProfile(EditUserVm bind)
		{
			string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
			if (!this._authentication.IsAuthenticated(sessionId))
			{
				return this.RedirectToAction("Login", "User");
			}
			User user = this._authentication.GetAuthenticatedUser(sessionId);
			if (this.ModelState.IsValid && bind.Password == user.Password)
			{
				this._service.EditUser(bind);
				return this.RedirectToAction("Profile");
			}
			return this.View(bind);
		}

		[HttpGet]
		[ChildActionOnly]
		public ActionResult LastLogin()
		{
			string sessionId = this.Request.Cookies["sessionId"]?.Value;
			User user = this._authentication.GetAuthenticatedUser(sessionId);
			return this.PartialView(user.LastLoginTime);
		}
	}
}