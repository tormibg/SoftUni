using System.Collections.Generic;
using Company.Models;

namespace Company.Interface
{
    interface ISalesEmployee
    {
        IList<Sale> Sales { get; set; }

        void AddSales(IList<Sale> sales);
    }
}
