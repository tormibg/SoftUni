using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Mage : Character,IAttack
    {
        private const int HealthPp = 150;
        private const int DefPoints = 50;
        private const int AttPoints = 300;
        private const int RanPoints = 5;

        public Mage(string id, int x, int y,  Team team)
            : base(id, x, y, HealthPp, DefPoints, team, RanPoints)
        {
            this.AttackPoints = AttPoints;
        }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var target = targetsList.LastOrDefault(tar => (tar.Team != this.Team && tar.IsAlive));
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
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            base.RemoveItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string retStr =  base.ToString();
            retStr += String.Format(", Attack: {0}",this.AttackPoints);
            return retStr;
        }

        public int AttackPoints { get; set; }
    }
}