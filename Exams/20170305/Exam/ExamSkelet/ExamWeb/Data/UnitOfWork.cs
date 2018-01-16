using SoftUniStore.App.Data.Contracts;
using SoftUniStore.App.Data.Repositories;
using SoftUniStore.App.Model;

namespace SoftUniStore.App.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamWebContext context;
        private IRepository<Login> logins;
        private IRepository<User> users;
        private IRepository<Game> games;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Login> Logins
            => this.logins ?? (this.logins = new Repository<Login>(this.context.Logins));

        public IRepository<User> Users
            => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public IRepository<Game> Games
            => this.games ?? (this.games = new Repository<Game>(this.context.Games));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
