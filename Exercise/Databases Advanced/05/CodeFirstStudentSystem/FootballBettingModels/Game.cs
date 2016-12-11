using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.BetGames = new HashSet<BetGame>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        [Required]
        public int HomeGoals { get; set; }

        [Required]
        public int AwayGoals { get; set; }

        public DateTime GameDateTime { get; set; }

        public double HomeTeamWinBetRate { get; set; }

        public double AwayTeamWinBetRate { get; set; }

        public double DrowBetRate { get; set; }

        public int RoundId { get; set; }

        public virtual Round Round { get; set; }

        public int? CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}