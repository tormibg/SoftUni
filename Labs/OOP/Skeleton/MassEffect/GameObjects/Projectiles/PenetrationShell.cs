namespace MassEffect.GameObjects.Projectiles
{
    class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage) : base(damage)
        {
        }

        public override void Hit(Interfaces.IStarship targetShip)
        {
            targetShip.Shields -= this.Damage;
        }
    }
}
