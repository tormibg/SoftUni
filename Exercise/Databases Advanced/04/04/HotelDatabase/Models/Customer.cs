using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Customer
    {
        [Key, Range(1,int.MaxValue)]
        public int AccountNumber { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmergencyName { get; set; }

        public string EmergencyNumber { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}