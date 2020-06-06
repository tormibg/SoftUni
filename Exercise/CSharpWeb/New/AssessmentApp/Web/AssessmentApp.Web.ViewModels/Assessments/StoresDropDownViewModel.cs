namespace AssessmentApp.Web.ViewModels.Assessments
{
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;

    public class StoresDropDownViewModel : IMapFrom<Store>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
