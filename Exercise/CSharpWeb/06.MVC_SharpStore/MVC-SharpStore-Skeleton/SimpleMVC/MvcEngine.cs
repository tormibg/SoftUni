using System;
using System.Reflection;
using SimpleHttpServer;

namespace SimpleMVC
{
    public static class MvcEngine
    {
        public static void Run(HttpServer server, string appAplicationAssemblyName)
        {
            RegisterAssemblyName(appAplicationAssemblyName);
            LoadApplicationAssembly(appAplicationAssemblyName);
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                //Log errors
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadApplicationAssembly(string appAplicationAssemblyName)
        {
            MvcContext.Current.ApplicationAssembly = Assembly.Load(appAplicationAssemblyName);
        }

        private static void RegisterAssemblyName(string appAplicationAssemblyName)
        {
            MvcContext.Current.AssemblyName = appAplicationAssemblyName;
            // Assembly.GetExecutingAssembly().GetName().Name;

        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
            MvcContext.Current.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }
    }
}
