using SoftUniStore.App.Model;

namespace SoftUniStore.App.Data.Contracts
{
    public interface IUnitOfWork
    {

        IRepository<Login> Logins { get; }

        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}
