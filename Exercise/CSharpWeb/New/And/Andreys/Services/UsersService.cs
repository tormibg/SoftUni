using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Andreys.App.Models;
using Andreys.App.ViewModels.Products;
using Andreys.Data;

namespace Andreys.App.Services
{
    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext _dbContext;

        public UsersService(AndreysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetUserNameById(string userId)
        {
            string userName = this._dbContext.Users.Where(x => x.Id == userId).Select(x => x.Username).FirstOrDefault();
            return userName;
        }

        public string GetUserIdByNameAndPassword(string inputUsername, string inputPassword)
        {
            var hashPassword = this.Hash(inputPassword);
            string userId = this._dbContext.Users
                .Where(x => x.Username.ToLower() == inputUsername.ToLower() && x.Password == hashPassword)
                .Select(x => x.Id).FirstOrDefault();
            return userId;
        }

        public bool IsUserExists(string inputUsername)
        {
            bool user = this._dbContext.Users.Any(x => x.Username.ToLower() == inputUsername.ToLower());
            return user;
        }

        public bool IsEmailExist(string inputinputEmail)
        {
            bool email = this._dbContext.Users.Any(x => x.Email.ToLower() == inputinputEmail.ToLower());
            return email;
        }

        public void Register(string inputUsername, string inputPassword, string inputEmail)
        {
            var hashPassword = this.Hash(inputPassword);
            var User = new User()
            {
                Username = inputUsername,
                Email = inputEmail,
                Password = hashPassword
            };
            this._dbContext.Add(User);
            this._dbContext.SaveChanges();
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