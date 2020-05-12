using Microsoft.EntityFrameworkCore;

namespace DemoApp
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DemoApp;Integrated Security=True;");
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
