using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    abstract class Projectile : IProjectile
    {
        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

       abstract public void Hit(IStarship targetShip);
    }
}
