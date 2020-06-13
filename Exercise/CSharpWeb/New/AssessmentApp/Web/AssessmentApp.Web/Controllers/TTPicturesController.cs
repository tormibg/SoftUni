namespace AssessmentApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AssessmentApp.Data.Models;
    using AssessmentApp.Web.ViewModels.TTPictures;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class TTPicturesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public TTPicturesController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            var model = new TPPicturesInputViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(TPPicturesInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.Redirect("/");
        }
    }
}
