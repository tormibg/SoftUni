namespace AssessmentApp.Web.ViewModels.TtPictures
{
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;

    public class EmailsDropDownViewModel : IMapFrom<Email>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Emails { get; set; }
    }
}
