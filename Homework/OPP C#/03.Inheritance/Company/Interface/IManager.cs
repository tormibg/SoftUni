using System.Collections.Generic;
using Company.Models;

namespace Company.Interface
{
    interface IManager
    {
        IList<RegularEmployee> EmplList { get; set; }

        void AddEmployees(List<RegularEmployee> empl);

    }
}
