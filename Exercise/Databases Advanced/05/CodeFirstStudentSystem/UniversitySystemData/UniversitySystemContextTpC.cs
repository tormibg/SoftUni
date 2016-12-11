using System.Data.Entity;
using UniversitySystemModels;

namespace UniversitySystemData
{
    public class UniversitySystemContextTpc : DbContext
    {
        public UniversitySystemContextTpc():base("name=UniversitySystemContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Person>();
            modelBuilder.Entity<Teacher>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Teachers");
            });
            modelBuilder.Entity<Student>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("Students");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
