using System.Data.Entity;
using UniversitySystemModels;

namespace UniversitySystemData
{
    public class UniversitySystemContextTph : DbContext
    {
        public UniversitySystemContextTph():base("name=UniversitySystemContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }
    }
}
