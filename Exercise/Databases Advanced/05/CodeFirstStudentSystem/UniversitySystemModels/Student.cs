using System.Collections.Generic;

namespace UniversitySystemModels
{
    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public double AverageGrade { get; set; }

        public int Attendance { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}