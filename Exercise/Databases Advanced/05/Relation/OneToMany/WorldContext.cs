using OneToMany.Models;

namespace OneToMany
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WorldContext : DbContext
    {
        public WorldContext()
            : base("name=WorldContext")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<StudentAddress> StudentAddresses { get; set; }

        public IDbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasRequired(st => st.StudentAddress)
                .WithRequiredPrincipal(address => address.Student);

            modelBuilder.Entity<School>()
                .HasMany(sch => sch.Students)
                .WithOptional(st => st.School);
            base.OnModelCreating(modelBuilder);
        }
    }
}