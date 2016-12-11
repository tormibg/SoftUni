using MassDefect.Models;

namespace MassDefect
{
    using System.Data.Entity;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public virtual IDbSet<SolarSystem> SolarSystems { get; set; }

        public virtual IDbSet<Star> Stars { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Anomalie> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Anomalies)
                .WithMany(p => p.Persons)
                .Map(m => m.ToTable("AnomalyVictims").MapLeftKey("PersonId").MapRightKey("AnomalyId"));

            modelBuilder.Entity<SolarSystem>()
                .HasMany(s => s.Stars)
                .WithOptional(st => st.SolarSystem)
                .HasForeignKey(st => st.SolarSystemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SolarSystem>()
                .HasMany(s => s.Planets)
                .WithOptional(p => p.SolarSystem)
                .HasForeignKey(p => p.SolarSystemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Star>()
                .HasMany(s => s.Planets)
                .WithOptional(p => p.Sun)
                .HasForeignKey(p => p.SunId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planet>()
                .HasMany(p => p.Persons)
                .WithOptional(per => per.HomePlanet)
                .HasForeignKey(per => per.HomePlanetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planet>()
                .HasMany(pl => pl.OriginAnomalies)
                .WithOptional(a => a.OriginPlanet)
                .HasForeignKey(a => a.OriginPlanetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planet>()
                .HasMany(pl => pl.TeleportAnomalies)
                .WithOptional(a => a.TeleportPlanet)
                .HasForeignKey(a => a.TeleportPlanetId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

}