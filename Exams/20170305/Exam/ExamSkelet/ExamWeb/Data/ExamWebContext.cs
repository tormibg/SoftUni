using System.Data.Entity;
using SoftUniStore.App.Model;

namespace SoftUniStore.App.Data
{
    public class ExamWebContext : DbContext
    {

        public ExamWebContext()
            : base("ExamWebContext")
        {
        }
        public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }
      
    }
}