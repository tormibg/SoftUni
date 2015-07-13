namespace SuperRpgGame
{
    public class Ninja : Character
    {
        private const int NinjaDamage = 150;
        private const int NinjaHealt = 300;
        private const char NSymbol = 'N';

        public Ninja(Position position, string name)
            : base(position, NSymbol, NinjaDamage, NinjaHealt, name)
        {
        } 
    }
}