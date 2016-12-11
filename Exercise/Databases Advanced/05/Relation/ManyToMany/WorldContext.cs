using ManyToMany.Models;

namespace ManyToMany
{
    using System.Data.Entity;

    public class WorldContext : DbContext
    {

        public WorldContext()
            : base("name=WorldContext")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<StudentAddress> StudentAddresses { get; set; }

        public IDbSet<School> Schools { get; set; }

        public IDbSet<Subject> Subjects { get; set; }

        public IDbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //OneToOne
            modelBuilder.Entity<Student>()
                .HasRequired(st => st.StudentAddress)
                .WithRequiredPrincipal(address => address.Student);

            //OneToMany
            modelBuilder.Entity<School>()
                .HasMany(sch => sch.Students)
                .WithOptional(st => st.School);

            //ManyToMany
            modelBuilder.Entity<Student>()
                .HasMany(st => st.Friends)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }

}