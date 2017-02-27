using System.Data.Entity;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Data
{
    public class NotesAppContext : DbContext, IDbIdentityContext
    {
        public NotesAppContext() : base("NotesAppContext")
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public DbSet<Login> Logins { get; set; }

        void IDbIdentityContext.SaveChanges()

        {
            this.SaveChanges();
        }
    }
}