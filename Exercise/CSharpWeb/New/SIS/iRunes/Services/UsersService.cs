using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using iRunes.Models;

namespace iRunes.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);
            User user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPassword);
            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public void Register(string username, string password, string email)
        {
            var User = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };
            this.db.Users.Add(User);
            this.db.SaveChanges();
        }

        public bool UserNameExists(string username)
        {
            var user = db.Users.FirstOrDefault(x => String.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase));
            return user != null;
        }

        public bool EmailExists(string email)
        {
            var result = db.Users.FirstOrDefault(x => String.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));
            return result != null;
        }

        public object GetUserNameById(string user)
        {
            var username = db.Users.Where(x => x.Id == user).Select(x => x.Username).FirstOrDefault();
            return username;
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}