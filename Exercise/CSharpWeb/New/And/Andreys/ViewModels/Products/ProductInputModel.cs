﻿using Andreys.App.Models;

namespace Andreys.App.ViewModels.Products
{
    public class ProductInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
    }
}