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
        private UsersService service;
        private AuthenticationManager authentication;

        public UserController()
        {
            this.service = new UsersService();
            this.authentication = new AuthenticationManager();
        }

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Profile");
            }

            return View(new RegisterUserVm());
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterUserVm bind)
        {
            if (this.service.UsernameExists(bind))
            {
                this.ModelState.AddModelError("UsernameEmail", "* There is already a user with such username/email");

                return this.View(bind);
            }

            if (this.ModelState.IsValid && bind.Password == bind.ConfirmPassword)
            {
                this.service.AddUser(bind);
                return this.RedirectToAction("Login");
            }

            return this.View(bind);
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Profile");
            }
            return this.View(new LoginUserVm());
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginUserVm bind)
        {
            if (this.ModelState.IsValid && this.service.UserExists(bind))
            {
                this.service.LoginUser(bind, this.Session.SessionID);
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
            if (this.authentication.IsAuthenticated(sessionId))
            {
                this.authentication.Logout(sessionId);
            }

            return this.RedirectToAction("Login");
        }

        [HttpGet]
        [Route("profile/{username?}")]
        public ActionResult Profile(string username)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login");
            }
            User user = this.authentication.GetAuthenticatedUser(sessionId);
            if (string.IsNullOrEmpty(username))
            {
                ProfilePageVm loggedUserVm = this.service.GetProfilePage(user.Username, user.Username);
                if (loggedUserVm == null)
                {
                    return new HttpNotFoundResult();
                }
                return this.View("MyProfile", loggedUserVm);
            }
            ProfilePageVm vm = this.service.GetProfilePage(username, user.Username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("editProfile")]
        public ActionResult EditProfile()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login");
            }
            User user = this.authentication.GetAuthenticatedUser(sessionId);
            EditUserVm vm = this.service.GetEditUserVm(user);
            return this.View(vm);
        }

        [HttpPost]
        [Route("editProfile")]
        public ActionResult EditProfile(EditUserVm bind)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!this.authentication.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login", "Users");
            }
            User user = this.authentication.GetAuthenticatedUser(sessionId);
            if (this.ModelState.IsValid && bind.Password == user.Password)
            {
                this.service.EditUser(bind);
                return this.RedirectToAction("Profile");
            }
            return this.View(bind);
        }
    }
}