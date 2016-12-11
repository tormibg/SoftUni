using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class Student
    {

        public Student()
        {
            this.Subjects = new HashSet<Subject>();
            this.Friends = new HashSet<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Student> Friends { get; set; }

        public virtual Town BornTown { get; set; }

        public virtual Town LivingTown { get; set; }
    }
}