namespace TheSlum.Items
{
    public class Shield : Item
    {
        public new const int HealthEffect = 0;
        public new const int DefenseEffect = 50;
        public new const int AttackEffect = 0;

        public Shield(string id)
            : base(id, HealthEffect, DefenseEffect, AttackEffect)
        {
        }
    }
}