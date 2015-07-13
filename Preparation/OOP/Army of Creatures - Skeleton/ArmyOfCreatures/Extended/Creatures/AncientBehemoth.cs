namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class AncientBehemoth : Creature
    {
        private const int DefaultAncientBehemothAttack = 19;
        private const int DefaultAncientBehemothDefense = 19;
        private const int DefaultAncientBehemothHealth = 300;
        private const decimal DefaultAncientBehemothDamage = 40;
        private const int AncientBehemothEnemyDefenseReductionPercentage = 80;
        private const int AncientBehemothEnemyDoubleDefenseWhenDefending = 5;

        public AncientBehemoth()
            : base(DefaultAncientBehemothAttack, DefaultAncientBehemothDefense, DefaultAncientBehemothHealth, DefaultAncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemothEnemyDefenseReductionPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemothEnemyDoubleDefenseWhenDefending));
        }
    }
}
