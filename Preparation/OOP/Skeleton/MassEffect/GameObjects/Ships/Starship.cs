using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private readonly IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public Locations.StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public abstract void RespondToAttack(IProjectile attack);

        public IEnumerable<Enhancement> Enhancements {
            get { return this.enhancements; }
        }

        public void AddEnhancement(Enhancements.Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ShipException("Enhancement cannot be null");
            }
            this.enhancements.Add(enhancement);
            this.ApplayEnhancement(enhancement);
        }

        private void ApplayEnhancement(Enhancement enhancement)
        {

            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Shields += enhancement.ShieldBonus;

        }

        //--{shipName} - {shipType}
        //-Location: {locationName}
        //-Health: {health}
        //-Shields: {shields}
        //-Damage: {damage}
        //-Fuel: {fuel}
        //-Enhancements: {enh1, enh2, ...}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("--{0} - {1}", this.Name, GetType().Name));
            if (this.Health >= 0)
            {
                sb.AppendLine("(Destroyed)");
            }
            sb.AppendLine(String.Format("-Location: {0}", this.Location));
            sb.AppendLine(String.Format("-Health: {0}", this.Health));
            sb.AppendLine(String.Format("-Shields: {0}", this.Shields));
            sb.AppendLine(String.Format("-Damage: {0}", this.Damage));
            sb.AppendLine(String.Format("-Fuel: {0:F1}", this.Fuel));

            string enhOut = "N/A";
            if (this.enhancements.Any())
            {
                enhOut = string.Join(", ", this.enhancements);
            }
            sb.AppendLine(String.Format("-Enhancements: {0}", enhOut));

            return sb.ToString();
        }
    }
}