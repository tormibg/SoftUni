using System.Web;
using System.Web.Mvc;
using CarDealer.App.Security;
using CarDealer.Models.BindingModels;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        [Route("register/")]
        public ActionResult Register()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            return this.View();
        }

        [HttpPost]
        [Route("register/")]
        public ActionResult Register([Bind(Include = "Email, Username, Password, ConfirmPassword")] UserRegisterVM bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            if (this.ModelState.IsValid && bind.Password == bind.ConfirmPassword)
            {
                this.service.RegisterUser(bind);
                return this.RedirectToAction("All", "Cars");
            }
            return this.RedirectToAction("Register");
        }

        [HttpGet]
        [Route("login/")]
        public ActionResult Login()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            return this.View();
        }

        [HttpPost]
        [Route("login/")]
        public ActionResult Login([Bind(Include = "Username, Password")] UserLoginVM bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie != null && AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All", "Cars");
            }
            if (this.ModelState.IsValid && this.service.UserExists(bind))
            {
                this.service.LoginUser(bind, Session.SessionID);
                this.Response.SetCookie(new HttpCookie("sessionId", Session.SessionID));
                return this.RedirectToAction("All", "Cars");
            }
            return this.RedirectToAction("Register");
        }
    }
}