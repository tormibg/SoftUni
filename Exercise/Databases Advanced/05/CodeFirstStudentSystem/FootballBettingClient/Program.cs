using FootballBettingData;

namespace FootballBettingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.Initialize(true);
        }
    }
}
