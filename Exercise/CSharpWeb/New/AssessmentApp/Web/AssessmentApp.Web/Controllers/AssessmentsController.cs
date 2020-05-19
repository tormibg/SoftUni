namespace AssessmentApp.Web.Controllers
{
    using System.Security.Claims;

    using AssessmentApp.Services.Data;
    using AssessmentApp.Web.ViewModels.Assessments;
    using Microsoft.AspNetCore.Mvc;

    public class AssessmentsController : Controller
    {
        private readonly IAssessmentsService assessmentsService;

        public AssessmentsController(IAssessmentsService assessmentsService)
        {
            this.assessmentsService = assessmentsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { Assessments = this.assessmentsService.GetAll<IndexAssessmentViewModel>() };
            return this.View(viewModel);
        }

        public IActionResult HygieneAssessment()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var viewModel = this.assessmentsService.GetHygieneAssessmentVm(claimsIdentity);

            return this.View(viewModel);
        }
    }
}
