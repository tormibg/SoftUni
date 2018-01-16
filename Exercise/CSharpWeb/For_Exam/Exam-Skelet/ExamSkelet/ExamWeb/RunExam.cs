using ExamWeb.BindingModels;
using ExamWeb.Model;
using ExamWeb.ViewModels;
using SimpleHttpServer;
using SimpleMVC;

namespace ExamWeb
{
    class RunExam
    {
        static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "ExamWeb");

        }

        private static void ConfigureMapper()
        {
            AutoMapper.Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBindingModel, User>();
                expression.CreateMap<User, AllUserViewModel>();
            });
        }
    }
}
