using System.Collections.Generic;
using ExamWeb.BindingModels;
using ExamWeb.Model;
using ExamWeb.Services;
using ExamWeb.Utility;
using ExamWeb.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace ExamWeb.Controllers
{
    public class HomeController : Controller
    {
        private HomeServices service;

        public HomeController()
        {
            this.service = new HomeServices();
        }

        [HttpGet]
        public IActionResult Index(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            return this.View();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpSession session, HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (!this.service.IsRegisterModelValid(rubm))
            {
                this.Redirect(response, "/home/register");
                return null;
            }
            User user = this.service.GetUserFromRegisterBind(rubm);
            this.service.RegisterUser(user);
            this.Redirect(response, "home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            if (!this.service.IsLoginModelValid(lubm))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(lubm);

            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult<HashSet<AllUserViewModel>>  Users(HttpResponse response, HttpSession session)
        {
            HashSet<AllUserViewModel> viewModels = this.service.GetAllUsers();

            return this.View(viewModels);
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(sessionId))
            {
                this.Redirect(response, "/home/index");
                return true;
            }

            return false;
        }
    }
}