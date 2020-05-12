using System.Threading.Tasks;
using SulsApp;
using Work.MVC;

namespace SlusApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
