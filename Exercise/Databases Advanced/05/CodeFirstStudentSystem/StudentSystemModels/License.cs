using System.ComponentModel.DataAnnotations;

namespace StudentSystemModels
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}