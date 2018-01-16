using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Model;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Services
{
    public class StoreServices : Service
    {
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            //if (string.IsNullOrEmpty(rubm.Fullname))
            //    return false;

            Regex regex = new Regex("^[a-zA-Z -.]+$");
            if (!regex.IsMatch(rubm.Fullname))
                return false;

            if (!rubm.Email.Contains("@"))
                return false;

            Regex passRegex = new Regex("?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}");
            if (!passRegex.IsMatch(rubm.Password))
                return false;

            if (rubm.Password != rubm.ConfirmPassword)
                return false;


            if (this.Context.Users.Any(user => user.Fullname == rubm.Fullname || user.Email == rubm.Email))
                return false;

            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel rubm)
        {
            User user = Mapper.Map<RegisterUserBindingModel, User>(rubm);
            return user;
        }

        public void RegisterUser(User user)
        {
            if (this.Context.Users.Count() == 0)
            {
                user.IsAdmin = true;
            }

            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        internal bool IsLoginModelValid(LoginUserBindingModel lubm)
        {
            return this.Context.Users.Any(
                user =>
                    (user.Email == lubm.Email) && user.Password == lubm.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel lubm)
        {
            return this.Context.Users.FirstOrDefault(
                 user =>
                     (user.Email == lubm.Email) && user.Password == lubm.Password);
        }

        public void LoginUser(User user, string sessionId)
        {
            this.Context.Logins.Add(new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            });

            this.Context.SaveChanges();
        }

        public HashSet<AllGamesViewModel> GetAllGames()
        {
            HashSet<AllGamesViewModel> allGames =  new HashSet<AllGamesViewModel>();
            foreach (var game in Context.Games.Entities)
            {
                game.Description = game.Description.Substring(0, 300);
                allGames.Add(Mapper.Map<Game, AllGamesViewModel>(game));
            }

            return allGames;
        }

        public HashSet<AllGamesViewModel> GetOwnedGames(User currentUser)
        {
            HashSet<AllGamesViewModel> allGames =  new HashSet<AllGamesViewModel>();

            foreach (var game in currentUser.Games)
            {
                allGames.Add(Mapper.Map<Game, AllGamesViewModel>(game));
            }

            return allGames;
        }
    }
}