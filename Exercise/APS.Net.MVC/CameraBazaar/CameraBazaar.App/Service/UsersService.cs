using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels.Cameras;
using CameraBazaar.Models.ViewModels.Users;

namespace CameraBazaar.App.Service
{
    public class UsersService : Service
    {
        public bool UsernameExists(RegisterUserVm bind)
        {
            if (this.Context.Users.Any(u => u.Username == bind.Username || u.Email == bind.Email))
            {
                return true;
            }

            return false;
        }

        public void AddUser(RegisterUserVm bind)
        {
            User user = Mapper.Map<RegisterUserVm, User>(bind);
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool UserExists(LoginUserVm bind)
        {
            if (this.Context.Users.Any(u => u.Username == bind.Username && u.Password == bind.Password))
            {
                return true;
            }

            return false;
        }

        public void LoginUser(LoginUserVm bind, string sessionSessionId)
        {
            if (!this.Context.Logins.Any(l => l.SessionId == sessionSessionId))
            {
                this.Context.Logins.Add(new Login() { SessionId = sessionSessionId });
                this.Context.SaveChanges();
            }
            Login login = this.Context.Logins.FirstOrDefault(l => l.SessionId == sessionSessionId);
            login.IsActive = true;
            User user = this.Context.Users.FirstOrDefault(u => u.Username == bind.Username && u.Password == bind.Password);
            login.User = user;
            this.Context.SaveChanges();
        }

        public ProfilePageVm GetProfilePage(string wantedUsername, string currentUsername)
        {
            User user = this.Context.Users.First(u => u.Username == wantedUsername);
            if (user == null)
            {
                return null;
            }
            ProfilePageVm page = new ProfilePageVm
            {
                Username = user.Username,
                Email = user.Email,
                InStockCameras = user.Cameras.Count(c => c.Quantity > 0),
                OutOfStockCameras = user.Cameras.Count(c => c.Quantity == 0),
                Phone = user.Phone,
                Id = user.Id,
                Cameras = Mapper.Map<IEnumerable<Camera>, IEnumerable<ShortCameraVm>>(user.Cameras)
            };
            if (currentUsername == wantedUsername)
            {
                page.Id = 0;
            }

            return page;
        }

        public EditUserVm GetEditUserVm(User user)
        {
            EditUserVm editUser = new EditUserVm();
            //User currentUser = this.Context.Users.Find(user.Id);
            editUser.Phone = user.Phone;
            editUser.Email = user.Email;
            editUser.Id = user.Id;
            return editUser;
        }

        public void EditUser(EditUserVm bind)
        {
            User user = this.Context.Users.Find(bind.Id);
            user.Email = bind.Email;
            user.Password = bind.Password;
            user.Phone = bind.Phone;
            this.Context.SaveChanges();
        }
    }
}