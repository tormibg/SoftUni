using System.Data.Entity;
using LearningSystem.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningSystem.Data
{
	public class LearningSystemContext : IdentityDbContext<ApplicationUser>
	{
		public LearningSystemContext()
			: base("LearningSystem")
		{
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Course> Courses { get; set; }

		public DbSet<Article> Articles { get; set; }

		public static LearningSystemContext Create()
		{
			return new LearningSystemContext();
		}
	}

}