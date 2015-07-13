using System;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private const int MinRounds = 1;
        private const int MaxRounds = 10;
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value < MinRounds || value > MaxRounds)
                {
                    throw new ArgumentOutOfRangeException("rounds",
                        string.Format("The numb of rounds int the range {0} .. {1}", MinRounds, MaxRounds));
                }

                this.rounds = value;
            }
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }
            this.rounds--;
            return currentDamage*2;
        }
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }


      /// ************************************************
        public override void ApplyWhenAttacking(Logic.Battles.ICreaturesInBattle attackerWithSpecialty, Logic.Battles.ICreaturesInBattle defender)
        {

        }

        public override void ApplyWhenDefending(Logic.Battles.ICreaturesInBattle defenderWithSpecialty, Logic.Battles.ICreaturesInBattle attacker)
        {

        }

        public override void ApplyAfterDefending(Logic.Battles.ICreaturesInBattle defenderWithSpecialty)
        {

        }

        public override void ApplyOnSkip(Logic.Battles.ICreaturesInBattle skipCreature)
        {

        }
    }
}