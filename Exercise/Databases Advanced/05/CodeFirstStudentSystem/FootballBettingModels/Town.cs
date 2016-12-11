using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CountyId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}