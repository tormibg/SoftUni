using StudentSystemModels;

namespace StudentSystemData
{
    using System.Data.Entity;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        public IDbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}