using System.Data.Entity;
using SharpStoreDB.Models;

namespace SharpStoreDB
{
    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext() :base("SharpStoreContext")
        {
        }

        public IDbSet<Knive> Knives { get; set; }

        public IDbSet<Message> Messages { get; set; }
    }
}
