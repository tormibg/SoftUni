namespace AssessmentApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AssessmentApp.Data.Common.Repositories;
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;

    public class TtPicturesServices : ITtPicturesServices
    {
        private readonly IDeletableEntityRepository<Email> emailRepository;

        public TtPicturesServices(IDeletableEntityRepository<Email> emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Email> stores = this.emailRepository.All().OrderBy(x => x.Name);
            return stores.To<T>().ToList();
        }
    }
}
