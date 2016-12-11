using System.ComponentModel.DataAnnotations;

namespace _13.UniversitySystem.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}