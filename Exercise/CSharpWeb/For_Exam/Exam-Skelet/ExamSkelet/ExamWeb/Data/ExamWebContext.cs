using System.Data.Entity;
using ExamWeb.Model;

namespace ExamWeb.Data
{
    public class ExamWebContext : DbContext
    {

        public ExamWebContext()
            : base("ExamWebContext")
        {
        }
        public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }
      
    }
}