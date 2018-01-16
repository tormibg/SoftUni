

using ExamWeb.Data.Contracts;
using ExamWeb.Data.Repositories;
using ExamWeb.Model;

namespace ExamWeb.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamWebContext context;
        private IRepository<Login> logins;
        private IRepository<User> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Login> Logins
            => this.logins ?? (this.logins = new Repository<Login>(this.context.Logins));

        public IRepository<User> Users
            => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
