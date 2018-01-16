using ExamWeb.Data.Contracts;
using ExamWeb.DepedencyContainer;
using Ninject;

namespace ExamWeb.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        protected IUnitOfWork Context { get; }
    }
}
