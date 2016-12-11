namespace MiniORMLive
{
    using System;
    using CustomORM.Core;
    using MiniORMLive.Entities;

    class Program
    {
        static void Main()
        {
            string connectionString = new ConnectionStringBuilder("MyWebSiteDatabase").ConnectionString;
            IDbContext context = new EntityManager(connectionString, true);

            User abv = context.FindById<User>(6);
            Console.WriteLine(abv.RegistrationDate);
        }
    }
}
