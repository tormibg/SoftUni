using System.Data.Entity;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.Data
{
    public class NotesAppContext : DbContext
    {
        public NotesAppContext() : base("NotesAppContext")
        {

        }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Note> Notes { get; set; }
    }
}