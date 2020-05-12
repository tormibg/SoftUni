using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SlusApp.Models;
using Work.MVC;

namespace SlusApp.Services
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext db { get; set; }
        public UsersService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = this.Hash(password),
                Username = username,
                Role = IdentityRole.User,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public void ChangePassword(string username, string newPassword)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user != null) user.Password = this.Hash(newPassword);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);
            return this.db.Users.Where(x =>
                x.Username == username && x.Password == hashPassword).Select(x => x.Id).FirstOrDefault();
        }

        public int CountUsers()
        {
            return db.Users.Count();
        }

        private string Hash(string password)
        {
            if (password == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}