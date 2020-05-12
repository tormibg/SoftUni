using System;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using SlusApp.Services;
using Work.HTTP;
using Work.MVC;

namespace SlusApp.Controllers
{
    class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private ILogger logger;

        public UsersController(IUsersService usersService, ILogger logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        [HttpGet]
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            var username = this.Request.FormData["username"];
            var password = this.Request.FormData["password"];
            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            var username = this.Request.FormData["username"];
            var email = this.Request.FormData["email"];
            var password = this.Request.FormData["password"];
            var confirmPassword = this.Request.FormData["confirmPassword"];
            if (String.CompareOrdinal(password,confirmPassword) != 0)
            {
                return this.Error("Password not match !");
            }

            if (username?.Length < 5 || username?.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters");
            }

            if (password?.Length < 6 || password?.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters");
            }

            if (!IsValid(email))
            {
                return this.Error("Email is not valid.");
            }

            usersService.CreateUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
        {
            this.SignOut();
            return this.Redirect("/");
        }
        private bool IsValid(string emailAddress)
        {
            try
            {
                new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
