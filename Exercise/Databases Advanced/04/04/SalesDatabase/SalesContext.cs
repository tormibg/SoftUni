using SalesDatabase.Models;

namespace SalesDatabase
{
    using System.Data.Entity;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SalesContext>());
            this.Database.Initialize(true);
        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Sale> Sales { get; set; }
        public IDbSet<StoreLocation> StoreLocations { get; set; }
    }

}