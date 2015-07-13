namespace SuperRpgGame
{
    public class Fairy : Character
    {
        private const int FairyDamage = 100;
        private const int FairyHealt = 60;
        private const char FSymbol = 'F';

        public Fairy(Position position, string name)
            : base(position, FSymbol, FairyDamage, FairyHealt, name)
        {
        } 
    }
}