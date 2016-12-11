using System.Data.Entity.Validation;
using System.Text;
using CreateUser.Models;

namespace CreateUser.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UsersContext context)
        {
            context.Towns.AddOrUpdate(t => t.Name,new Town()
            {
                Name = "Sofia",
                Country = "Bulgaria"
            }, new Town()
            {
                Name = "Berlin",
                Country = "Germany"
            }, new Town()
            {
                Name = "Vienna",
                Country = "Austria"
            });

            SaveChanges(context);

            Town sofia = context.Towns.FirstOrDefault(t => t.Name == "Sofia");
            Town berlin = context.Towns.FirstOrDefault(t => t.Name == "Berlin");

            var user1 = new User()
            {
                Age = 12,
                Email = "avb@abv.bg",
                Id = 3,
                IsDeleted = false,
                LastTimeLoggedIn = DateTime.Now,
                Password = "Qww1@qwer",
                RegisteredOn = DateTime.Now.AddDays(-4),
                Username = "Asen",
                TownInBorn = sofia,
                TownInLiving = berlin,
                FirstName = "Ivan",
                LastName = "Ivanov"
            };
            context.Users.AddOrUpdate(user1);

            SaveChanges(context);

        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
