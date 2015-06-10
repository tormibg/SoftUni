
namespace Abstraction.Characters
{
    class Mage : Character
    {
        private const int MageHealth = 100;
        private const int MageMana = 300;
        private const int MageDamage = 75;

        public Mage()
            : base(MageHealth, MageMana, MageDamage)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= MageMana;
            target.Health -= this.Damage*2;
        }
    }
}
