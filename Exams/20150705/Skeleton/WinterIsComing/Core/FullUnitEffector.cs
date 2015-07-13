using System.Collections.Generic;
using WinterIsComing.Contracts;

namespace WinterIsComing.Core.Exceptions
{
    public class FullUnitEffector : IUnitEffector
    {
        private const int HealtsToAdd = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
                unit.HealthPoints += HealtsToAdd;
            }
        }
    }
}