namespace MassEffect.GameObjects.Projectiles
{
    class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage) : base(damage)
        {
            
        }
        public override void Hit(Interfaces.IStarship targetShip)
        {
            targetShip.Health -= this.Damage;
            targetShip.Shields -= (this.Damage*2);
        }
    }
}
