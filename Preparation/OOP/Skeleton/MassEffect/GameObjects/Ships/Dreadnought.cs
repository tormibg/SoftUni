using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : Starship
    {
        private const int DefaultDreadnoughtHeath = 200;
        private const int DefaultDreadnoughtShields = 300;
        private const int DefaultDreadnoughtDamage = 150;
        private const int DefaultDreadnoughtFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaultDreadnoughtHeath, DefaultDreadnoughtShields, DefaultDreadnoughtDamage, DefaultDreadnoughtFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToAttack(IProjectile attack)
        {
            throw new System.NotImplementedException();
        }
    }
}