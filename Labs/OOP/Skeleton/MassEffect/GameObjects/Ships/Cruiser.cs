using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

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

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
