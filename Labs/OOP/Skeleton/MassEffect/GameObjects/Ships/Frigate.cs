using System;
using System.Text;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int _projectilesFired;

        private const int FHealt = 60;
        private const int FShields = 50;
        private const int FDamage = 30;
        private const int FFuel = 220;

        public Frigate(string name, StarSystem location)
            : base(name, FHealt, FShields, FDamage, FFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this._projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {   
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(base.ToString());
                sb.AppendLine( String.Format("-Projectiles fired: {0}",this._projectilesFired));
                return sb.ToString().TrimEnd();
            }
            return base.ToString().TrimEnd();
        }
    }
}
