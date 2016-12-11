using System.Data.Entity;
using UniversitySystemModels;

namespace UniversitySystemData
{
    public class UniversitySystemContextTpt : DbContext
    {
        public UniversitySystemContextTpt():base("name=UniversitySystemContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
            base.OnModelCreating(modelBuilder);
        }
    }
}
