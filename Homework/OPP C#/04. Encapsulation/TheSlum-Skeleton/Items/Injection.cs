namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        public new const int HealthEffect = 200;
        public new const int DefenseEffect = 0;
        public new const int AttackEffect = 0;
        public new const int Timeout = 3;

        public Injection(string id)
            : base(id, HealthEffect, DefenseEffect, AttackEffect, Timeout)
        {
        }
    }
}