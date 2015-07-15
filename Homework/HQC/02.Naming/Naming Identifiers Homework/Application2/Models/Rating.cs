namespace Minesweeper.Models
{
    public class Rating
    {
        public Rating()
        {
        }

        public Rating(string name, int points)
        {
            this.Player = name;
            this.RecordPoints = points;
        }
       
        public string Player { get; set; }

        public int RecordPoints { get; set; }
    }
}