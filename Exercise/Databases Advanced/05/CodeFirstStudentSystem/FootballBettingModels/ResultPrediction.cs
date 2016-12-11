using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingModels
{
    public class ResultPrediction
    {
        public enum Predictions
        {
            HomeTeamWin,
            DrawGame,
            AwayTeamWin
        }

        public ResultPrediction()
        {
            this.BetGames = new HashSet<BetGame>();
        }
        [Key]
        public int Id { get; set; }

        public Predictions Prediction { get; set; }

        public virtual ICollection<BetGame> BetGames { get; set; }
    }
}