namespace BillsPaymentData.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BillsPaymentData.BillsPaymentContextTpt>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BillsPaymentData.BillsPaymentContext";
        }

        protected override void Seed(BillsPaymentData.BillsPaymentContextTpt context)
        {
        }
    }
}
