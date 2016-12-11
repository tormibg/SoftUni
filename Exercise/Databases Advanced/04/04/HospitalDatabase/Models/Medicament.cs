using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Medicament
    {
        [Key, Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}