namespace AssessmentApp.Data.Models
{
    using AssessmentApp.Data.Common.Models;

    public class Email : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Emails { get; set; }
    }
}
