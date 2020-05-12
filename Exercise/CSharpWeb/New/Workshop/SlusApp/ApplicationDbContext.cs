using Microsoft.EntityFrameworkCore;
using SlusApp.Models;

namespace SlusApp
{
    public class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SlusApp;Integrated Security=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Problems> Problems { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
    }
}
