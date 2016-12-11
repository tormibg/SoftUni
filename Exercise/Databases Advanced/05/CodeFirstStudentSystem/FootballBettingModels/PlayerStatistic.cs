using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingModels
{
    public class PlayerStatistic
    {
        [Key]
        [Column(Order = 0)]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public int PlayedMinutesDuringGame { get; set; }
    }
}