using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CompetitionTypeId { get; set; }
        public virtual CompetitionType CompetitionType { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}