using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Warrior : Character,IAttack
    {
        private const int HealthPp = 200;
        private const int DefPoints = 100;
        private const int AttPoints = 150;
        private const int RanPoints = 2;

        public Warrior(string id, int x, int y,  Team team)
            : base(id, x, y, HealthPp, DefPoints, team, RanPoints)
        {
            this.AttackPoints = AttPoints;
        }
        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var target = targetsList.FirstOrDefault(tar => (tar.Team != this.Team && tar.IsAlive));
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
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public int AttackPoints { get; set; }

        public override string ToString()
        {
            string retStr = base.ToString();
            retStr += String.Format(", Attack: {0}", this.AttackPoints);
            return retStr;
        }
    }
}