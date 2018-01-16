using ExamWeb.Data;
using ExamWeb.Data.Contracts;
using Ninject.Modules;

namespace ExamWeb.DepedencyContainer
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
