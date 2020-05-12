using System;
using System.Net.Mail;
using Andreys.App.Services;
using Andreys.App.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("/Users/Login")]
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = _usersService.GetUserIdByNameAndPassword(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        [HttpGet("/Users/Register")]
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password and ConfirmPassword must be the same");
            }

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                return this.Error("Username must be contain at least 4 or must have 10 characters");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password must be contain at least 6 or must have 20 characters");
            }

            if (this._usersService.IsUserExists(input.Username) || this._usersService.IsEmailExist(input.Email))
            {
                return this.Error("Username or password exists");
            }

            this._usersService.Register(input.Username, input.Password, input.Email);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.LogOut();
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