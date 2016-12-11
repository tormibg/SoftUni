using System.Collections;
using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class Subject
    {
        public Subject()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}