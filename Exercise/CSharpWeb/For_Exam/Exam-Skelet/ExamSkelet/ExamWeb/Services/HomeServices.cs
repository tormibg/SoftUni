using System.Collections.Generic;
using System.Text.RegularExpressions;
using AutoMapper;
using ExamWeb.BindingModels;
using ExamWeb.Model;
using ExamWeb.ViewModels;

namespace ExamWeb.Services
{
    public class HomeServices : Service
    {
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            if (rubm.Username.Length < 3)
                return false;

            Regex regex = new Regex("^[a-z0-9]+$");
            if (!regex.IsMatch(rubm.Username))
                return false;

            if (!rubm.Email.Contains("@"))
                return false;

            Regex passRegex = new Regex("^[0-9]{4}$");
            if (!passRegex.IsMatch(rubm.Password))
                return false;

            if (rubm.Password != rubm.ConfirmPassword)
                return false;


            if (this.Context.Users.Any(user => user.Username == rubm.Username || user.Email == rubm.Email))
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
                    (user.Username == lubm.Username || user.Email == lubm.Username) &&
                    user.Password == lubm.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel lubm)
        {
            return this.Context.Users.FirstOrDefault(
                 user =>
                     (user.Username == lubm.Username || user.Email == lubm.Username) &&
                     user.Password == lubm.Password);
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

        public HashSet<AllUserViewModel> GetAllUsers()
        {
            HashSet<AllUserViewModel> allUsers = new HashSet<AllUserViewModel>();
            foreach (var usersEntity in Context.Users.Entities)
            {
                allUsers.Add(Mapper.Map<User, AllUserViewModel>(usersEntity));
            }

            return allUsers;
        }
    }
}