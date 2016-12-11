using GringottsDatabase.Models;

namespace GringottsDatabase
{
    using System.Data.Entity;

    public class WizardDepositsContext : DbContext
    {
        public WizardDepositsContext()
            : base("name=WizardDepositsContext")
        {
        }

        public virtual IDbSet<WizardDeposits> WizardDepositses { get; set; }
    }
}