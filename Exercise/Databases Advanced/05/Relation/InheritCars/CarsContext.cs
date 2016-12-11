using InheritCars.Models;

namespace InheritCars
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarsContext : DbContext
    {

        public CarsContext()
            : base("name=CarsContext")
        {
        }

        public IDbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>()
            //.Map<LuxiriosCar>(m => m.Requires("Type")
            //    .HasValue("Lux"))
            //.Map<BatMobil>(m => m.Requires("Type")
            //    .HasValue("Bat"));

            //modelBuilder.Entity<LuxiriosCar>().ToTable("LuxiriosCar");
            //modelBuilder.Entity<BatMobil>().ToTable("BatMobil");

            modelBuilder.Entity<LuxiriosCar>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("LuxiriosCarsi");
            });

            modelBuilder.Entity<BatMobil>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BatMobili");
            });



            base.OnModelCreating(modelBuilder);
        }
    }

}