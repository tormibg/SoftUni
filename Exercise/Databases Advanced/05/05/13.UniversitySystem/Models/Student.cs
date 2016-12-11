using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13.UniversitySystem.Models
{
    //[Table("Students")]
    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public double AverageGrade { get; set; }

        public string Attendance { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}