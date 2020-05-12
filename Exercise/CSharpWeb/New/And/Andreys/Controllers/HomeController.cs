using Andreys.App.Services;
using Andreys.App.ViewModels.Home;
using Andreys.App.ViewModels.Products;

namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;

        public HomeController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        [HttpGet("/Home/Index")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                HomeProductsModel viewModel = this._productsService.GetAllProducts();
                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse HomeIndex()
        {
            return this.Redirect("/Home/Index");
        }
    }
}
