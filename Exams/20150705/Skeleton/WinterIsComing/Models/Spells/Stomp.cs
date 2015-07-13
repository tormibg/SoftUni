using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : ISpell
    {
        private const int StompEnergyCost = 10;

        private int damage;

        public Stomp(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = StompEnergyCost;
        }

        public int Damage { get; private set; }
        public int EnergyCost { get; private set; }

    }
}