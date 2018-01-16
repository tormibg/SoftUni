using Ninject.Modules;
using SoftUniStore.App.Data;
using SoftUniStore.App.Data.Contracts;

namespace SoftUniStore.App.DepedencyContainer
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
