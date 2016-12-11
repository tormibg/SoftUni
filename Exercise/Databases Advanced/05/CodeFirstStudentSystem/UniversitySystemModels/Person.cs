using System.ComponentModel.DataAnnotations;

namespace UniversitySystemModels
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
