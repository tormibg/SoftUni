namespace TheSlum
{
    using Interfaces;

    public abstract class Bonus : Item, ITimeoutable
    {
        protected Bonus(string id,int healthEffect, int defenseEffect, int attackEffect, int timeout)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = timeout;
            this.Countdown = timeout;
        }

        public int Timeout { get; set; }

        public int Countdown { get; set; }

        public bool HasTimedOut { get; set; }
    }
}
