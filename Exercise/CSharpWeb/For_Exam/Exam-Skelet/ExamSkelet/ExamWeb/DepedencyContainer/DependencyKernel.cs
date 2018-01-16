using Ninject;
using SimpleMVC;

namespace ExamWeb.DepedencyContainer
{
    public class DependencyKernel
    {
        private static StandardKernel kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (kernel == null)
                {
                    kernel = new StandardKernel();
                    kernel.Load(MvcContext.Current.ApplicationAssembly);
                }

                return kernel;
            }
        }
    }
}
