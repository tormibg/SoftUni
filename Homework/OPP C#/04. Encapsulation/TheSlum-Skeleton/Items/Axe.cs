namespace TheSlum.Items
{
    public class Axe : Item
    {
        public new const int HealthEffect = 0;
        public new const int DefenseEffect = 0;
        public new const int AttackEffect = 75;

        public Axe(string id)
            : base(id, HealthEffect, DefenseEffect, AttackEffect)
        {
        }
    }
}