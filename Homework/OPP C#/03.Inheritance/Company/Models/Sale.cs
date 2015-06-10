using System;
using Company.Interface;

namespace Company.Models
{
    class Sale : ISale
    {
        //private string prodName;
        //private DateTime dateSale;
        //private decimal price;

        public Sale(string prodName, DateTime dateSale, decimal price)
        {
            this.ProdName = ProdName;
            this.DateSale = dateSale;
            this.Price = price;
        }

        public string ProdName { get; set; }
        public DateTime DateSale { get; set; }
        public decimal Price { get; set; }
    }
}
