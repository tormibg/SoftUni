using System.ComponentModel.DataAnnotations.Schema;

namespace InClass.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }
    }
}