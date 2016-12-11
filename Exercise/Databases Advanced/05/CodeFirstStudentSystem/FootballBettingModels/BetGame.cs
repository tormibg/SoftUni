using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingModels
{
    public class BetGame
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Key, Column(Order = 1)]
        public int BetId { get; set; }
        public Bet Bet { get; set; }

        public int ResultPredictionId { get; set; }
        public ResultPrediction ResultPrediction { get; set; }
    }
}