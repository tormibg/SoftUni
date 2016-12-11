using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToMany.Models
{
    public class Town
    {
        public Town()
        {
            this.BornStudents = new HashSet<Student>();
            this.LivingStudents = new HashSet<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        [InverseProperty("BornTown")]
        public virtual ICollection<Student> BornStudents { get; set; }
        [InverseProperty("LivingTown")]
        public virtual ICollection<Student> LivingStudents { get; set; }
    }
}