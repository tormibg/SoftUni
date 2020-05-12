using System.Collections.Generic;
using System.Linq;

namespace Andreys.App.ViewModels.Products
{
    public class HomeProductsModel
    {
        public IQueryable<HomeProductModel> ProductModels { get; set; }
    }
}