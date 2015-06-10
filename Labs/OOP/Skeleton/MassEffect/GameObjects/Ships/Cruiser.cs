using MassEffect.GameObjects.Locations;

namespace MassEffect.GameObjects.Ships
{
    class Cruiser  : Starship
    {
        private const int CHealt = 100;
        private const int CShields = 100;
        private const int CDamage = 50;
        private const int CFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, CHealt, CShields, CDamage, CFuel, location)
        {
        }
    }
}
