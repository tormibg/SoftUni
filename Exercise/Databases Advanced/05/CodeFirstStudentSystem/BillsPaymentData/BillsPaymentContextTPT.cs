using System.ComponentModel.DataAnnotations.Schema;
using BillsPaymentModels;

namespace BillsPaymentData
{
    using System.Data.Entity;

    public class BillsPaymentContextTpt : DbContext
    {
        public BillsPaymentContextTpt()
            : base("name=BillsPaymentContext")
        {
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            base.OnModelCreating(modelBuilder);
        }
    }

}