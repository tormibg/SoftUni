using LiveTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LiveTest.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<LiveTest.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(LiveTest.Models.ApplicationDbContext context)
		{
			var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

			var roleCreated = roleManager.Create(new IdentityRole("Admin"));
			if (!roleManager.Roles.Any())
			{
				if (roleCreated.Succeeded)
				{
					var user = userManager.Users.FirstOrDefault();
					userManager.AddToRole(user?.Id, "Admin");
				}
			}
		}
	}
}
