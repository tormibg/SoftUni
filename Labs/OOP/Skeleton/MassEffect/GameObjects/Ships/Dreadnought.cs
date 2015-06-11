using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Dreadnought  : Starship
    {
        private const int DHealt = 200;
        private const int DShields = 300;
        private const int DDamage = 150;
        private const int DFuel = 700;

        public Dreadnought (string name, StarSystem location)
            : base(name, DHealt, DShields, DDamage, DFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;
            base.RespondToAttack(projectile);
            this.Shields -= 50;
        }
    }
}
