using System.Data.Entity;
using _13.UniversitySystem.Models;

namespace _13.UniversitySystem
{
    public class TptContext : DbContext
    {
        public TptContext() : base("name=TPTContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            base.OnModelCreating(modelBuilder);
        }
    }
}