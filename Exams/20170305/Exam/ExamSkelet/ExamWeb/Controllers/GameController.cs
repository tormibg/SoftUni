using System.Collections.Generic;
using System.Linq;
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
    public class GameController : Controller
    {
        private GameServices service;
        private SignInManager signInManager;

        public GameController()
        {
            this.service = new GameServices();
            this.signInManager = new SignInManager();
        }

        [HttpGet]
        public IActionResult<GameDatailsViewModel> Gamedetails(HttpResponse response, HttpSession session, int gameId)
        {
            //if (this.IsAuthenticated(session.Id, response))
            if (!this.signInManager.IsAuthenticated(session))
            {
                return null;
            }
            User currentUser = this.signInManager.GetAuthenticatedUser(session);

            GameDatailsViewModel viewModel = this.service.GetGameById(gameId, currentUser);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Gamedetails(HttpResponse response, HttpSession session, BuyGameBindingModel bgbm)
        {
            //if (this.IsAuthenticated(session.Id, response))
            if (!this.signInManager.IsAuthenticated(session))
            {
                return null;
            }
            this.service.BuyGame(bgbm.Gameid);
            this.Redirect(response, "/store/all");
            return null;
        }

        [HttpGet]
        public IActionResult<HashSet<AllGamesListViewModel>> All(HttpSession session, HttpResponse response)
        {
            //User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            HashSet<AllGamesListViewModel> viewModel = this.service.GetAllGames();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Addgame(HttpSession session, HttpResponse response)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            //User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Addgame(HttpSession session, HttpResponse response, AddGameBindingModel agbm)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            if (this.service.CheckGameInputDetails(agbm))
            {
                this.Redirect(response, "/game/addgame");
                return null;
            }

            this.service.AddGame(agbm);
            this.Redirect(response, "/store/all");
            return null;
        }

        [HttpGet]
        public IActionResult<GameEditViewModel> Editgame(HttpSession session, HttpResponse response, int gameId)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }
            GameEditViewModel gameView = this.service.GetGameByIdforEdit(gameId);

            return this.View(gameView);
        }

        [HttpPost]
        public IActionResult Editgame(HttpSession session, HttpResponse response, EditGameBindingModel egbm)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            if (this.service.CheckGameEditDetails(egbm))
            {
                this.Redirect(response, "/game/editgame");
                return null;
            }
            this.service.EditGame(egbm);
            this.Redirect(response, "/game/all");
            return null;
        }

        [HttpGet]
        public IActionResult Deletegame(HttpSession session, HttpResponse response, int gameId)
        {
            User currentUser = this.signInManager.GetAuthenticatedUser(session);
            if (currentUser == null)
            {
                this.Redirect(response, "/store/login");
                return null;
            }

            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/store/all");
                return null;
            }

            this.service.DeleteGamesById(gameId);
            this.Redirect(response, "/game/all");
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