namespace AssessmentApp.Web.ViewModels.Assessments
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexAssessmentViewModel> Assessments { get; set; }
    }
}
