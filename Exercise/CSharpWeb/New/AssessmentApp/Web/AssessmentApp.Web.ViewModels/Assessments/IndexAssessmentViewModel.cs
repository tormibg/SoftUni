namespace AssessmentApp.Web.ViewModels.Assessments
{
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;

    public class IndexAssessmentViewModel : IMapFrom<Assessment>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ActionName { get; set; }
    }
}
