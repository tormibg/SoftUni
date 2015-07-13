namespace SuperRpgGame
{
    public class Ork : Character
    {
        private const int OrkDamage = 100;
        private const int OrkHealt = 60;
        private const char OSymbol = 'O';

        public Ork(Position position,  string name)
            : base(position, OSymbol, OrkDamage, OrkHealt, name)
        {
        }
    }
}