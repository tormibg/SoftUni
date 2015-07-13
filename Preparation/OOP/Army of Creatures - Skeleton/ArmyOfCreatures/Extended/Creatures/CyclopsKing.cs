using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18m;
        private const int CyclopsKingAddAttackWhenSkip  = 3;
        private const int CyclopsKingDoubleAttackWhenAttacking  = 4;
        private const int CyclopsKingEnemyDoubleDamage = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKingAddAttackWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKingDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(CyclopsKingEnemyDoubleDamage));
        }
    }
}
