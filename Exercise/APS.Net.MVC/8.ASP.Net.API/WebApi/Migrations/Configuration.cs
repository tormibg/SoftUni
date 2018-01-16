using WebApi.Models;

namespace WebApi.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(WebApi.Models.ApplicationDbContext context)
		{
			context.Cats.AddOrUpdate(cat => cat.Name, new[]
			{
				new Cat()
				{
					Name = "Puh",
					Price = 2m
				},
				new Cat()
				{
					Name = "Puss in boots",
					Price = 14m
				},
				new Cat()
				{
					Name = "Snejko",
					Price = 4m
				},
				new Cat()
				{
					Name = "Pupi",
					Price = 5m
				},
			});
		}
	}
}
