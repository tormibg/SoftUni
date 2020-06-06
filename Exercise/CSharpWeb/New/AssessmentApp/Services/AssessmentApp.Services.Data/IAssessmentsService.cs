﻿namespace AssessmentApp.Services.Data
{
    using System.Collections.Generic;

    using AssessmentApp.Web.ViewModels.Assessments;

    public interface IAssessmentsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        object GetViewByAssessmentId(string id);

        HygieneAssessmentInputViewModel GetHygieneAssessmentVm(string userId, string userName);
    }
}
