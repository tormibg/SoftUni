using _13.UniversitySystem.Models;

namespace _13.UniversitySystem
{
    using System.Data.Entity;

    public class TphContext : DbContext
    {
        public TphContext()
            : base("name=TPHContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }
    }
}