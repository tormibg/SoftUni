using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Blizzard  : ISpell
    {
        private const int BlizzardEnergyCost = 40;

        private int damage;

        public Blizzard(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = BlizzardEnergyCost;
        }

        public int Damage
        {
            get
            {
                return this.damage * 2;
            }
            private set { this.damage = value; }
        }
        public int EnergyCost { get; private set; }

    }
}