using System;

namespace Customer
{
    public class Payment : ICloneable
    { 
        //•	Define a class Payment which holds a product name and price.
        //private string prodName;
        //private decimal prodPrice;

        public Payment(string prodName, decimal prodPrice)
        {
            this.ProdName = prodName;
            this.ProdPrice = prodPrice;
        }

        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }

        public object Clone()
        {
            return new Payment(this.ProdName, this.ProdPrice);
        }
    }

}