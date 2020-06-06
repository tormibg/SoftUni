namespace AssessmentApp.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Data;
    using AssessmentApp.Web.ViewModels.Assessments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AssessmentsController : Controller
    {
        private readonly IAssessmentsService assessmentsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IStoresService storesService;

        public AssessmentsController(IAssessmentsService assessmentsService, UserManager<ApplicationUser> userManager, IStoresService storesService)
        {
            this.assessmentsService = assessmentsService;
            this.userManager = userManager;
            this.storesService = storesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { Assessments = this.assessmentsService.GetAll<IndexAssessmentViewModel>() };
            return this.View(viewModel);
        }

        public async Task<IActionResult> HygieneAssessmentAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var stores = this.storesService.GetAll<StoresDropDownViewModel>();

            // var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var viewModel = this.assessmentsService.GetHygieneAssessmentVm(user.Id, user.UserName);
            viewModel.Stores = stores;
            return this.View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            // TO DO
            return this.View();
        }
    }
}
