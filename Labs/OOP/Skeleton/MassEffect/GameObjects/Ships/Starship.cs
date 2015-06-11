using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MassEffect.Engine;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    abstract class Starship : IStarship
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

        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public void AddEnhancement(Enhancements.Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }
            this.enhancements.Add(enhancement);
            foreach (Enhancement enhancement1 in enhancements)
            {
                this.Damage += enhancement1.DamageBonus;
                this.Fuel += enhancement1.FuelBonus;
                this.Shields += enhancement1.ShieldBonus;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(String.Format("--{0} - {1}",this.Name,this.GetType().Name));
            if (this.Health > 0)
            {
                output.AppendLine(String.Format("-Location: {0}",this.Location.Name));
                output.AppendLine(String.Format("-Health: {0}",this.Health));
                output.AppendLine(String.Format("-Shields: {0}",this.Shields));
                output.AppendLine(String.Format("-Damage: {0}", this.Damage));
                output.AppendLine(String.Format("-Fuel: {0}", this.Fuel));
                output.AppendLine(String.Format("-Enhancements: {0}", string.Join(", ", enhancements).TrimEnd()));
            }
            else
            {
                output.AppendLine(String.Format("(Destroyed)"));
            }
            return output.ToString().TrimEnd();
        }
    }
}
