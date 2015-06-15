using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private const int HealthPp = 75;
        private const int DefPoints = 50;
        private const int HPoints = 60;
        private const int RanPoints = 6;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, HealthPp, DefPoints, team, RanPoints)
        {
            this.HealingPoints = HPoints;
        }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var target = targetsList.OrderBy(t => t.HealthPoints).LastOrDefault(tar => (tar.Team == this.Team && tar.IsAlive && tar !=this));
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.HealingPoints += item.HealthEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.HealingPoints -= item.HealthEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string retStr = base.ToString();
            retStr += String.Format(", Healing: {0}", this.HealingPoints);
            return retStr;
        }

        public int HealingPoints { get; set; }
    }
}