namespace AssessmentApp.Services.Data
{
    using System.Collections.Generic;

    public interface IStoresService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
