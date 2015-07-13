using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        private const int DefaultCruiserHeath = 100;
        private const int DefaultCruiserShields = 100;
        private const int DefaultCruiserDamage = 50;
        private const int DefaultCruiserFuel = 700;

        public Cruiser(string name, StarSystem location)
            : base(name, DefaultCruiserHeath, DefaultCruiserShields, DefaultCruiserDamage, DefaultCruiserFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToAttack(IProjectile attack)
        {
        }
    }
}