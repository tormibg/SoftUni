using System;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit : IUnit
    {
        protected Unit(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints )
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            this.CombatHandler = new CombatHandler(this);
        }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; private set; }
        public int Range { get; private set; }
        public int AttackPoints { get; set; }
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public int EnergyPoints { get; set; }
        public ICombatHandler CombatHandler { get; private set; }

        /*>{name} - {type} at ({x},{y})
          -Health points = {..} 
          -Attack points = {..}
          -Defense points = {..}
          -Energy points = {..}
          -Range = {..}
        */

        public override string ToString()
        {
          StringBuilder sbOut = new StringBuilder();
            sbOut.AppendLine(String.Format(">{0} - {1} at ({2},{3})",this.Name, GetType().Name,this.X, this.Y));
            if (this.HealthPoints <= 0)
            {
                sbOut.Append("(Dead)");
            }
            else
            {
                sbOut.AppendLine(String.Format("-Health points = {0}",this.HealthPoints));
                sbOut.AppendLine(String.Format("-Attack points = {0}", this.AttackPoints));
                sbOut.AppendLine(String.Format("-Defense points = {0}", this.DefensePoints));
                sbOut.AppendLine(String.Format("-Energy points = {0}", this.EnergyPoints));
                sbOut.Append(String.Format("-Range = {0}", this.Range));
            }
            return sbOut.ToString();
        }
    }
}