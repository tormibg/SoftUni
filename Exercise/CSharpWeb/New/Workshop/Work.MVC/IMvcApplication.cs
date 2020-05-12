using System.Collections.Generic;

namespace Work.MVC
{
    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);
        void ConfigureServices(IServiceCollection serviceCollection);
    }
}