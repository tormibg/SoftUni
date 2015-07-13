using System;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private const int MinProdLenght = 3;
        private const int MaxProdLenght = 10;

       // private const int MinProdLenght = 3;
      //  private const int MaxProdLenght = 10;

        private string name;
        private string brand;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));

                Validator.CheckIfStringLengthIsValid(value, MaxProdLenght, MinProdLenght,
                    String.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinProdLenght,
                        MaxProdLenght));

                this.name = value;
            }
        }
        public string Brand { get; private set; }
        public decimal Price { get; private set; }
        public GenderType Gender { get; private set; }
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("")
        }
    }
}