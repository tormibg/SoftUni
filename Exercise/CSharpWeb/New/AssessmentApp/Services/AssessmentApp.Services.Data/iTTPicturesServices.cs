namespace AssessmentApp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITtPicturesServices
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
