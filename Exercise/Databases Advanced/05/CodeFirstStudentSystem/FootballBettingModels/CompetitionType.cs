using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class CompetitionType
    {
        public CompetitionType()
        {
            this.Competitions = new HashSet<Competition>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}