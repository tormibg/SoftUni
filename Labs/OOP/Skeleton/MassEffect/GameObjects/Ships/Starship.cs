using System;
using System.Collections;
using System.Collections.Generic;
using MassEffect.Engine;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    abstract class Starship : IStarship
    {
        private IList<Enhancement> enhancements; 

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

        public IProjectile ProduceAttack()
        {
            throw new System.NotImplementedException();
        }

        public void RespondToAttack(IProjectile attack)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Enhancements.Enhancement> Enhancements
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
        }
    }
}
