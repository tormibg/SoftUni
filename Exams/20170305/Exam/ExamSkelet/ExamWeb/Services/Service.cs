using Ninject;
using SoftUniStore.App.Data.Contracts;
using SoftUniStore.App.DepedencyContainer;

namespace SoftUniStore.App.Services
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
