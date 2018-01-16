using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CameraBazaar.Models.BindModels.Camera;
using CameraBazaar.Models.BindModels.User;
using CameraBazaar.Models.EntityModels;
using CameraBazaar.Models.ViewModels.Cameras;
using CameraBazaar.Models.ViewModels.Users;

namespace CameraBazaar.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserVm, User>();
                expression.CreateMap<Camera, ShortCameraVm>();
                expression.CreateMap<Camera, DetailsCameraVm>();
                expression.CreateMap<AddCameraBm, AddCameraVm>();
                expression.CreateMap<AddCameraBm, Camera>();
                expression.CreateMap<Camera, EditCameraVm>();
                expression.CreateMap<EditCameraBm, Camera>();
                expression.CreateMap<EditCameraBm, EditCameraVm>();
                expression.CreateMap<Camera, DeleteCameraVm>();
            });
        }
    }
}
