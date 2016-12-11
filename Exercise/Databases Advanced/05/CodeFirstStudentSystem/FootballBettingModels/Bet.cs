using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGame>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal BedMoney { get; set; }

        public DateTime BetDateTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}