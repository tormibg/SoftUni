namespace AssessmentApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AssessmentApp.Data.Common.Repositories;
    using AssessmentApp.Data.Models;
    using AssessmentApp.Services.Mapping;
    using AssessmentApp.Web.ViewModels.Assessments;

    public class StoresService : IStoresService
    {
        private readonly IDeletableEntityRepository<Store> storeRepository;

        public StoresService(IDeletableEntityRepository<Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Store> stores = this.storeRepository.All().OrderBy(x => x.Name);
            return stores.To<T>().ToList();
        }
    }
}
