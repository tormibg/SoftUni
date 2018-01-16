using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AutoMapper;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Model;
using SoftUniStore.App.Utility;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Services
{
    public class GameServices : Service
    {
        public GameDatailsViewModel GetGameById(int gameId, User currentUser)
        {
            Game gameFound = Context.Games.Find(gameId);
            //GameDatailsViewModel game = Mapper.Map<Game, GameDatailsViewModel>(gameFound);
            GameDatailsViewModel game = new GameDatailsViewModel()
            {
                Description = gameFound.Description,
                Id = gameId,
                Price = gameFound.Price,
                ReleaseDate = gameFound.ReleaseDate,
                Size = gameFound.Size,
                Title = gameFound.Title,
                Trailer = gameFound.Trailer,
                Owners = gameFound.Owners.ToList(),
                curUserId = currentUser.Id
            };
            return game;
        }

        public GameEditViewModel GetGameByIdforEdit(int gameId)
        {
            Game gameFound = Context.Games.Find(gameId);
            GameEditViewModel game = Mapper.Map<Game, GameEditViewModel>(gameFound);
            return game;
        }

        internal void BuyGame(int gameId)
        {
            string currentUser = ViewBag.Bag["fullname"];
            User user = this.Context.Users.FirstOrDefault(u => u.Fullname == currentUser);
            Game game = this.Context.Games.Find(gameId);
            game.Owners.Add(user);
            this.Context.SaveChanges();
        }

        public HashSet<AllGamesListViewModel> GetAllGames()
        {
            HashSet<AllGamesListViewModel> allGames = new HashSet<AllGamesListViewModel>();
            foreach (var game in Context.Games.Entities)
            {
                allGames.Add(Mapper.Map<Game, AllGamesListViewModel>(game));
            }

            return allGames;
        }

        public bool CheckGameEditDetails(EditGameBindingModel agbm)
        {
            if (agbm.Title.Length > 100 || agbm.Title.Length < 4 || char.IsUpper(agbm.Title[0]))
                return false;

            if (agbm.Price <= 0)
                return false;

            if (agbm.Size <= 0)
                return false;

            Regex regex = new Regex(@"^http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-\_]*)(&(amp;)?‌​[\w\?‌​=]*)?");
            if (!regex.IsMatch(agbm.Trailer))
                return false;

            regex = new Regex(@"^(http|https):");
            if (!regex.IsMatch(agbm.ImageThumbnail))
                return false;

            if (agbm.Description.Length < 20)
                return false;

            return true;
        }

        public bool CheckGameInputDetails(AddGameBindingModel agbm)
        {
            if (agbm.Title.Length > 100 || agbm.Title.Length < 4 || char.IsUpper(agbm.Title[0]))
                return false;

            if (agbm.Price <= 0)
                return false;

            if (agbm.Size <= 0)
                return false;

            Regex regex = new Regex(@"^http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-\_]*)(&(amp;)?‌​[\w\?‌​=]*)?");
            if (!regex.IsMatch(agbm.Trailer))
                return false;

            regex = new Regex(@"^(http|https):");
            if (!regex.IsMatch(agbm.ImageThumbnail))
                return false;

            if (agbm.Description.Length < 20)
                return false;

            return true;
        }

        public void AddGame(AddGameBindingModel agbm)
        {
            Game game = Mapper.Map<AddGameBindingModel, Game>(agbm);
            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }

        public void EditGame(EditGameBindingModel egbm)
        {
            Game game = this.Context.Games.Find(egbm.Id);
            game.Description = egbm.Description;
            game.ImageThumbnail = egbm.ImageThumbnail;
            game.Price = egbm.Price;
            game.Size = egbm.Size;
            game.Title = egbm.Title;
            game.Trailer = egbm.Trailer;

            this.Context.SaveChanges();
        }

        public void DeleteGamesById(int gameId)
        {
            this.Context.Games.Remove(gameId);
            this.Context.SaveChanges();
        }
    }
}