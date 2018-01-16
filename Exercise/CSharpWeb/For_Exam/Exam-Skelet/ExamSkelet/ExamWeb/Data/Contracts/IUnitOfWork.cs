using ExamWeb.Model;

namespace ExamWeb.Data.Contracts
{
    public interface IUnitOfWork
    {

        IRepository<Login> Logins { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
