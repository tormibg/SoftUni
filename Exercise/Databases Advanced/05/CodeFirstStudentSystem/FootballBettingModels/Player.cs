using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string PostionId { get; set; }
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}