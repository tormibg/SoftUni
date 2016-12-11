using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models
{
    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}