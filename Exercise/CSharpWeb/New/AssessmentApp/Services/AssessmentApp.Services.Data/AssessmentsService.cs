namespace AssessmentApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AssessmentApp.Data.Common.Repositories;
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;
    using AssessmentApp.Web.ViewModels.Assessments;

    public class AssessmentsService : IAssessmentsService
    {
        private readonly IDeletableEntityRepository<Assessment> assessmentRepository;

        public AssessmentsService(IDeletableEntityRepository<Assessment> assessmentRepository)
        {
            this.assessmentRepository = assessmentRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Assessment> query = this.assessmentRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public object GetViewByAssessmentId(string id)
        {
            throw new System.NotImplementedException();
        }

        public HygieneAssessmentInputViewModel GetHygieneAssessmentVm(string userId, string userName)
        {
            var viewModel = new HygieneAssessmentInputViewModel()
            {
                UserId = userId,
                UserName = userName,
            };
            return viewModel;
        }
    }
}
