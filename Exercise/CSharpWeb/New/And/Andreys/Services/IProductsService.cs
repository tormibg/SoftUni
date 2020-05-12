using Andreys.App.Models;
using Andreys.App.ViewModels.Products;

namespace Andreys.App.Services
{
    public interface IProductsService
    {
        HomeProductsModel GetAllProducts();
        void AddProduct(string inputName, string inputImageUrl, string inputDescription, in decimal inputPrice,
            string inputCategory, string inputGender);

        ProductDetailsModel GetDetails(int productId);
        void Delete(int id);
    }
}