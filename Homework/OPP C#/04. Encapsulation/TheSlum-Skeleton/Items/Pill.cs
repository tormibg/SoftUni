using System.Data;
using System.Threading;

namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        public new const int HealthEffect = 0;
        public new const int DefenseEffect = 0;
        public new const int AttackEffect = 100;
        public new const int Timeout = 1;

        public Pill(string id)
            : base(id, HealthEffect, DefenseEffect, AttackEffect, Timeout)
        {
        }
    }
}