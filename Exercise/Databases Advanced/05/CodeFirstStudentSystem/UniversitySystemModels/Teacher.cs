using System.Collections.Generic;

namespace UniversitySystemModels
{
    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}