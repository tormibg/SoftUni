using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : Starship
    {
        private const int DefaultFrigDamage = 30;
        private const int DefaultFrigHeath = 60;
        private const int DefaultFrigShields = 50;
        private const int DefaultFrigFuel = 220;

        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, DefaultFrigHeath, DefaultFrigShields, DefaultFrigDamage, DefaultFrigFuel, location)
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