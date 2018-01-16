using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Model;
using SoftUniStore.App.Services;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Controllers
{
    public class StoreController : Controller
    {
        private StoreServices service;
        private SignInManager signInManager;

        public StoreController()
        {
            this.service = new StoreServices();
            this.signInManager = new SignInManager();
        }

        [HttpGet]
        public IActionResult<HashSet<AllGamesViewModel>>  All(HttpSession session, HttpResponse response)
        {
            //User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            HashSet<AllGamesViewModel> viewModel = this.service.GetAllGames();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<HashSet<AllGamesViewModel>>  Owned(HttpSession session, HttpResponse response)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            HashSet<AllGamesViewModel> viewModel = this.service.GetOwnedGames(currentUser);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpSession session, HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (!this.service.IsRegisterModelValid(rubm))
            {
                this.Redirect(response, "/store/register");
                return null;
            }
            User user = this.service.GetUserFromRegisterBind(rubm);
            this.service.RegisterUser(user);
            this.Redirect(response, "/store/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            if (!this.service.IsLoginModelValid(lubm))
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(lubm);

            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/store/all");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            this.signInManager.Logout(response, session.Id);
            this.Redirect(response, "/store/login");
            return null;
        }

        //private bool IsAuthenticated(string sessionId, HttpResponse response)
        //{
        //    if (!AuthenticationManager.IsAuthenticated(sessionId))
        //    {
        //        this.Redirect(response, "/store/login");
        //        return true;
        //    }

        //    return false;
        //}
    }
}