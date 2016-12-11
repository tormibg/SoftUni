using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, MaxLength(3), MinLength(3)]
        public string Initials { get; set; }

        [Required]
        public int PrimaryKitColor { get; set; }
        public virtual Color PrimaryColor { get; set; }

        [Required]
        public int SecondaryKitColor { get; set; }
        public virtual Color SecondaryColor { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public decimal Budget { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
