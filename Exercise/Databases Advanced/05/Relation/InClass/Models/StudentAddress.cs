using System.ComponentModel.DataAnnotations.Schema;

namespace InClass.Models
{
    public class StudentAddress
    {
        //[ForeignKey("Student")]
        public int Id { get; set; }

        public string Address { get; set; }

        //[ForeignKey("Student")]
        //public int StudentAddressId { get; set; }

        public virtual Student Student { get; set; }
    }
}