using Andreys.App.Models;
using Andreys.App.Services;
using Andreys.App.ViewModels.Products;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("/Products/Add")]
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Products/Add")]
        public HttpResponse Add(ProductInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name must be contain at least 4 or must have 20 characters");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("Description must have only 10 characters");
            }

            if (input.Price < 0)
            {
                return this.Error("Price must be > 0");
            }

            this._productsService.AddProduct(input.Name, input.ImageUrl, input.Description, input.Price, input.Category,
                input.Gender);
            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            ProductDetailsModel viewModel = this._productsService.GetDetails(id);
            return this.View(viewModel);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this._productsService.Delete(id);
            return this.Redirect("/");
        }
    }
}