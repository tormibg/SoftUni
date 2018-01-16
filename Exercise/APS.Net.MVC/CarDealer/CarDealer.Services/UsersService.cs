using System;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;

namespace CarDealer.Services
{
    public class UsersService : Service
    {
        public void RegisterUser(UserRegisterVM bind)
        {
            User user = Mapper.Map<UserRegisterVM, User>(bind);
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool UserExists(UserLoginVM bind)
        {
            if (this.Context.Users.Any(user => user.Username == bind.Username && user.Password == bind.Password))
            {
                return true;
            }
            return false;
        }

        public void LoginUser(UserLoginVM bind, string httpCookieValue)
        {
            if (!this.Context.Logins.Any(login => login.SessionId == httpCookieValue))
            {
                var login = new Login() { SessionId = httpCookieValue };
                this.Context.Logins.Add(login);
                this.Context.SaveChanges();
            }

            Login myLogin = this.Context.Logins.FirstOrDefault(login => login.SessionId == httpCookieValue);
            myLogin.IsActive = true;
            myLogin.User = this.Context.Users.FirstOrDefault(
                    user => user.Username == bind.Username && user.Password == bind.Password);
            this.Context.SaveChanges();
        }
    }
}