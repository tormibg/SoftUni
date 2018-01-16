namespace ExamWeb.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamWeb.Data.ExamWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamWeb.Data.ExamWebContext context)
        {
        }
    }
}
