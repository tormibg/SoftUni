using MassEffect.GameObjects.Locations;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int projectilesFired;

        private const int FHealt = 60;
        private const int FShields = 50;
        private const int FDamage = 30;
        private const int FFuel = 220;

        public Frigate(string name, StarSystem location)
            : base(name, FHealt, FShields, FDamage, FFuel, location)
        {
        }
    }
}
