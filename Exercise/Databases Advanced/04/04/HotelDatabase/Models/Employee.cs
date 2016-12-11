using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Employee
    {
        [Key,Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}