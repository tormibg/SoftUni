using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystemModels
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Friends = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Names { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistredOn { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Student> Friends { get; set; }
    }
}
