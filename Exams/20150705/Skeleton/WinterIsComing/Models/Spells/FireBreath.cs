using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : ISpell
    {
        private const int FireBreathEnergyCost = 30;

        private int damage;

        public FireBreath(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = FireBreathEnergyCost;
        }

        public int Damage { get; private set; }
        public int EnergyCost { get; private set; }

    }
}