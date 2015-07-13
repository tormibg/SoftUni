using System;
using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.CombatHandlers
{
    public class CombatHandler : ICombatHandler
    {
        private const int IceGiantIncreasePointsAfterCastSpell = 5;
        private Units.Unit unit;
        private int mageCastSpells ;

        public CombatHandler(Units.Unit unit)
        {
            this.Unit = unit;
        }


        public IUnit Unit { get; set; }


        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            switch (this.Unit.GetType().Name)
            {
                case "IceGiant":
                    return IceGiantComabatHandler(candidateTargets);
                case "Mage":
                    return MageComabatHandler(candidateTargets);
                case "Warrior":
                    return WarriorComabatHandler(candidateTargets);
                default:
                    throw new GameException(String.Format("Unknown type of unit"));
            }
        }

        public ISpell GenerateAttack()
        {
            switch (this.Unit.GetType().Name)
            {
                case "IceGiant":
                    var IceGiantSpell = IceGiantSpellHandler();

                    if (Unit.EnergyPoints - IceGiantSpell.EnergyCost <= 0)
                    {
                        Console.WriteLine(GlobalMessages.NotEnoughEnergy, this.Unit.Name, IceGiantSpell.GetType().Name);
                        return new FireBreath(0);
                    }

                    this.Unit.EnergyPoints -= IceGiantSpell.EnergyCost;
                    this.Unit.AttackPoints += IceGiantIncreasePointsAfterCastSpell;
                    return IceGiantSpell;
                case "Mage":
                    ISpell mageSpell = null;
                    if (mageCastSpells == 0)
                    {
                        mageSpell = MageSpellHandlerFireBreath();
                    }
                    else
                    {
                        mageSpell = MageSpellHandlerBlizzard();
                    }

                    if (Unit.EnergyPoints - mageSpell.EnergyCost <= 0)
                    {
                        Console.WriteLine(GlobalMessages.NotEnoughEnergy, this.Unit.Name, mageSpell.GetType().Name);
                        return new FireBreath(0);
                    }
                    mageCastSpells++;
                    if (mageCastSpells > 1)
                    {
                        mageCastSpells = 0;
                    }
                    this.Unit.EnergyPoints -= mageSpell.EnergyCost;
                    return mageSpell;

                case "Warrior":
                    var warSpell = WarriorSpellHandler();
                    if (this.Unit.HealthPoints > 50)
                    {
                        if (Unit.EnergyPoints - warSpell.EnergyCost <= 0)
                        {
                            Console.WriteLine(GlobalMessages.NotEnoughEnergy, this.Unit.Name, warSpell.GetType().Name);
                            return new FireBreath(0);
                        }
                        this.Unit.EnergyPoints -= warSpell.EnergyCost;
                    }
                    return warSpell;
                default:
                    throw new GameException(String.Format("Unknown type of unit"));
            }
        }
    
        
        private IEnumerable<IUnit> IceGiantComabatHandler(IEnumerable<IUnit> candidateTargets)
        {
            IfCandidateIsNull(candidateTargets);

            IList<IUnit> units = new List<IUnit>();
            foreach (IUnit nextTarget in candidateTargets)
            {
                units.Add(nextTarget);
                if (this.Unit.HealthPoints <= 150)
                {
                    return units;
                }
            }
            return units;
        }

        private IEnumerable<IUnit> MageComabatHandler(IEnumerable<IUnit> candidateTargets)
        {
            IfCandidateIsNull(candidateTargets);

            int count = 0;
            IList<IUnit> units = new List<IUnit>();
            var nextTargets = candidateTargets.OrderByDescending( x => x.HealthPoints).ThenBy(x => x.Name).ToList();
            foreach (IUnit nextTarget in nextTargets)
            {
                units.Add(nextTarget);
                count++;
                if (count == 3)
                {
                    return units;
                }               
            }
            return units;
        }

        private IEnumerable<IUnit> WarriorComabatHandler(IEnumerable<IUnit> candidateTargets)
        {
            IfCandidateIsNull(candidateTargets);

            IList<IUnit> units = new List<IUnit>();
            var nextTargets = candidateTargets.OrderBy(x => x.HealthPoints).ThenBy(n => n.Name).ToList();
            foreach (IUnit nextTarget in nextTargets)
            {
                units.Add(nextTarget);
                return units;
            }
            return units;
        }

        private ISpell IceGiantSpellHandler()
        {
            var spell = new Stomp(this.Unit.AttackPoints);
            return spell;
        }


        private ISpell MageSpellHandlerFireBreath()
        {
                return new FireBreath(this.Unit.AttackPoints);
        }

        private ISpell MageSpellHandlerBlizzard()
        {
                return new Blizzard (this.Unit.AttackPoints);
        }

        private ISpell WarriorSpellHandler()
        {
            var spell = new Cleave(this.Unit.AttackPoints, this.Unit.HealthPoints);
            return spell;
        }

        private void IfCandidateIsNull(IEnumerable<IUnit> candidateTargets)
        {
            if (candidateTargets == null)
            {
                throw new ArgumentNullException("List of candidate cannot be null");
            }
        }
    }
}