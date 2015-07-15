namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Orders
    {
        private const int TopNumber = 5;
     
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            if (allProducts != null)
            {
                var fiveMostExpensiveProducts = allProducts
                    .OrderByDescending(p => p.UnitPrice)
                    .Take(TopNumber)
                    .Select(p => p.Nome);
                Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProducts));
            }

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            if (allProducts != null)
            {
                var second = allProducts
                    .GroupBy(p => p.CatId)
                    .Select(grp => new
                                       {
                                           Category = allCategories.First(c => c.Id == grp.Key).Name, 
                                           Count = grp.Count()
                                       })
                    .ToList();
                foreach (var item in second)
                {
                    Console.WriteLine("{0}: {1}", item.Category, item.Count);
                }
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            if (allOrders != null)
            {
                var fiveTopProducts = allOrders
                    .GroupBy(o => o.ProductId)
                    .Select(grp => new
                                       {
                                           Product = allProducts.First(p => p.Id == grp.Key).Nome, 
                                           Quantities = grp.Sum(grpgrp => grpgrp.Quantity)
                                       })
                    .OrderByDescending(q => q.Quantities)
                    .Take(TopNumber);
                foreach (var item in fiveTopProducts)
                {
                    Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
                }
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            if (allOrders != null)
            {
                var mostProfitableCategory =
                    allOrders.GroupBy(o => o.ProductId)
                        .Select(
                            g =>
                            new
                                {
                                    catId = allProducts.First(p => p.Id == g.Key).CatId,
                                    price = allProducts.First(p => p.Id == g.Key).UnitPrice,
                                    quantity = g.Sum(p => p.Quantity)
                                })
                        .GroupBy(gg => gg.catId)
                        .Select(
                            grp =>
                            new
                                {
                                    category_name = allCategories.First(c => c.Id == grp.Key).Name,
                                    total_quantity = grp.Sum(g => g.quantity * g.price)
                                })
                        .OrderByDescending(g => g.total_quantity)
                        .First();
                Console.WriteLine("{0}: {1}", mostProfitableCategory.category_name, mostProfitableCategory.total_quantity);
            }
        }
    }
}
