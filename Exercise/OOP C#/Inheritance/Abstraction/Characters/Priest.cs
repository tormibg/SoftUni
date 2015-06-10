
namespace Abstraction.Characters
{
    class Priest : Character, Interfaces.IHeal
    {
        private const int PriestHealth = 300;
        private const int PriestMana = 0;
        private const int PriestDamage = 120;
        private const int StealHealth = 10;
        private const int PriestHealt = 150;
        private const int PriestHealtMana = 100;

        public Priest()
            : base(PriestHealth, PriestMana, PriestDamage)
        {
        }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
            this.Health += this.Damage / StealHealth;
        }

        public void Heal(Character target)
        {
            this.Mana -= PriestHealtMana;
            target.Health += PriestHealt;
        }
    }
}
