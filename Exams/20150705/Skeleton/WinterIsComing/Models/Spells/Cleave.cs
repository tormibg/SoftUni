using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Cleave : ISpell
    {
        private const int CleaveEnergyCost = 15;

        private int damage;
        private int healt;

        public Cleave(int damage, int healt)
        {
            this.Damage = damage;
            this.healt = healt;
            this.EnergyCost = CleaveEnergyCost;
        }

        public int Damage {
            get {
                if (this.healt <= 80)
                {
                    return this.damage + this.healt*2;
                }
                return this.damage;
            }
            private set { this.damage = value; }
        }
        public int EnergyCost { get; private set; }

    }
}