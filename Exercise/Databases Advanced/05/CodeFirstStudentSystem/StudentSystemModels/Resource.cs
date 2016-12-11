using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystemModels
{
    public class Resource
    {
        public enum ResourceOfType
        {
            Video = 0,
            Presentation = 1,
            Document = 2,
            Other = 3
        }

        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceOfType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}