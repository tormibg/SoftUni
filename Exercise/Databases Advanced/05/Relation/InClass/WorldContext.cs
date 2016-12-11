using InClass.Models;

namespace InClass
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasRequired(st => st.StudentAddress)
                .WithRequiredPrincipal(address => address.Student);
            base.OnModelCreating(modelBuilder);
        }
    }

}