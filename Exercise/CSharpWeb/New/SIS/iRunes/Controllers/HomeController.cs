using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRunes.Services;
using iRunes.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;

namespace iRunes.Controllers
{
    class HomeController : Controller
    {
        private readonly IUsersService useeService;

        public HomeController(IUsersService useeService)
        {
            this.useeService = useeService;
        }
        [HttpGet("/")]
        [HttpGet("/Home/Index")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var indexViewModel = new IndexViewModel
                {
                    Username = (string)this.useeService.GetUserNameById(this.User)
                };
                return this.View(indexViewModel, "Home");
            }

            return this.View("/");
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
