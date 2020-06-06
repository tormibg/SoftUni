namespace AssessmentApp.Web.ViewModels.Assessments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HygieneAssessmentInputViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int Id { get; set; }

        public IEnumerable<StoresDropDownViewModel> Stores { get; set; }
    }
}
