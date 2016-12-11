using System.ComponentModel.DataAnnotations.Schema;
using BillsPaymentModels;

namespace BillsPaymentData
{
    using System.Data.Entity;

    public class BillsPaymentContextTpc : DbContext
    {
        public BillsPaymentContextTpc()
            : base("name=BillsPaymentContext")
        {
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BillingDetail>();
            modelBuilder.Entity<BillingDetail>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<CreditCard>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("CreditCards");
            });

            modelBuilder.Entity<BankAccount>().Map(config =>
            {
                config.MapInheritedProperties();
                config.ToTable("BankAccount");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}