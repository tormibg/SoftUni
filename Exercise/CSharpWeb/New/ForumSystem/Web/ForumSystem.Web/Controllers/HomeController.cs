using ForumSystem.Services.Data;

namespace ForumSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using ForumSystem.Data;
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var vewModel = new IndexViewModel();
            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>();
            vewModel.Categories = categories;
            return this.View(vewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
