using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Color
    {
        public Color()
        {
            this.PrimaryColorTeam = new HashSet<Team>();
            this.SecondaryColorTeam = new HashSet<Team>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryColorTeam { get; set; }
        public virtual ICollection<Team> SecondaryColorTeam { get; set; }
    }
}