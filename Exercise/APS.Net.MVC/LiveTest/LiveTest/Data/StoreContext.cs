using LiveTest.Models;

namespace LiveTest.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("StoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Game> Games { get; set; }
    }
}