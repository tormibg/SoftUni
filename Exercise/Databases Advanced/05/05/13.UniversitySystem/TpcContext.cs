using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using _13.UniversitySystem.Models;

namespace _13.UniversitySystem
{
    public class TpcContext : DbContext
    {
        public TpcContext() : base("name=TPCContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Student>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Students");
            });
            modelBuilder.Entity<Teacher>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Teachers");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}