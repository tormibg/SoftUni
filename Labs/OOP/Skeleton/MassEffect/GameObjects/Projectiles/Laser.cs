namespace MassEffect.GameObjects.Projectiles
{
    class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
            
        }

        public override void Hit(Interfaces.IStarship targetShip)
        {
            int extDamge = 0;

            if (targetShip.Shields < this.Damage)
            {
                extDamge = targetShip.Shields - this.Damage;
            }

            targetShip.Shields -= this.Damage;
            targetShip.Health -= extDamge;
        }
    }
}
