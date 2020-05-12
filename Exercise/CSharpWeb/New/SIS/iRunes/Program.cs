using System;
using System.Threading.Tasks;
using SIS.MvcFramework;

namespace iRunes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}
