using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveTest.Startup))]
namespace LiveTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
