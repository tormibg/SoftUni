using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13.UniversitySystem.Models
{
    //[Table("Teacher")]
    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }
        [Required]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}