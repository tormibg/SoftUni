namespace AssessmentApp.Data.Models
{
    using AssessmentApp.Data.Common.Models;

    public class Assessment : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ActionName { get; set; }
    }
}
