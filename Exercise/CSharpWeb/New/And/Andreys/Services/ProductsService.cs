using System;
using System.Linq;
using Andreys.App.Models;
using Andreys.App.ViewModels.Products;
using Andreys.Data;

namespace Andreys.App.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext _dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public HomeProductsModel GetAllProducts()
        {
            IQueryable<HomeProductModel> products = this._dbContext.Products.Select(x => new HomeProductModel()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Price = x.Price
            });
            var returnProducts = new HomeProductsModel()
            {
                ProductModels = products
            };
            return returnProducts;
        }

        public void AddProduct(string inputName, string inputImageUrl, string inputDescription, in decimal inputPrice,
            string inputCategory, string inputGender)
        {
            Category enumCategory;
            Enum.TryParse(inputCategory, out enumCategory);
            Gender enumGender;
            Enum.TryParse(inputGender, out enumGender);
            var product = new Product()
            {
                Name = inputName,
                ImageUrl = inputImageUrl,
                Description = inputDescription,
                Price = inputPrice,
                Category = enumCategory,
                Gender = enumGender
            };
            this._dbContext.Products.Add(product);
            this._dbContext.SaveChanges();
        }

        public ProductDetailsModel GetDetails(int productId)
        {
            var viewModel = this._dbContext.Products.Where(x => x.Id == productId).Select(x => new ProductDetailsModel()
            {
                Id = x.Id,
                Category = x.Category.ToString(),
                Description = x.Description,
                Gender = x.Gender.ToString(),
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Price = x.Price,
            }).FirstOrDefault();

            return viewModel;
        }

        public void Delete(int id)
        {
            Product product = this._dbContext.Products.FirstOrDefault(x => x.Id == id);
            this._dbContext.Products.Remove(product);
            this._dbContext.SaveChanges();
        }
    }
}