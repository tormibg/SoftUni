using SimpleHttpServer;
using SimpleMVC;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Model;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App
{
    class RunExam
    {
        static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore.App");

        }

        private static void ConfigureMapper()
        {
            AutoMapper.Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBindingModel, User>();
                expression.CreateMap<Game, AllGamesViewModel>();
                expression.CreateMap<Game, AllGamesListViewModel>();
                expression.CreateMap<Game, GameDatailsViewModel>();
                expression.CreateMap<Game, GameEditViewModel>();
                expression.CreateMap<AddGameBindingModel, Game>();
            });
        }
    }
}
