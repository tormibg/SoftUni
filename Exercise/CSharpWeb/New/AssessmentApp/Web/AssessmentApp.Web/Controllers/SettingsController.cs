namespace AssessmentApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AssessmentApp.Data.Common.Repositories;
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Data;
    using AssessmentApp.Web.ViewModels.Settings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    public class SettingsController : BaseController
    {
        private readonly ISettingsService settingsService;

        private readonly IDeletableEntityRepository<Setting> repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public SettingsController(
            ISettingsService settingsService,
            IDeletableEntityRepository<Setting> repository,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.settingsService = settingsService;
            this.repository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var settings = this.settingsService.GetAll<SettingViewModel>();
            var model = new SettingsListViewModel { Settings = settings };

            // await this.roleManager.CreateAsync(new ApplicationRole
            // {
            //    Name = "EmailSenders",
            // });

            // var user = await this.userManager.GetUserAsync(this.User);
            // await this.userManager.AddToRoleAsync(user, "EmailSenders");
            return this.View(model);
        }

        public async Task<IActionResult> InsertSetting()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.repository.AddAsync(setting);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
