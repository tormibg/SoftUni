namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int GriffinDoubleDefenseWhenDefending = 5;
        private const int GriffinAddDefenseWhenSkip = 3;
        
        public Griffin()
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDoubleDefenseWhenDefending));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinAddDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}